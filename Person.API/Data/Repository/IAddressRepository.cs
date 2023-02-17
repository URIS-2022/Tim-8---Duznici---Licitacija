using Person.API.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Person.API.Data.Repository
{
    /// <summary>
    /// Interface for managing addresses in the database.
    /// </summary>
    public interface IAddressRepository
    {
        /// <summary>
        /// Gets all addresses from the database.
        /// </summary>
        /// <returns>An IEnumerable of Address.</returns>
        Task<IEnumerable<Address>> GetAllAddresses();
        /// <summary>
        /// Gets an address by its unique identifier.
        /// </summary>
        /// <param name="AddressId">The unique identifier of the address.</param>
        /// <returns>An Address object if found; otherwise, null.</returns>
        Task<Address?> GetAddressByGuid(Guid AddressId);
        /// <summary>
        /// Creates a new address in the database.
        /// </summary>
        /// <param name="address">The address to be created.</param>
        /// <returns>The newly created Address object.</returns>
        Task<Address> CreateAddress(Address address);
        /// <summary>
        /// Deletes an address from the database.
        /// </summary>
        /// <param name="AddressId">The unique identifier of the address to be deleted.</param>
        Task DeleteAddress(Guid AddressId);
        /// <summary>
        /// Updates an existing address in the database.
        /// </summary>
        /// <param name="id">The unique identifier of the address to be updated.</param>
        /// <param name="updateModel">The updated address data.</param>
        /// <returns>The updated Address object if successful; otherwise, null.</returns>
        Task<Address?> UpdateAddress(Guid id, Address updateModel);
    }
}
