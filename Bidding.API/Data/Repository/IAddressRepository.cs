using Bidding.API.Entities;

namespace Bidding.API.Data.Repository
{
    public interface IAddressRepository
    {

        Task<IEnumerable<Address>> GetAllAddresses();
        Task<Address> GetAddressByGuid(Guid guid);

        Task<Address> AddAddress(Address address);
        Task DeleteAddress(Guid guid);
        Task<Address?> UpdateAddress(Address address);

    }
}
