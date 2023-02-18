using Bidding.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Bidding.API.Data.Repository
{
    /// <summary>
    /// A repository for managing addresses in the database.
    /// </summary>
    public class AddressRepository : IAddressRepository
    {
        private readonly BiddingDBContext context;

        /// <summary>
        /// Initializes a new instance of the <see cref="AddressRepository"/> class.
        /// </summary>
        /// <param name="context">The bidding database context.</param>
        public AddressRepository(BiddingDBContext context)
        {
            this.context = context;
        }

        /// <summary>
        /// Retrieves all addresses in the database.
        /// </summary>
        /// <returns>An asynchronous operation that returns an address.</returns>

        public async Task<IEnumerable<Address>> GetAllAddresses()
        {
            return await context.Adresses.ToListAsync();
        }

        /// <summary>
        /// Adds a new address to the database.
        /// </summary>
        /// <param name="address">The address to add.</param>

        public async Task<Address> AddAddress(Address address)
        {
            context.Adresses.Add(address);
            await context.SaveChangesAsync();
            return address;
        }

        /// <summary>
        /// Deletes an address from the database by its GUID.
        /// </summary>
        /// <param name="guid">The GUID of the address to delete.</param>

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
        /// <summary>
        /// Retrieves an address from the database by its GUID.
        /// </summary>
        /// <param name="guid">The GUID of the address to retrieve.</param>
        public async Task<Address> GetAddressByGuid(Guid guid)
        {
            return await context.Adresses.FindAsync(guid);
        }

        /// <summary>
        /// Updates an existing address in the database.
        /// </summary>
        /// <param name="address">The updated address to save.</param>
        /// <returns>An asynchronous operation that returns the updated address or null if the address was not found.</returns>

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
