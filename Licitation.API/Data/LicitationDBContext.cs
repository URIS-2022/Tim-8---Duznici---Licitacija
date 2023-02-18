using Licitation.API.Entities;
using Licitation.API.Enums;
using Microsoft.EntityFrameworkCore;

namespace Licitation.API.Data;

/// <summary>
/// Initializes a new instance of the LicitationDBContext class.
/// </summary>
public class LicitationDBContext : DbContext

{
    private readonly IConfiguration Configuration;

    /**
    <summary>Initializes a new instance of the <c>LicitationDBContext</c> class with the specified options and configuration.</summary>
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
        
        modelBuilder.Entity<Entities.Licitation>()
            .HasData(
               new Entities.Licitation
               {
                   Guid = Guid.Parse("e053576b-8397-4173-928e-dec58721d00f"),
                   Stage = 2,
                   Date = new DateTime(2023, 2, 11),
                   Year = 2023,
                   Constarint = 0,
                   BidIncrement = 100,
                   ApplicationDeadline = new DateTime(2023, 2, 11)

               }

            );

        modelBuilder.Entity<Document>()
            .HasData(
            new Document
            {
                Guid = Guid.Parse("3eaae99e-7690-4476-ab92-213bf3a2ea58"),
                LicitationGuid = Guid.Parse("e053576b-8397-4173-928e-dec58721d00f"),
                DocumentType = DocumentType.PreparationOfTheBiddingReport,
                ReferenceNumber = "34",
                DateSubmitted = new DateTime(2021, 2, 11),
                DateCertified = new DateTime(2022, 2, 11),
                Template = "Sablon dokumenta"

            }
          );


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
