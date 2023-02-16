using Microsoft.EntityFrameworkCore;
using Preparation.API.Entities;
using Preparation.API.Enums;

namespace Preparation.API.Data
{
    /// <summary>
    /// DbContext za rad sa bazom podataka.
    /// </summary>
    public class PreparationDbContext : DbContext
    {
        private readonly IConfiguration configuration;
        public PreparationDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Document> Documents { get; set; }

        /// <summary>
        /// Metoda za definisanje strukture baze i njenih relacija.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Announcement>()
                .HasKey(u => u.Guid);

            modelBuilder.Entity<Document>()
                .HasIndex(u => u.ReferenceNumber)
                .IsUnique();

            modelBuilder.Entity<Document>()
                .HasKey(u => u.Guid);

            modelBuilder.Entity<Announcement>()
                .HasMany(p => p.Documents)
                .WithOne(a => a.Announcement)
                .HasForeignKey(p => p.AnnouncementGuid); // Add foreign key

            modelBuilder.Entity<Document>()
                .HasData(new 
                {
                    Guid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                    AnnouncementGuid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                    DocumentType = DocumentType.Determining,
                    DocumentStatus = DocumentStatus.Approved,
                    ReferenceNumber = "34432564789541231211",
                    DateSubmitted = new DateTime(2021, 2, 11),
                    DateCertified = new DateTime(2022, 2, 11),
                    Template = "Sablon dokumenta"

                }
              );

            modelBuilder.Entity<Document>()
                .HasData(new
                {
                    Guid = Guid.Parse("8de0c01b-b4b0-4df2-9009-3df21b91a0bb"),
                    AnnouncementGuid = Guid.Parse("8da0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                    DocumentType = DocumentType.Determining,
                    DocumentStatus = DocumentStatus.Approved,
                    ReferenceNumber = "34432564789541299211",
                    DateSubmitted = new DateTime(2021, 3, 11),
                    DateCertified = new DateTime(2022, 3, 11),
                    Template = "Sablon dokumenta"

                }
              );

            modelBuilder.Entity<Announcement>()
                .HasData(new
                {
                    Guid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                    LicitationGuid = Guid.Parse("8de0c01b-b7b0-4df2-1001-3df21b91a0bb")
                }
              );

            modelBuilder.Entity<Announcement>()
                .HasData(new
                {
                    Guid = Guid.Parse("8da0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                    LicitationGuid = Guid.Parse("8de0c01b-b7b0-4df2-2002-3df21b91a0bb")
                }
              );
        }

    }
}
