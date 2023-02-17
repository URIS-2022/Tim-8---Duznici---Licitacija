﻿// <auto-generated />
using System;
using Administration.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Administration.API.Migrations;

[DbContext(typeof(AdministrationDbContext))]
partial class AdministrationDbContextModelSnapshot : ModelSnapshot
{
    protected override void BuildModel(ModelBuilder modelBuilder)
    {
#pragma warning disable 612, 618
        modelBuilder
            .HasAnnotation("ProductVersion", "7.0.3")
            .HasAnnotation("Relational:MaxIdentifierLength", 128);

        SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

        modelBuilder.Entity("Administration.API.Entities.Committee", b =>
            {
                b.Property<Guid>("Guid")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("DateAssembled")
                    .HasColumnType("datetime2");

                b.HasKey("Guid");

                b.ToTable("Committees");

                b.HasData(
                    new
                    {
                        Guid = new Guid("42afdb31-0568-4a14-92e1-9430d7c819c9"),
                        DateAssembled = new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Local)
                    });
            });

        modelBuilder.Entity("Administration.API.Entities.CommitteeMember", b =>
            {
                b.Property<Guid>("CommitteeGuid")
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid>("MemberGuid")
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("Role")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("CommitteeGuid", "MemberGuid");

                b.HasIndex("MemberGuid");

                b.ToTable("CommitteeMembers");

                b.HasData(
                    new
                    {
                        CommitteeGuid = new Guid("42afdb31-0568-4a14-92e1-9430d7c819c9"),
                        MemberGuid = new Guid("9eab25c2-0a43-47d7-bf7b-912871e76df6"),
                        Role = "Member"
                    });
            });

        modelBuilder.Entity("Administration.API.Entities.Document", b =>
            {
                b.Property<Guid>("Guid")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<Guid>("CommitteeGuid")
                    .HasColumnType("uniqueidentifier");

                b.Property<DateTime>("DateCertified")
                    .HasColumnType("datetime2");

                b.Property<DateTime>("DateSubbmitted")
                    .HasColumnType("datetime2");

                b.Property<string>("ReferenceNumber")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Template")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<int>("Type")
                    .HasColumnType("int");

                b.HasKey("Guid");

                b.HasIndex("CommitteeGuid");

                b.ToTable("Documents");

                b.HasData(
                    new
                    {
                        Guid = new Guid("73d71612-5714-4ef1-b01b-96ce427307e9"),
                        CommitteeGuid = new Guid("42afdb31-0568-4a14-92e1-9430d7c819c9"),
                        DateCertified = new DateTime(2023, 2, 16, 18, 47, 57, 392, DateTimeKind.Local).AddTicks(837),
                        DateSubbmitted = new DateTime(2023, 2, 16, 0, 0, 0, 0, DateTimeKind.Local),
                        ReferenceNumber = "AD898DSA89S79",
                        Template = "Usal document",
                        Type = 0
                    });
            });

        modelBuilder.Entity("Administration.API.Entities.Member", b =>
            {
                b.Property<Guid>("Guid")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("uniqueidentifier");

                b.Property<string>("FirstName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("LastName")
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                b.HasKey("Guid");

                b.ToTable("Members");

                b.HasData(
                    new
                    {
                        Guid = new Guid("9eab25c2-0a43-47d7-bf7b-912871e76df6"),
                        FirstName = "Mike",
                        LastName = "Joa"
                    });
            });

        modelBuilder.Entity("Administration.API.Entities.CommitteeMember", b =>
            {
                b.HasOne("Administration.API.Entities.Committee", "Committee")
                    .WithMany("CommitteeMembers")
                    .HasForeignKey("CommitteeGuid")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("Administration.API.Entities.Member", "Member")
                    .WithMany("CommitteeMembers")
                    .HasForeignKey("MemberGuid")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Committee");

                b.Navigation("Member");
            });

        modelBuilder.Entity("Administration.API.Entities.Document", b =>
            {
                b.HasOne("Administration.API.Entities.Committee", "Committee")
                    .WithMany("Documents")
                    .HasForeignKey("CommitteeGuid")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.Navigation("Committee");
            });

        modelBuilder.Entity("Administration.API.Entities.Committee", b =>
            {
                b.Navigation("CommitteeMembers");

                b.Navigation("Documents");
            });

        modelBuilder.Entity("Administration.API.Entities.Member", b =>
            {
                b.Navigation("CommitteeMembers");
            });
#pragma warning restore 612, 618
    }
}
