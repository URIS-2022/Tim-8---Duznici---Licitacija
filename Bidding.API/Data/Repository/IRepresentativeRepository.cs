using Bidding.API.Entities;


namespace Bidding.API.Data.Repository
{
    public interface IRepresentativeRepository
    {
        Task<IEnumerable<Representative>> GetAllRepresentatives();
        Task<Representative> GetRepresentativeByGuid(Guid guid);
        Task<Representative?> GetRepresentativeByIdentificationNumber(string identificationNumber);
        Task<Representative> AddRepresentative(Representative representative);
        Task DeleteRepresentative(Guid guid);
        Task<Representative?> UpdateRepresentative(Representative representative);
    }
}
