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

            modelBuilder.Entity<Lot>().HasKey(table => new {
                table.LandGuid,
                table.LotGuid
            });


            modelBuilder.Entity<Land>() 
                .HasData(new
                {
                    LandGuid = Guid.Parse("3f84c3a3-34c2-48a0-93a1-f00af6c9b2ba"),
                    TotalArea = 3000,
                    MunicipalityId = Guid.Parse("aa3f2265-7182-4424-ba83-2eed388ce748"),
                    RealEstateNumber = "2",
                    LandCulture = "Field",
                    ProtectedZone = "III",
                    Drainage = "Excellent",
                    Municipality = "Bajmok",
                    LandClass = "1",
                    LandProcessing = "Arable",
                    PropertyType = "Private"
                });


            modelBuilder.Entity<Lot>()
                .HasData(new
                {
                    LotGuid = Guid.Parse("67e0bcc7-db55-4726-8b3d-ee0dabed6de3"),
                    LandGuid = Guid.Parse("3f84c3a3-34c2-48a0-93a1-f00af6c9b2ba"),
                    LotArea = 1234,
                    LotUser = "John Doe",
                    LotNumber = 1,
                    LandCultureState= "Field",
                    LandClassState = "2",
                    LandProcessingState= "Arable",
                    ProtectedZoneState = "II",
                    DrainageState = "Good"
                });


        }
    }
}