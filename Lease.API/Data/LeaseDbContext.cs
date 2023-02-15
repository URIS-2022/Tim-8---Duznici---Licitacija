
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

    public DbSet<PriorityTypeEntity> PriorityTypes { get; set; }
    public DbSet<PriorityBuyer> PriorityBuyers { get; set; }
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
              .HasMany(dd => dd.LeaseAgreements)
              .WithOne(la => la.DueDate)
              .HasForeignKey(la => la.DueDateId);



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

        modelBuilder.Entity<PriorityBuyer>()
                .HasKey(pb => new { pb.BuyerGuid, pb.PriorityTypeId });

        modelBuilder.Entity<PriorityBuyer>()
        .HasOne(pb => pb.Buyer)
        .WithMany(b => b.PriorityBuyers)
        .HasForeignKey(pb => pb.BuyerGuid);

        modelBuilder.Entity<PriorityBuyer>()
            .HasOne(pb => pb.PriorityType)
            .WithMany(pt => pt.PriorityBuyers)
            .HasForeignKey(pb => pb.PriorityTypeId);

        modelBuilder.Entity<Buyer>()
             .HasMany(b => b.PriorityBuyers)
             .WithOne(pb => pb.Buyer)
             .HasForeignKey(pb => pb.BuyerGuid);

        modelBuilder.Entity<PriorityTypeEntity>()
             .HasKey(pt=>pt.Id);

        modelBuilder.Entity<PriorityTypeEntity>()
            .HasMany(pt => pt.PriorityBuyers)
            .WithOne(pb => pb.PriorityType)
            .HasForeignKey(pb => pb.PriorityTypeId);



        //proveri da li mora da se napise many to many



    }

}
