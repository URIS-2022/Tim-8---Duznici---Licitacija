﻿using AutoMapper;
using Person.API.Data;
using Person.API.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Data.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly PersonDbContext context;


        public AddressRepository (PersonDbContext context)
        {
            this.context = context;

        }

        public async Task<IEnumerable<Address>> GetAllAddresses()
        {
            return await context.Addresses
                .ToListAsync();
        }

        public async Task<Address> GetAddressByGuid(Guid AddressId)
        {
            return await context.Addresses.FirstOrDefaultAsync(a => a.AddressId == AddressId);
        }

        public async Task<Address?> GetAddressByZipCode(string zipCode)
        {
            Address? address = await context.Addresses.SingleOrDefaultAsync(x => x.ZipCode == zipCode);

            return address;
        }

        public async Task<Address> CreateAddress(Address address)
        {
            context.Addresses.Add(address);
            await context.SaveChangesAsync();
            return address;
        }

        public async Task DeleteAddresses(Guid AddressId)
        {
            var address = await GetAddressByGuid(AddressId);
            context.Addresses.Remove(address);
            await context.SaveChangesAsync();
        }

        public async Task UpdateAddresses(Address address)
        {
            await context.SaveChangesAsync();
        }

        
    }
}

