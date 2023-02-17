﻿// <auto-generated />
using System;
using Bidding.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Bidding.API.Migrations
{
    [DbContext(typeof(BiddingDBContext))]
    [Migration("20230212182848_UpdateDBContext")]
    partial class UpdateDBContext
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Bidding.API.Entities.Address", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Place")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StreetNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.ToTable("Adresses");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            Country = "Srbija",
                            Place = "Subotica",
                            Street = "Nikole Tesle",
                            StreetNumber = "23",
                            ZipCode = "11000"
                        });
                });

            modelBuilder.Entity("Bidding.API.Entities.BiddingOffer", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BuyerGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<float>("Offer")
                        .HasColumnType("real");

                    b.Property<Guid>("PublicBiddingGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RepresentativeGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Guid");

                    b.HasIndex("PublicBiddingGuid");

                    b.HasIndex("RepresentativeGuid");

                    b.ToTable("BiddingOffers");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            BuyerGuid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            Date = new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Offer = 50000f,
                            PublicBiddingGuid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            RepresentativeGuid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb")
                        });
                });

            modelBuilder.Entity("Bidding.API.Entities.BuyerApplication", b =>
                {
                    b.Property<Guid>("Guid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("RepresentativeGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.HasKey("Guid", "RepresentativeGuid");

                    b.HasIndex("RepresentativeGuid");

                    b.ToTable("BuyerApplications");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            RepresentativeGuid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            Amount = 60000
                        });
                });

            modelBuilder.Entity("Bidding.API.Entities.Document", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateSertified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateSubmited")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("PublicBiddingGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReferenceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Template")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("documentType")
                        .HasColumnType("int");

                    b.HasKey("Guid");

                    b.HasIndex("PublicBiddingGuid");

                    b.HasIndex("ReferenceNumber")
                        .IsUnique();

                    b.ToTable("Documents");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            DateSertified = new DateTime(2022, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DateSubmited = new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            PublicBiddingGuid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            ReferenceNumber = "34",
                            Template = "Sablon dokumenta",
                            documentType = 1
                        });
                });

            modelBuilder.Entity("Bidding.API.Entities.PublicBidding", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddresGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AuctionedPrice")
                        .HasColumnType("int");

                    b.Property<Guid>("BestBuyerGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DepositReplenishmentAmount")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Expected")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LeasePeriod")
                        .HasColumnType("int");

                    b.Property<Guid>("Round")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("StartPricePerHectar")
                        .HasColumnType("int");

                    b.Property<int>("biddingStatus")
                        .HasColumnType("int");

                    b.Property<int>("municipality")
                        .HasColumnType("int");

                    b.Property<int>("public_bidding_type")
                        .HasColumnType("int");

                    b.HasKey("Guid");

                    b.HasIndex("AddresGuid");

                    b.ToTable("PublicBiddings");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            AddresGuid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            AuctionedPrice = 70000,
                            BestBuyerGuid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            Date = new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            DepositReplenishmentAmount = 1000,
                            EndDate = new DateTime(2021, 5, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Expected = "Zaboravio",
                            LeasePeriod = 5,
                            Round = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            StartDate = new DateTime(2021, 2, 11, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            StartPricePerHectar = 50000,
                            biddingStatus = 1,
                            municipality = 10,
                            publicbiddingtype = 1
                        });
                });

            modelBuilder.Entity("Bidding.API.Entities.PublicBiddingLot", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LotGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LotNumber")
                        .HasColumnType("int");

                    b.Property<Guid>("PublicBiddingGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Guid");

                    b.HasIndex("PublicBiddingGuid");

                    b.ToTable("PublicBiddingLots");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            LotGuid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            LotNumber = 5,
                            PublicBiddingGuid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb")
                        });
                });

            modelBuilder.Entity("Bidding.API.Entities.Representative", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AddressGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("IdentificationNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("NumberOfBoard")
                        .HasColumnType("int");

                    b.Property<Guid>("PublicBiddingGuid")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Guid");

                    b.HasIndex("AddressGuid");

                    b.HasIndex("IdentificationNumber")
                        .IsUnique();

                    b.HasIndex("PublicBiddingGuid");

                    b.ToTable("Representatives");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            AddressGuid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                            FirstName = "Mladen",
                            IdentificationNumber = "0802000180857",
                            LastName = "Krsmanovic",
                            NumberOfBoard = 1,
                            PublicBiddingGuid = new Guid("8de0c01b-b7b0-4df2-9009-3df21b91a0bb")
                        });
                });

            modelBuilder.Entity("Bidding.API.Entities.BiddingOffer", b =>
                {
                    b.HasOne("Bidding.API.Entities.PublicBidding", "publicBidding")
                        .WithMany("BiddingOffers")
                        .HasForeignKey("PublicBiddingGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bidding.API.Entities.Representative", "Representative")
                        .WithMany("BiddingOffers")
                        .HasForeignKey("RepresentativeGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Representative");

                    b.Navigation("publicBidding");
                });

            modelBuilder.Entity("Bidding.API.Entities.BuyerApplication", b =>
                {
                    b.HasOne("Bidding.API.Entities.Representative", "representative")
                        .WithMany("buyerApplications")
                        .HasForeignKey("RepresentativeGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("representative");
                });

            modelBuilder.Entity("Bidding.API.Entities.Document", b =>
                {
                    b.HasOne("Bidding.API.Entities.PublicBidding", "PublicBidding")
                        .WithMany("Documents")
                        .HasForeignKey("PublicBiddingGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PublicBidding");
                });

            modelBuilder.Entity("Bidding.API.Entities.PublicBidding", b =>
                {
                    b.HasOne("Bidding.API.Entities.Address", "Address")
                        .WithMany("PublicBiddings")
                        .HasForeignKey("AddresGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Address");
                });

            modelBuilder.Entity("Bidding.API.Entities.PublicBiddingLot", b =>
                {
                    b.HasOne("Bidding.API.Entities.PublicBidding", "PublicBidding")
                        .WithMany("PublicBiddingLots")
                        .HasForeignKey("PublicBiddingGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("PublicBidding");
                });

            modelBuilder.Entity("Bidding.API.Entities.Representative", b =>
                {
                    b.HasOne("Bidding.API.Entities.Address", "address")
                        .WithMany("Representatives")
                        .HasForeignKey("AddressGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Bidding.API.Entities.PublicBidding", "publicBidding")
                        .WithMany("Representatives")
                        .HasForeignKey("PublicBiddingGuid")
                        .OnDelete(DeleteBehavior.NoAction)
                        .IsRequired();

                    b.Navigation("address");

                    b.Navigation("publicBidding");
                });

            modelBuilder.Entity("Bidding.API.Entities.Address", b =>
                {
                    b.Navigation("PublicBiddings");

                    b.Navigation("Representatives");
                });

            modelBuilder.Entity("Bidding.API.Entities.PublicBidding", b =>
                {
                    b.Navigation("BiddingOffers");

                    b.Navigation("Documents");

                    b.Navigation("PublicBiddingLots");

                    b.Navigation("Representatives");
                });

            modelBuilder.Entity("Bidding.API.Entities.Representative", b =>
                {
                    b.Navigation("BiddingOffers");

                    b.Navigation("buyerApplications");
                });
#pragma warning restore 612, 618
        }
    }
}
