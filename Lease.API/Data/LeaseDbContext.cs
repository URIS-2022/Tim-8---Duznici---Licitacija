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

        /* modelBuilder.Entity<Buyer>()
                .Prope(u => u.PersonGuid).IsUnique(false);

         modelBuilder.Entity<LeaseAgreement>()
               .Property(u => u.PersonGuid).IsUnique(false); */

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




        modelBuilder.Entity<DueDate>().HasData(
              new DueDate
              {
                  Guid = Guid.Parse("b415d4f5-6342-41f3-9935-08db10fc223b"),
                  Date = DateTime.Parse("2023-01-17T15:32:02.236")
              }
          );


        modelBuilder.Entity<Document>().HasData(
    new Document
    {
        Guid = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
        Type = DocumentType.LeaseProposition,
        ReferenceNumber = "lll",
        DateSubbmitted = new DateTime(2023, 2, 17, 15, 35, 11, 651, DateTimeKind.Utc),
        DateCertified = new DateTime(2023, 2, 17, 15, 35, 11, 651, DateTimeKind.Utc),
        Template = "SV obrazac",
        LeaseAgreementGuid = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6")
    });


        modelBuilder.Entity<Buyer>().HasData(
    new Buyer
    {
        Guid = Guid.Parse("600f70cc-2384-4ea7-95fa-9ef269736e3f"),
        RealisedArea = 20,
        Ban = false,
        StartDateOfBan = DateTime.Parse("2023-02-17T15:33:22.979Z"),
        BanDuration = 0,
        BanEndDate = DateTime.Parse("2023-02-17T15:33:22.979Z"),
        BiddingGuid = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
        PersonGuid = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
        Priorities = new List<PriorityType> { PriorityType.Border, PriorityType.Irrigation}
    }
);
        modelBuilder.Entity<LeaseAgreement>().HasData(
        new LeaseAgreement
        {
            Guid = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            GuaranteeType = GuaranteeType.None,
            ReferenceNumber = "string",
            DateRecording = DateTime.Parse("2023-02-18T16:18:11.961Z"),
            MinisterGuid = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            DeadlineLandReturn = DateTime.Parse("2023-02-18T16:18:11.961Z"),
            PlaceOfSigning = "string",
            DateOfSigning = DateTime.Parse("2023-02-18T16:18:11.961Z"),
            PublicBiddingGuid = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            PersonGuid = Guid.Parse("3fa85f64-5717-4562-b3fc-2c963f66afa6"),
            DocumentStatus = DocumentStatus.None,
            DueDateGuid = Guid.Parse("b415d4f5-6342-41f3-9935-08db10fc223b")
        }
        );


        modelBuilder.Entity<Buyer>().Property(b => b.Priorities).HasConversion(new PriorityTypeListValueConverter());

    }

}
