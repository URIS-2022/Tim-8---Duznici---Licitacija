using Licitation.API.Entities;
using Licitation.API.Enums;
using System.Reflection.Emit;
namespace Licitation.API.Data;

public class LicitationDBContext : DbContext
{
    public LicitationDBContext(DbContextOptions<LicitationDBContext> options)
    : base(options)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Licitation>(entity =>
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
            entity.HasKey(e => new { e.Licitation, e.LandGuid });
            entity.HasOne(e => e.Licitation)
                  .WithMany(e => e.LicitationLands)
                  .HasForeignKey(e => e.Licitation)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<LicitationPublicBidding>(entity =>
        {
            entity.HasKey(e => new { e.PublicBiddingGuid, e.Licitation });
            entity.HasOne(e => e.Licitation)
                  .WithMany(e => e.LicitationPublicBiddings)
                  .HasForeignKey(e => e.Licitation)
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Guid);
            entity.HasOne(e => e.Licitation)
                  .WithMany(e => e.Documents)
                  .HasForeignKey(e => e.Licitation);
            entity.Property(e => e.ReferenceNumber).IsRequired();
            entity.Property(e => e.DateSubmitted).IsRequired();
            entity.Property(e => e.DateCertified).IsRequired();
            entity.Property(e => e.Template).IsRequired();
        });

        modelBuilder.Entity<DocumentType>(entity =>
        {
            entity.HasKey(e => e.Id);
        });
    }

}
