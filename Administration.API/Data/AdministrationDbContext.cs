using Administration.API.Entities;
using Administration.API.Enums;
using Microsoft.EntityFrameworkCore;

namespace Administration.API.Data;

/// <summary>
/// AdministrationDbContext is a class that inherits from DbContext. 
/// It represents the database context for the administrationentication system.
/// </summary>
public class AdministrationDbContext : DbContext
{

    /// <summary>
    /// Initializes a new instance of the AdministrationDbContext class.
    /// </summary>
    /// <param name="options">The options to be used by a DbContext.</param>
    public AdministrationDbContext(DbContextOptions<AdministrationDbContext> options)
    : base(options)
    { }

    /// <summary>
    /// A DbSet of SystemUser entities.
    /// </summary>
    public DbSet<CommitteeMember> CommitteeMembers { get; set; }

    public DbSet<Committee> Committees { get; set; }

    public DbSet<Member> Members { get; set; }

    public DbSet<Document> Documents { get; set; }

    /// <summary>
    /// Overrides OnModelCreating method to configure the model creating process.
    /// </summary>
    /// <param name="modelBuilder">The ModelBuilder instance to be used for model creating.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CommitteeMember>()
        .HasKey(cm => new { cm.CommitteeGuid, cm.MemberGuid });

        modelBuilder.Entity<CommitteeMember>()
            .HasOne(cm => cm.Committee)
            .WithMany(c => c.CommitteeMembers)
            .HasForeignKey(cm => cm.CommitteeGuid);

        modelBuilder.Entity<CommitteeMember>()
            .HasOne(cm => cm.Member)
            .WithMany(m => m.CommitteeMembers)
            .HasForeignKey(cm => cm.MemberGuid);

        modelBuilder.Entity<Document>()
            .HasOne(d => d.Committee)
            .WithMany(cm => cm.Documents)
            .HasForeignKey(d => d.CommitteeGuid);

        var committee = new Committee(
            guid: Guid.Parse("42afdb31-0568-4a14-92e1-9430d7c819c9"),
            dateAssembled: DateTime.Today);

        var member = new Member(
            guid: Guid.Parse("9eab25c2-0a43-47d7-bf7b-912871e76df6"),
            firstName: "Mike", lastName: "Joa");

        var document = new Document(
            guid: Guid.Parse("73d71612-5714-4ef1-b01b-96ce427307e9"),
            type: DocumentType.CommitteePlan,
            committeeGuid: Guid.Parse("42afdb31-0568-4a14-92e1-9430d7c819c9"),
            dateSubbmitted: DateTime.Today,
            dateCertified: DateTime.Now,
            template: "Usal document",
            referenceNumber: "AD898DSA89S79");

        modelBuilder.Entity<Committee>().HasData(committee);

        modelBuilder.Entity<Document>().HasData(document);

        modelBuilder.Entity<Member>().HasData(member);

        modelBuilder.Entity<CommitteeMember>().HasData(new CommitteeMember(committeeGuid: committee.Guid, memberGuid: member.Guid, role: "Member"));
    }
}
