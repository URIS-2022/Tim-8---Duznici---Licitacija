using Complaint.API.Enums;
using Microsoft.EntityFrameworkCore;

namespace Complaint.API.Data;

public class ComplaintDbContext : DbContext
{
    public ComplaintDbContext(DbContextOptions<ComplaintDbContext> options)
        : base(options)
    {
    }

    public DbSet<Entities.Complaint> Complaints { get; set; } = default!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Entities.Complaint>().HasData(
            new Entities.Complaint(
                type: ComplaintType.LeaseComplaint, dateSubmitted: DateTime.Today,
                buyerGuid: Guid.NewGuid(), "Nema razloga", "Ono je test podatak",
                resolutionDate: DateTime.Today.AddDays(1), "F86S8OLFD", status: ComplaintStatus.Opened,
                subjectGuid: Guid.NewGuid(), action: ComplaintAction.SecondRoundSameConditions)
        );
        base.OnModelCreating(modelBuilder);
    }
}
