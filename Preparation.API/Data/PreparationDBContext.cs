using Microsoft.EntityFrameworkCore;
using Preparation.API.Entities;

namespace Preparation.API.Data
{
    public class PreparationDBContext : DbContext
    {
        public PreparationDBContext(DbContextOptions<PreparationDBContext> options)
        : base(options)
        { }

        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Document> Documents { get; set; }

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
        }

    }
}
