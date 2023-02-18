using Lease.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lease.API.Data;

/// <summary>
/// Database context for the lease API.
/// </summary>
public class LeaseDbContext : DbContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LeaseDbContext"/> class.
    /// </summary>
    /// <param name="options"> The options to be used by a <see cref="DbContext"/>. </param>
    public LeaseDbContext(DbContextOptions<LeaseDbContext> options)
    : base(options)
    { }

    /// <summary>
    /// Gets or sets the lease agreements.
    /// </summary>
    public DbSet<LeaseAgreement> LeaseAgreements { get; set; }

    /// <summary>
    /// Gets or sets the buyers.
    /// </summary>
    public DbSet<Buyer> Buyers { get; set; }

    /// <summary>
    /// Gets or sets the documents.
    /// </summary>
    public DbSet<Document> Documents { get; set; }
    /// <summary>
    /// Gets or sets the due dates.
    /// </summary>
    public DbSet<DueDate> DueDates { get; set; }

    /// <summary>
    /// Configures the model that was discovered by convention from the entity types exposed in <see cref="DbSet{TEntity}"/> properties on your derived context.
    /// </summary>
    /// <param name="modelBuilder"></param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

        modelBuilder.Entity<LeaseAgreement>()
            .HasKey(u => u.Guid);

        modelBuilder.Entity<LeaseAgreement>()
               .HasIndex(u => u.ReferenceNumber)
               .IsUnique();

        modelBuilder.Entity<LeaseAgreement>()
            .HasKey(u => u.Guid);

        modelBuilder.Entity<Buyer>()
            .HasKey(u => u.Guid);
        modelBuilder.Entity<Buyer>()
               .HasIndex(u => u.PersonGuid).IsUnique(false);

        modelBuilder.Entity<Document>()
              .HasIndex(u => u.ReferenceNumber)
              .IsUnique();

        modelBuilder.Entity<Document>()
            .HasKey(u => u.Guid);

        modelBuilder.Entity<DueDate>()
          .HasKey(u => u.Guid);

        modelBuilder.Entity<DueDate>()
              .HasMany(dd => dd.LeaseAgreements)
              .WithOne(la => la.DueDate)
              .HasForeignKey(la => la.DueDateGuid);

        modelBuilder.Entity<LeaseAgreement>()
                .HasMany(x => x.Documents)
                .WithOne(x => x.LeaseAgreement)
                .HasForeignKey(x => x.LeaseAgreementGuid)
                .IsRequired();

        modelBuilder.Entity<LeaseAgreement>()
            .HasOne(x => x.Buyer)
            .WithOne(b => b.LeaseAgreement)
            .HasPrincipalKey<LeaseAgreement>(x => x.PersonGuid)
            .HasForeignKey<Buyer>(x => x.PersonGuid)
            .IsRequired();

        modelBuilder.Entity<Buyer>().Property(b => b.Priorities).HasConversion(new PriorityTypeListValueConverter());
    }
}
