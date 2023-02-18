using Complaint.API.Enums;
using Microsoft.EntityFrameworkCore;

namespace Complaint.API.Data;

/// <summary>
/// Db context for Complaints
/// </summary>
public class ComplaintDbContext : DbContext
{
    /// <summary>
    /// Constructor for ComplaintDbContext
    /// </summary>
    /// <param name="options"> DbContextOptions for ComplaintDbContext</param>
    public ComplaintDbContext(DbContextOptions<ComplaintDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// DbSet for Complaints
    /// </summary>
    public DbSet<Entities.Complaint> Complaints { get; set; } = default!;

    /// <summary>
    /// OnModelCreating override
    /// </summary>
    /// <param name="modelBuilder"> ModelBuilder for ComplaintDbContext</param>
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
