using Microsoft.EntityFrameworkCore;
using Person.API.Entities;

namespace Person.API.Data.Repository
{
    /// <summary>
    /// Provides CRUD operations for the Address entity.
    /// </summary>
    public class AddressRepository : IAddressRepository
    {
        private readonly PersonDbContext context;

        /// <summary>
        /// Creates a new instance of the AddressRepository class.
        /// </summary>
        /// <param name="context">The PersonDbContext object.</param>
        public AddressRepository(PersonDbContext context)
        {
            this.context = context;

        }
        /// <summary>
        /// Retrieves all addresses from the database.
        /// </summary>
        /// <returns>An IEnumerable collection of Address objects.</returns>
        public async Task<IEnumerable<Address>> GetAllAddresses()
        {
            return await context.Addresses.ToListAsync();
        }
        /// <summary>
        /// Retrieves an address from the database by its ID.
        /// </summary>
        /// <param name="AddressId">The ID of the address to retrieve.</param>
        /// <returns>The Address object with the specified ID, or null if no such address exists.</returns>
        public async Task<Address?> GetAddressByGuid(Guid AddressId)
        {
            return await context.Addresses.FirstOrDefaultAsync(a => a.AddressId == AddressId);
        }
        /// <summary>
        /// Adds a new address to the database.
        /// </summary>
        /// <param name="address">The Address object to be added.</param>
        /// <returns>The Address object that was added to the database.</returns>
        public async Task<Address> CreateAddress(Address address)
        {
            context.Addresses.Add(address);
            await context.SaveChangesAsync();
            return address;
        }

        /// <summary>
        /// Deletes an address from the database by its ID.
        /// </summary>
        /// <param name="AddressId">The ID of the address to delete.</param>
        /// <returns>A Task representing the asynchronous operation.</returns>
        public async Task DeleteAddress(Guid AddressId)
        {
            var address = await GetAddressByGuid(AddressId);
            if (address != null)
            {
                context.Addresses.Remove(address);
                await context.SaveChangesAsync();
            }

        }
        /// <summary>
        /// Updates an existing address in the database.
        /// </summary>
        /// <param name="id">The ID of the address to update.</param>
        /// <param name="updateModel">The updated Address object.</param>
        /// <returns>The Address object that was updated in the database, or null if no such address exists.</returns>
        public async Task<Address?> UpdateAddress(Guid id, Address updateModel)
        {
            var address = await context.Addresses.FirstOrDefaultAsync(a => a.AddressId == id);
            if (address == null)
            {
                return null;
            }
            context.Entry(address).CurrentValues.SetValues(updateModel);
            await context.SaveChangesAsync();
            return address;
        }


    }
}

