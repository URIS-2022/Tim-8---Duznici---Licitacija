using Microsoft.EntityFrameworkCore;
using Payment.API.Entities;

namespace Payment.API.Data;

public class PaymentDBContext : DbContext
{
    private readonly IConfiguration Configuration;
    public PaymentDBContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        this.Configuration = configuration;
    }

    public DbSet<Entities.Payment> Payments { get; set; }

    public DbSet<PaymentWarrant> PaymentWarrants { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        /*
        modelBuilder.Entity<PaymentEntity>()
            .HasData(
               new PaymentEntity
               {
                   Guid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                   AccountNumber = "323024329",
                   ReferenceNumber = "PW-1234",
                   TotalAmount = 230,
                   PayerGuid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                   PaymentTitle = "Sample Payment",
                   PaymentDate = new DateTime(2021, 2, 12),
                   PublicBiddingGuid = Guid.Parse("88de3s01b-b7b0-4df2-9009-3df21b91a0bb"),
                   PaymentWarrantGuid = Guid.Parse("8de0c09b-b7b0-4df2-9009-3df21b91a0bb")
               }

            );

        modelBuilder.Entity<PaymentWarrant>()
            .HasData(
            new PaymentWarrant
            {
                Guid = Guid.Parse("8de0c09b-b7b0-4df2-9009-3df21b91a0bb"),
                ReferenceNumber = "PW-1234",
                PayerGuid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                TotalAmount = 100.50m,
                PublicBiddingGuid = Guid.Parse("8de0c01b-b7b0-4df2-9069-3df21b91a0bb")

            }
           );
        */

    modelBuilder.Entity<Entities.Payment>(entity =>
        {
            entity.HasKey(e => e.Guid);
            entity.Property(e => e.AccountNumber).IsRequired();
            entity.Property(e => e.ReferenceNumber).IsRequired();
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
            entity.Property(p => p.PayerGuid).IsRequired();
            entity.Property(p => p.PaymentTitle).IsRequired().HasMaxLength(100);
            entity.Property(p => p.PaymentDate).IsRequired();
            entity.Property(p => p.PublicBiddingGuid).IsRequired();

            /*entity.HasOne(p => p.paymentWarrant)
            .WithMany(pw => pw.payments)
            .HasForeignKey(pw => pw.ReferenceNumber);*/
  
            entity.HasOne(e => e.paymentWarrant)
                .WithMany(e => e.payments)
                .HasForeignKey(e => e.ReferenceNumber)
                .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<PaymentWarrant>(entity =>
        {
            entity.HasKey(e => e.ReferenceNumber);
            entity.HasIndex(e => e.ReferenceNumber).IsUnique();
            entity.Property(e => e.ReferenceNumber).IsRequired();
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
        });
    }

}
