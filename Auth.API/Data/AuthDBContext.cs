using Auth.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Data;

public class AuthDbContext : DbContext
{
    public AuthDbContext(DbContextOptions<AuthDbContext> options)
    : base(options)
    { }

    public DbSet<SystemUser> SystemUser { get; set; }

}
