using Landlot.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Landlot.API.Data
{
    public class LandlotDbContext : DbContext
    {
        private readonly IConfiguration configuration;

        public LandlotDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.configuration = configuration;
        }

        public DbSet<Land> Lands { get; set; }
        public DbSet<Lot> Lots { get; set; }

        /// <summary>
        /// Popunjavanje baze sa nekim test podacima
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Land>()
                .HasKey(l => l.LandGuid);

            modelBuilder.Entity<Lot>()
                .HasKey(l => l.LotGuid);

            modelBuilder.Entity<Land>()
                .HasMany(p => p.Lots)
                .WithOne(a => a.Land)
                .HasForeignKey(p => p.LandGuid);

            modelBuilder.Entity<Land>()
                .HasData(new
                {
                    LandGuid = Guid.Parse("3f84c3a3-34c2-48a0-93a1-f00af6c9b2ba"),
                    TotalArea = 300,
                    Municipality = "Bajmok",
                    RealEstateNumber = "22",
                    Culture = "Vrtovi",
                    Zone = "3",
                    Drainage = "Odvodnjavanje",
                    LandClass = "III",
                    Processing = "Ostalo",
                    Property = "Drugi oblici"
                });

            modelBuilder.Entity<Land>()
                .HasData(new
                {
                    LandGuid = Guid.Parse("1f14c3a3-34c2-48a0-03a1-f00af6c9b2bb"),
                    TotalArea = 111.25,
                    Municipality = "Bikovo",
                    RealEstateNumber = "1234",
                    Culture = "Livade",
                    Zone = "4",
                    Drainage = "Odvodnjavanje",
                    LandClass = "I",
                    Processing = "Ostalo",
                    Property = "Privatna svojina"
                });

            modelBuilder.Entity<Lot>()
                .HasData(new
                {
                    LotGuid = Guid.Parse("67e0bcc7-db55-4726-8b3d-ee0dabed6de3"),
                    LandGuid = Guid.Parse("3f84c3a3-34c2-48a0-93a1-f00af6c9b2ba"),
                    LotArea = 1234,
                    LotUser = Guid.Parse("3f84c3a3-34c2-48a0-93a1-f00af6c9b2bc"),
                    LotNumber = 1,
                    CultureState = "Vrtovi",
                    ClassState = "II",
                    ProcessingState = "Ostalo",
                    ProtectedZoneState = "1",
                    DrainageState = "Odvodnjavanje"
                });

            modelBuilder.Entity<Lot>()
                .HasData(new
                {
                    LotGuid = Guid.Parse("61e0bcc1-db15-4726-8b3d-ee0dabed6de3"),
                    LandGuid = Guid.Parse("1f14c3a3-34c2-48a0-03a1-f00af6c9b2bb"),
                    LotArea = 4321.56,
                    LotUser = Guid.Parse("1f14c3a3-34c2-48a0-03a1-f00af6c9b2bb"),
                    LotNumber = 13,
                    CultureState = "Njive",
                    LandClassState = "III",
                    ProcessingState = "Obradivo",
                    ProtectedZoneState = "4",
                    DrainageState = "Odvodnjavanje"
                });
        }
    }
}