using Microsoft.EntityFrameworkCore;
using Payment.API.Entities;

namespace Payment.API.Data;

/// <summary>
/// Represents a database context for the Payment application.
/// </summary>
public class PaymentDBContext : DbContext
{
    private readonly IConfiguration Configuration;

    /// <summary>
    /// Initializes a new instance of the PaymentDBContext class.
    /// </summary>
    /// <param name="options">The DbContextOptions to be used by the context.</param>
    /// <param name="configuration">The IConfiguration used to configure the context.</param>
    public PaymentDBContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        this.Configuration = configuration;
    }
    /// <summary>
    /// Gets or sets the Payments table in the database.
    /// </summary>
    public DbSet<Entities.Payment> Payments { get; set; }
    /// <summary>
    /// Gets or sets the PaymentWarrants table in the database.
    /// </summary>
    public DbSet<PaymentWarrant> PaymentWarrants { get; set; }

    /// <inheritdoc />
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<Entities.Payment>()
            .HasData(
               new Entities.Payment
               {
                   Guid = Guid.Parse("56277ee2-3d28-4cde-8e6d-d2397342fc9d"),
                   AccountNumber = "323024329",
                   ReferenceNumber = "PW-1234",
                   TotalAmount = 230,
                   PayerGuid = Guid.Parse("e31726fb-23a4-4f1b-a335-4354a96d052b"),
                   PaymentTitle = "Sample Payment",
                   PaymentDate = new DateTime(2021, 2, 12),
                   PublicBiddingGuid = Guid.Parse("f488b81f-ff6e-4ce1-aea9-050b085b6849")
               }

            );

        modelBuilder.Entity<PaymentWarrant>()
            .HasData(
            new PaymentWarrant
            {
                Guid = Guid.Parse("e1cd0010-b413-4b81-841d-2bc234b34c85"),
                ReferenceNumber = "PW-1234",
                PayerGuid = Guid.Parse("ec856b7c-278d-4877-afc7-83405a3259bb"),
                TotalAmount = 100.50m,
                PublicBiddingGuid = Guid.Parse("af3ad9df-c61c-4229-958f-e2b5f96870d7")

            }
           );
        

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

            entity.HasOne(e => e.PaymentWarrant)
                .WithMany(pw => pw.Payments)
                .HasForeignKey(e => e.ReferenceNumber);
        });

        modelBuilder.Entity<PaymentWarrant>(entity =>
        {
            entity.HasKey(e => e.ReferenceNumber);
            entity.HasAlternateKey(e => e.ReferenceNumber);
            //entity.HasIndex(e => e.ReferenceNumber).IsUnique();
            entity.Property(e => e.ReferenceNumber).IsRequired();
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(18,2)");
        });
    }

}
