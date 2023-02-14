using AutoMapper;
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

        public async Task<IEnumerable<Address>> GetAllAddress()
        {
            return await context.Addresses.ToListAsync();
        }

        public async Task<Address?> GetAddressByGuid(Guid addressId)
        {
            return await context.Addresses.FindAsync(addressId);
        }

        public async Task<Address?> CreateAddress(Address address)
        {
            var created = context.Addresses.Add(address);
            await context.SaveChangesAsync();
            return created.Entity;
        }

        
        public async Task DeleteAddress(Guid addressId)
        {
            var address = await context.Addresses.FindAsync(addressId);
            if (address == null)
            {
                throw new InvalidOperationException("Address not found");
            }
            context.Addresses.Remove(address);
            await context.SaveChangesAsync();
        }

        
    }
}

