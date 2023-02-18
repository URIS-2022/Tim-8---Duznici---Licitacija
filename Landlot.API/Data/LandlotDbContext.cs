using Landlot.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Landlot.API.Data
{
    /// <summary>
    /// Represents the database context for managing landlot entities.
    /// </summary>
    public class LandlotDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LandlotDbContext"/> class using the specified options.
        /// </summary>
        /// <param name="options">The options for configuring this database context.</param>
        public LandlotDbContext(DbContextOptions<LandlotDbContext> options)
        : base(options)
        { }

        /// <summary>
        /// Gets or sets the DbSet of lands in the database.
        /// </summary>
        /// <remarks>
        /// This DbSet is used to interact with the "Lands" table in the database.
        /// </remarks>
        public DbSet<Land> Lands { get; set; }

        /// <summary>
        /// Gets or sets the DbSet of lots in the database.
        /// </summary>
        /// <remarks>
        /// This DbSet is used to interact with the "Lots" table in the database.
        /// </remarks>
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
               .Property(l => l.TotalArea)
                .HasPrecision(18, 2);

            modelBuilder.Entity<Lot>()
              .Property(l => l.LotArea)
               .HasPrecision(18, 2);




            modelBuilder.Entity<Land>()
                .HasData(new
                {
                    LandGuid = Guid.Parse("3f84c3a3-34c2-48a0-93a1-f00af6c9b2ba"),
                    TotalArea = 300M,
                    Municipality = Enums.LandlotMunicipality.Bajmok,
                    RealEstateNumber = "22",
                    Culture = Enums.LandlotCulture.Vrtovi,
                    Zone = Enums.LandlotProtectedZone.Zone3,
                    Drainage = Enums.LandlotDrainage.Odvodnjavanje,
                    LandClass = Enums.LandlotClass.III,
                    Processing = Enums.LandlotProcessing.Ostalo,
                    Property = Enums.LandlotPropertyType.DrzavnaSvojinaRS
                }
                );

            modelBuilder.Entity<Land>()
                .HasData(new
                {
                    LandGuid = Guid.Parse("1f14c3a3-34c2-48a0-03a1-f00af6c9b2bb"),
                    TotalArea = 1111M,
                    Municipality = Enums.LandlotMunicipality.Bikovo,
                    RealEstateNumber = "1234",
                    Culture = Enums.LandlotCulture.Livade,
                    Zone = Enums.LandlotProtectedZone.Zone4,
                    Drainage = Enums.LandlotDrainage.Odvodnjavanje,
                    LandClass = Enums.LandlotClass.I,
                    Processing = Enums.LandlotProcessing.Ostalo,
                    Property = Enums.LandlotPropertyType.PrivatnaSvojina
                });

            modelBuilder.Entity<Lot>()
                .HasData(new
                {
                    LotGuid = Guid.Parse("67e0bcc7-db55-4726-8b3d-ee0dabed6de3"),
                    LandGuid = Guid.Parse("3f84c3a3-34c2-48a0-93a1-f00af6c9b2ba"),
                    LotArea = 1234.56M,
                    LotUser = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                    LotNumber = 1,
                    CultureState = Enums.LandlotCulture.Vrtovi,
                    ClassState = Enums.LandlotClass.II,
                    ProcessingState = Enums.LandlotProcessing.Ostalo,
                    ProtectedZoneState = Enums.LandlotProtectedZone.Zone1,
                    DrainageState = Enums.LandlotDrainage.Odvodnjavanje
                });

            modelBuilder.Entity<Lot>()
                .HasData(new
                {
                    LotGuid = Guid.Parse("61e0bcc1-db15-4726-8b3d-ee0dabed6de3"),
                    LandGuid = Guid.Parse("1f14c3a3-34c2-48a0-03a1-f00af6c9b2bb"),
                    LotArea = 4321.12M,
                    LotUser = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                    LotNumber = 13,
                    CultureState = Enums.LandlotCulture.Njive,
                    ClassState = Enums.LandlotClass.III,
                    ProcessingState = Enums.LandlotProcessing.Obradivo,
                    ProtectedZoneState = Enums.LandlotProtectedZone.Zone4,
                    DrainageState = Enums.LandlotDrainage.Odvodnjavanje
                });
        }
    }
}