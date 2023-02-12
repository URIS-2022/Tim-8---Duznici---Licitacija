using Landlot.API.Entities;

namespace Landlot.API.Data.Repository
{

    public interface ILandRepository
    {
        Task<IEnumerable<Land>> GetLands();

        Task<Land?> GetLand(Guid id);

        Task<Land?> UpdateLand(Guid id, Land land);

        Task<Land?> AddLand(Land land);

        Task DeleteLand(Guid id);
    }
}
