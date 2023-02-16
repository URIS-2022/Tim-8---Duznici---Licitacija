using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Person.API.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Data
{
    public class PersonDbContext : DbContext
    {


        private readonly IConfiguration Configuration;

        public PersonDbContext(DbContextOptions options, IConfiguration configuration) : base(options)
        {
            this.Configuration = configuration;
        }


        public DbSet<PhysicalPerson> PhysicalPersons { get; set; }

        public DbSet<Address> Addresses { get; set; }

        public DbSet<LegalPerson> LegalPersons { get; set; }

        public DbSet<ContactPerson> ContactPersons { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PhysicalPerson>()
               .HasKey(p => p.PhysicalPersonId);

            modelBuilder.Entity<PhysicalPerson>()
                .HasData(
                    new PhysicalPerson
                    {

                        PhysicalPersonId = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                        FirstName ="Luka",
                        LastName="Lukic",
                        Jmbg="1234567876543",
                        AddressId=Guid.Parse("8de0c01b-b7b0-4df2-9000-3df21b91a0bb"),
                        PhoneNumber1="0652632633",
                        PhoneNumber2="0622402001",
                        Email="luka123@gmail.com",
                        AccountNumber="1234567"

                    }
            );

            modelBuilder.Entity<LegalPerson>()
             .HasKey(lp => lp.LegalPersonId);


            modelBuilder.Entity<LegalPerson>()
               .HasOne(lp => lp.ContactPerson)
               .WithMany()
               .HasForeignKey(lp => lp.ContactPersonId);


            modelBuilder.Entity<LegalPerson>()
                .HasData(
                    new LegalPerson
                    {
                        LegalPersonId = Guid.Parse("8de0c01b-b7b0-4df2-9009-3df21b91a0bb"),
                        ContactPersonId = Guid.Parse("a43a31f7-ffad-4aff-a199-1a6d31a8b850"),
                        Name = "Vaskons",
                        IdentificationNumber = "16050",
                        AddressId = Guid.Parse("8de0c01b-b7b0-4df2-9234-3df21b91a0bb"),
                        PhoneNumber1 = "0613263358",
                        PhoneNumber2 = "0603377409",
                        Fax = "1110222",
                        Email = "vaskons@yahoo.com",
                        AccountNumber = "7654321"

                    }
            );

            modelBuilder.Entity<ContactPerson>()
              .HasKey(p => p.ContactPersonId);


            modelBuilder.Entity<ContactPerson>()
                .HasData(
                    new ContactPerson
                    {
                        ContactPersonId = Guid.Parse("a43a31f7-ffad-4aff-a199-1a6d31a8b850"),
                        FirstName = "Petar",
                        LastName = "Milanovic",
                        Function = "Generalni direktor",
                        PhoneNumber = "0639444271"
                    }
            );


            modelBuilder.Entity<Address>()
              .HasKey(a => a.AddressId);


            modelBuilder.Entity<Address>()
                .HasData(
                    new Address
                {
                        AddressId = Guid.Parse("9a8e31d5-5e7b-46e7-80c6-f22e607ee907"),
                        Country = "Srbija",
                        Street = "Njegoseva",
                        StreetNumber = "21",
                        Place = "Beograd",
                        ZipCode = "11000"
                });
        }
    }
}






