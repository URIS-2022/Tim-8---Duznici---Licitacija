
using Lease.API.Entities;
using Lease.API.Enums;
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
             .HasKey(u => u.Id);

        




        modelBuilder.Entity<DueDate>()
              .HasOne(dd => dd.LeaseAgreement)
              .WithOne(la => la.DueDate)
              .HasForeignKey<DueDate>(dd => dd.LeaseAgreementGuid);



        modelBuilder.Entity<LeaseAgreement>()
                .HasMany(x => x.Documents)
                .WithOne(x => x.LeaseAgreement)
                .HasForeignKey(x => x.LeaseAgreementGuid)
                .IsRequired();


        modelBuilder.Entity<LeaseAgreement>()
               .HasOne(x => x.Buyer)
               .WithOne(x => x.LeaseAgreement)
               .HasForeignKey<Buyer>(x => x.PersonGuid)
               .IsRequired();


        modelBuilder.Entity <List<PriorityType>>()
               .HasNoKey();



        //proveri da li mora da se napise many to many



    }

}
