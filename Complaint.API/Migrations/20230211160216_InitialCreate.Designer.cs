﻿// <auto-generated />
using System;
using Complaint.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Complaint.API.Migrations
{
    [DbContext(typeof(ComplaintDbContext))]
    [Migration("20230211160216_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Complaint.API.Entities.Complaint", b =>
                {
                    b.Property<Guid>("Guid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Action")
                        .HasColumnType("int");

                    b.Property<Guid>("BuyerGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("DateSubmitted")
                        .HasColumnType("datetime2");

                    b.Property<string>("Rationale")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Reason")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ResolutionCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ResolutionDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("SubjectGuid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Guid");

                    b.ToTable("Complaints");

                    b.HasData(
                        new
                        {
                            Guid = new Guid("1d2d5ce3-596e-4246-9f92-d5a8814c4fdb"),
                            Action = 1,
                            BuyerGuid = new Guid("63abde59-1ea0-455f-91ab-d179029a1e39"),
                            DateSubmitted = new DateTime(2023, 2, 11, 0, 0, 0, 0, DateTimeKind.Local),
                            Rationale = "Ono je test podatak",
                            Reason = "Nema razloga",
                            ResolutionCode = "F86S8OLFD",
                            ResolutionDate = new DateTime(2023, 2, 12, 0, 0, 0, 0, DateTimeKind.Local),
                            Status = 0,
                            SubjectGuid = new Guid("eda5afb2-a4d1-4d19-b6d5-a988d32513d2"),
                            Type = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
