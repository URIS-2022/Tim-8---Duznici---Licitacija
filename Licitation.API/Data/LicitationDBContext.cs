using Licitation.API.Entities;
using Licitation.API.Enums;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using System.Reflection.Emit;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections;

namespace Licitation.API.Data;

public class LicitationDBContext : DbContext
{
    private readonly IConfiguration Configuration;
    public LicitationDBContext(DbContextOptions options, IConfiguration configuration) : base(options)
    {
        this.Configuration = configuration;
    }
    public DbSet<Entities.Licitation> LicitationEntities { get; set; }
    public DbSet<Document> Documents { get; set; }
    public DbSet<LicitationLand> LicitationLands { get; set; }
    public DbSet<PublicBidding> LicitationPublicBiddings { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        /*
        modelBuilder.Entity<LicitationEntity>()
            .HasData(
               new LicitationEntity
               {
                   Guid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                   Stage = 2,
                   Date = new DateTime(2023, 2, 11),
                   Year = 2023,
                   Constarint = 0,
                   BidIncrement = 100,
                   ApplicationDeadline = new DateTime(2023, 2, 11),
                   LandGuids = new List<Guid>
                   {
                        Guid.Parse("9de0c01b-b7b0-4df2-9009-3df21b91a0ss"),
                        Guid.Parse("1de0c01b-b7b0-4df2-9009-3df21b91a0cc"),
                        Guid.Parse("2de0c01b-b7b0-4df2-9009-3df21b91a0dd"),
                        Guid.Parse("3de0c01b-b7b0-4df2-9009-3df21b91a0ee")
                   },
                   PublicBiddingGuids = new List<Guid>
                   {
                        Guid.Parse("3de0c01b-b7b0-4df2-9009-3df21b91a0ss"),
                        Guid.Parse("5de0c01b-b7b0-4df2-9009-3df21b91a0cc"),
                        Guid.Parse("2de9c01b-b7b0-4df2-9009-3df21b91a0dd"),
                        Guid.Parse("3de7c01b-b7b0-4df2-9009-3df21b91a0ee")
                   }

               }

            );

        modelBuilder.Entity<Document>()
            .HasData(
            new Document
            {
                Guid = Guid.Parse("8ne0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                LicitationGuid = Guid.Parse("8de0c02b - b7b0 - 4df2 - 9009 - 3df21b91a0bb"),
                documentType = DocumentType.PreparationOfTheBiddingReport,
                ReferenceNumber = "34",
                DateSubmitted = new DateTime(2021, 2, 11),
                DateCertified = new DateTime(2022, 2, 11),
                Template = "Sablon dokumenta"

            }
          );




        */


        modelBuilder.Entity<Entities.Licitation>(entity =>
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
            entity.HasKey(e => new { e.LandGuid, e.LicitationGuid });
        });

        modelBuilder.Entity<PublicBidding>(entity =>
        {
            entity.HasKey(e => new { e.PublicBiddingGuid, e.LicitationGuid });
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Guid);
        });

        modelBuilder.Entity<LicitationLand>().HasOne(ll => ll.licitation)
        .WithMany(l => l.LicitationLands)
        .HasForeignKey(ll => ll.LicitationGuid);

        modelBuilder.Entity<PublicBidding>().HasOne(pb => pb.licitation)
        .WithMany(l => l.PublicBiddings)
        .HasForeignKey(pb => pb.LicitationGuid);

        modelBuilder.Entity<Document>().HasOne(d => d.licitation)
        .WithMany(l => l.Documents)
        .HasForeignKey(d => d.LicitationGuid);

        /*modelBuilder.Entity<LicitationPublicBidding>().HasOne(pb => pb.licitation)
         .WithMany(l => l.PublicBiddings)
         .HasForeignKey(pb => pb.LicitationGuid);*/

        modelBuilder.Entity<LicitationLand>(entity =>
        {
            entity.HasKey(e => new { e.LandGuid, e.LicitationGuid });
        });

        modelBuilder.Entity<PublicBidding>(entity =>
        {
            entity.HasKey(e => new { e.PublicBiddingGuid, e.LicitationGuid });
        });

        modelBuilder.Entity<Document>(entity =>
        {
            entity.HasKey(e => e.Guid);
        });

        modelBuilder.Entity<Document>()
        .HasIndex(u => u.ReferenceNumber)
        .IsUnique();

        /*modelBuilder.Entity<LicitationPublicBidding>().HasOne(pb => pb.licitation)
        .WithMany(l => l.PublicBiddings)
        .HasForeignKey(pb => pb.LicitationGuid);*/

        /*modelBuilder.Entity<LicitationLand>().HasOne(ll => ll.licitation)
        .WithMany(l => l.LicitationLands)
        .HasForeignKey(ll => ll.LicitationGuid);*/


    }

}
