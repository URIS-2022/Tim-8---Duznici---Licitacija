using Licitation.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Licitation.API.Data;

/// <summary>
/// Initializes a new instance of the LicitationDBContext class.
/// </summary>
/// <param name="options">The options to be used by the database context.</param>
/// <param name="configuration">The configuration used by the database context.</param>
public class LicitationDBContext : DbContext

{
    private readonly IConfiguration Configuration;

    /**
    <summary>Initializes a new instance of the <c>LicitationDBContext</c> class with the specified options and configuration.</summary>
    <param name="options">The options used to configure this context.</param>
    <param name="configuration">The configuration used to configure this context.</param>
    */
    public LicitationDBContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        this.Configuration = configuration;
    }
    /// <summary>
    /// Gets or sets the set of Licitation entities.
    /// </summary>
    public DbSet<Entities.Licitation> LicitationEntities { get; set; }
    /// <summary>
    /// Gets or sets the set of Document entities.
    /// </summary>
    public DbSet<Document> Documents { get; set; }
    /// <summary>
    /// Gets or sets the set of LicitationLand entities.
    /// </summary>
    public DbSet<LicitationLand> LicitationLands { get; set; }

    /// <summary>
    /// Gets or sets the set of PublicBidding entities associated with Licitation.
    /// </summary>
    public DbSet<PublicBidding> LicitationPublicBiddings { get; set; }

    /// <summary>
    /// Override of OnModelCreating method from DbContext, called when the model for a derived context has been initialized, allowing further configuration to be applied to the model.
    /// This method can be used to configure entity mappings, relationships, database constraints, and other model-related settings.
    /// </summary>
    /// <param name="modelBuilder">The builder being used to construct the model for this context.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        /*
        modelBuilder.Entity<LicitationEntity>()
            .HasData(
               new LicitationEntity
               {
                   Guid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                   Stage = 2,
                   Date = new DateTime(2023, 2, 11),
                   Year = 2023,
                   Constarint = 0,
                   BidIncrement = 100,
                   ApplicationDeadline = new DateTime(2023, 2, 11),
                   LandGuids = new List<Guid>
                   {
                        Guid.Parse("9de0c01b-b7b0-4df2-9009-3df21b91a0ss"),
                        Guid.Parse("1de0c01b-b7b0-4df2-9009-3df21b91a0cc"),
                        Guid.Parse("2de0c01b-b7b0-4df2-9009-3df21b91a0dd"),
                        Guid.Parse("3de0c01b-b7b0-4df2-9009-3df21b91a0ee")
                   },
                   PublicBiddingGuids = new List<Guid>
                   {
                        Guid.Parse("3de0c01b-b7b0-4df2-9009-3df21b91a0ss"),
                        Guid.Parse("5de0c01b-b7b0-4df2-9009-3df21b91a0cc"),
                        Guid.Parse("2de9c01b-b7b0-4df2-9009-3df21b91a0dd"),
                        Guid.Parse("3de7c01b-b7b0-4df2-9009-3df21b91a0ee")
                   }

               }

            );

        modelBuilder.Entity<Document>()
            .HasData(
            new Document
            {
                Guid = Guid.Parse("8ne0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                LicitationGuid = Guid.Parse("8de0c02b - b7b0 - 4df2 - 9009 - 3df21b91a0bb"),
                documentType = DocumentType.PreparationOfTheBiddingReport,
                ReferenceNumber = "34",
                DateSubmitted = new DateTime(2021, 2, 11),
                DateCertified = new DateTime(2022, 2, 11),
                Template = "Sablon dokumenta"

            }
          );




        */


        modelBuilder.Entity<Entities.Licitation>(entity =>
        {
            entity.HasKey(e => e.Guid);
            entity.Property(e => e.Stage).IsRequired();
            entity.Property(e => e.Date).IsRequired();
            entity.Property(e => e.Year).IsRequired();
            entity.Property(e => e.Constarint).IsRequired();
            entity.Property(e => e.BidIncrement).IsRequired();
            entity.Property(e => e.ApplicationDeadline).IsRequired();
        });

        modelBuilder.Entity<LicitationLand>(entity =>
        {
            entity.HasKey(e => new { e.LandGuid, e.LicitationGuid });
        });

        modelBuilder.Entity<PublicBidding>(entity =>
        {
            entity.HasKey(e => new { e.PublicBiddingGuid, e.LicitationGuid });
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Guid);
        });

        modelBuilder.Entity<LicitationLand>().HasOne(ll => ll.licitation)
        .WithMany(l => l.LicitationLands)
        .HasForeignKey(ll => ll.LicitationGuid);

        modelBuilder.Entity<PublicBidding>().HasOne(pb => pb.licitation)
        .WithMany(l => l.PublicBiddings)
        .HasForeignKey(pb => pb.LicitationGuid);

        modelBuilder.Entity<Document>().HasOne(d => d.licitation)
        .WithMany(l => l.Documents)
        .HasForeignKey(d => d.LicitationGuid);

        /*modelBuilder.Entity<LicitationPublicBidding>().HasOne(pb => pb.licitation)
         .WithMany(l => l.PublicBiddings)
         .HasForeignKey(pb => pb.LicitationGuid);*/

        modelBuilder.Entity<LicitationLand>(entity =>
        {
            entity.HasKey(e => new { e.LandGuid, e.LicitationGuid });
        });

        modelBuilder.Entity<PublicBidding>(entity =>
        {
            entity.HasKey(e => new { e.PublicBiddingGuid, e.LicitationGuid });
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Guid);
        });

        modelBuilder.Entity<Document>()
        .HasIndex(u => u.ReferenceNumber)
        .IsUnique();

        /*modelBuilder.Entity<LicitationPublicBidding>().HasOne(pb => pb.licitation)
        .WithMany(l => l.PublicBiddings)
        .HasForeignKey(pb => pb.LicitationGuid);*/

        /*modelBuilder.Entity<LicitationLand>().HasOne(ll => ll.licitation)
        .WithMany(l => l.LicitationLands)
        .HasForeignKey(ll => ll.LicitationGuid);*/


    }

}
