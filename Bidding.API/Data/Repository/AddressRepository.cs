using Bidding.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bidding.API.Data.Repository
{
    public class AddressRepository : IAddressRepository
    {
        private readonly BiddingDBContext context;

        public AddressRepository(BiddingDBContext context)
        {
            this.context = context;
        }

        public async Task<IEnumerable<Address>> GetAllAddresses()
        {
            return await context.Adresses.ToListAsync();
        }

        public async Task<Address> AddAddress(Address address)
        {
            context.Adresses.Add(address);
            await context.SaveChangesAsync();
            return address;
        }

        public async Task DeleteAddress(Guid guid)
        {
            var address = await context.Adresses.FindAsync(guid);
            if (address == null)
            {
                throw new InvalidOperationException("Address not found");
            }
            context.Adresses.Remove(address);
            await context.SaveChangesAsync();
        }

        public async Task<Address> GetAddressByGuid(Guid guid)
        {
            return await context.Adresses.FindAsync(guid);
        }

        public async Task<Address?> UpdateAddress(Address address)
        {
            var existingAddress = await GetAddressByGuid(address.Guid);
            if (existingAddress == null)
            {
                throw new InvalidOperationException($"The address with ID '{address.Guid}' was not found.");
            }

            context.Entry(existingAddress).CurrentValues.SetValues(address);
            await context.SaveChangesAsync();

            return existingAddress;
        }
    }
}
