﻿// <auto-generated />
using System;
using Licitation.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Licitation.API.Migrations
{
    [DbContext(typeof(LicitationDBContext))]
    [Migration("20230216120741_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Licitation.API.Entities.Document", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateCertified")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateSubmitted")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<Guid>("LicitationGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("ReferenceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Template")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Guid");

                    b.HasIndex("LicitationGuid");

                    b.HasIndex("ReferenceNumber")
                        .IsUnique();

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Licitation.API.Entities.Licitation", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("ApplicationDeadline")
                        .HasColumnType("datetime2");

                    b.Property<int>("BidIncrement")
                        .HasColumnType("int");

                    b.Property<int>("Constarint")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("Stage")
                        .HasColumnType("int");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Guid");

                    b.ToTable("LicitationEntities");
                });

            modelBuilder.Entity("Licitation.API.Entities.LicitationLand", b =>
                {
                    b.Property<Guid>("LandGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LicitationGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LicitationGuid1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("LandGuid", "LicitationGuid");

                    b.HasIndex("LicitationGuid");

                    b.HasIndex("LicitationGuid1");

                    b.ToTable("LicitationLands");
                });

            modelBuilder.Entity("Licitation.API.Entities.LicitationPublicBidding", b =>
                {
                    b.Property<Guid>("PublicBiddingGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("LicitationGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("LicitationGuid1")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("PublicBiddingGuid", "LicitationGuid");

                    b.HasIndex("LicitationGuid");

                    b.HasIndex("LicitationGuid1");

                    b.ToTable("LicitationPublicBiddings");
                });

            modelBuilder.Entity("Licitation.API.Entities.Document", b =>
                {
                    b.HasOne("Licitation.API.Entities.Licitation", "licitation")
                        .WithMany("Documents")
                        .HasForeignKey("LicitationGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("licitation");
                });

            modelBuilder.Entity("Licitation.API.Entities.LicitationLand", b =>
                {
                    b.HasOne("Licitation.API.Entities.Licitation", "licitation")
                        .WithMany("LicitationLands")
                        .HasForeignKey("LicitationGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Licitation.API.Entities.Licitation", null)
                        .WithMany("Lands")
                        .HasForeignKey("LicitationGuid1");

                    b.Navigation("licitation");
                });

            modelBuilder.Entity("Licitation.API.Entities.LicitationPublicBidding", b =>
                {
                    b.HasOne("Licitation.API.Entities.Licitation", "licitation")
                        .WithMany("PublicBiddings")
                        .HasForeignKey("LicitationGuid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Licitation.API.Entities.Licitation", null)
                        .WithMany("LicitationPublicBiddings")
                        .HasForeignKey("LicitationGuid1");

                    b.Navigation("licitation");
                });

            modelBuilder.Entity("Licitation.API.Entities.Licitation", b =>
                {
                    b.Navigation("Documents");

                    b.Navigation("Lands");

                    b.Navigation("LicitationLands");

                    b.Navigation("LicitationPublicBiddings");

                    b.Navigation("PublicBiddings");
                });
#pragma warning restore 612, 618
        }
    }
}
