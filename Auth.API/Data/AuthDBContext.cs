using Auth.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Data;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
    : base(options)
    { }

    public DbSet<SystemUser> SystemUsers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<SystemUser>()
            .HasIndex(u => u.Username)
            .IsUnique();

        modelBuilder.Entity<SystemUser>()
            .HasKey(u => u.Guid);
    }
}
