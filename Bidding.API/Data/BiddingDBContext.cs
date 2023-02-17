using Microsoft.EntityFrameworkCore;
using Bidding.API.Entities;
using Bidding.API.Enums;

namespace Bidding.API.Data
{
    public class BiddingDBContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public BiddingDBContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }

        public DbSet<Address> Adresses { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<BiddingOffer> BiddingOffers { get; set; }
        public DbSet<BuyerApplication> BuyerApplications { get; set; }
        
        public DbSet<PublicBidding> PublicBiddings { get; set; }
        public DbSet<PublicBiddingLot> PublicBiddingLots { get; set; }
        public DbSet<Representative> Representatives { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);


            modelBuilder.Entity<Address>()
                .HasData(
                   new Address
                   {
                       Guid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                       Country = "Srbija",
                       Street = "Nikole Tesle",
                       StreetNumber = "23",
                       Place = "Subotica",
                       ZipCode = "11000"


                   }

                );

            modelBuilder.Entity<Document>()
                .HasData(
                new Document
                {
                    Guid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                    PublicBiddingGuid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                    documentType =DocumentType.Report ,
                    ReferenceNumber = "34",
                    DateSubmited = new DateTime(2021, 2, 11),
                    DateSertified = new DateTime(2022, 2, 11),
                    Template ="Sablon dokumenta"

                }
              );

            modelBuilder.Entity<BiddingOffer>()
                .HasData(
                new BiddingOffer
                {
                    Guid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                    RepresentativeGuid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                    PublicBiddingGuid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                    Date = new DateTime(2021, 2, 11),
                    Offer = 50000.0f,
                    BuyerGuid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb")
                }


               );

            modelBuilder.Entity<BuyerApplication>()
                .HasData(
                  new BuyerApplication
                  {
                      Guid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                      RepresentativeGuid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                      Amount = 60000 
                  }


                );

            

            modelBuilder.Entity<PublicBidding>()
                .HasData(
                  new PublicBidding
                  {
                      Guid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                      Date = new DateTime(2021, 2, 11),
                      StartDate = new DateTime(2021, 2, 11),
                      EndDate = new DateTime(2021, 5, 11),
                      StartPricePerHectar = 50000,
                      Expected = "Zaboravio",
                      municipality = Municipality.NoviGrad,
                      AuctionedPrice = 70000,
                      BestBuyerGuid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                      public_bidding_type = PublicBiddingType.PublicLicitation,
                      AddresGuid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                      LeasePeriod = 5,
                      DepositReplenishmentAmount = 1000,
                      Round = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                      biddingStatus = BiddingStatus.FirstRound
                  }



                );

            modelBuilder.Entity<PublicBiddingLot>()
                .HasData(
                  new PublicBiddingLot
                  {
                      Guid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                      LotGuid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                      PublicBiddingGuid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                      LotNumber = 5

                  }


                );

            modelBuilder.Entity<Representative>()
                .HasData(
                  new Representative
                  {
                      Guid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                      FirstName = "Mladen",
                      LastName = "Krsmanovic",
                      IdentificationNumber = "0802000180857",
                      AddressGuid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                      NumberOfBoard = 1,
                      PublicBiddingGuid = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb")
                  }

                );

            modelBuilder.Entity<Address>()
            .HasKey(u => u.Guid);

            modelBuilder.Entity<Address>()
            .HasMany(r => r.Representatives)
            .WithOne(a => a.address)
            .HasForeignKey(a => a.AddressGuid);




            modelBuilder.Entity<Document>()
            .HasIndex(u => u.ReferenceNumber)
            .IsUnique();

            modelBuilder.Entity<Document>()
           .HasOne(d => d.PublicBidding)
           .WithMany(pb => pb.Documents)
           .HasForeignKey(d => d.PublicBiddingGuid);

            modelBuilder.Entity<Document>()
            .HasKey(u => u.Guid);

            modelBuilder.Entity<BiddingOffer>()
            .HasKey(u => u.Guid);

            modelBuilder.Entity<BuyerApplication>()
            .HasKey(u => new { u.Guid, u.RepresentativeGuid });

            modelBuilder.Entity<BuyerApplication>()
           .HasOne(b => b.representative)
           .WithMany(r => r.BuyerApplications)
           .HasForeignKey(b => b.RepresentativeGuid);

            modelBuilder.Entity<PublicBidding>()
              .HasKey(u => u.Guid);
            

            modelBuilder.Entity<PublicBidding>()
            .HasMany(p => p.Representatives)
            .WithOne(r => r.publicBidding)
            .HasForeignKey(r => r.PublicBiddingGuid);
           

            modelBuilder.Entity<PublicBidding>()
            .HasOne(p => p.Address)
            .WithMany(a => a.PublicBiddings)
            .HasForeignKey(p => p.AddresGuid);

            modelBuilder.Entity<PublicBidding>()
           .HasMany(p => p.BiddingOffers)
           .WithOne(b => b.publicBidding)
           .HasForeignKey(b => b.PublicBiddingGuid);

            modelBuilder.Entity<PublicBiddingLot>()
            .HasKey(u => u.Guid);

            modelBuilder.Entity<PublicBiddingLot>()
           .HasOne(pl => pl.PublicBidding)
           .WithMany(pb => pb.PublicBiddingLots)
           .HasForeignKey(pl => pl.PublicBiddingGuid);

            modelBuilder.Entity<Representative>()
            .HasIndex(u => u.IdentificationNumber)
            .IsUnique();

            modelBuilder.Entity<Representative>()
            .HasKey(u => u.Guid);
         
            modelBuilder.Entity<Representative>()
           .HasMany(r => r.BiddingOffers)
          .WithOne(bo => bo.Representative)
          .HasForeignKey(bo => bo.RepresentativeGuid);


        }
    }
}
