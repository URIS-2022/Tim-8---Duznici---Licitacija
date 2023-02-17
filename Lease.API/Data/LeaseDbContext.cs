using Lease.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Lease.API.Data;

public class LeaseDbContext : DbContext

{
    public LeaseDbContext(DbContextOptions<LeaseDbContext> options)
    : base(options)
    { }

    public DbSet<LeaseAgreement> LeaseAgreements { get; set; }
    public DbSet<Buyer> Buyers { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<DueDate> DueDates { get; set; }

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
            .WithOne(b=> b.LeaseAgreement)
            .HasPrincipalKey<LeaseAgreement>(x => x.PersonGuid)
            .HasForeignKey<Buyer>(x => x.PersonGuid)
            .IsRequired();

        modelBuilder.Entity<Buyer>().Property(b => b.Priorities).HasConversion(typeof(PriorityTypeListJsonConverter));

    }

}
