using Landlot.API.Entities;


namespace Landlot.API.Data.Repository
{
    public interface ILotRepository
    {
        Task<IEnumerable<Lot>> GetLots();
        Task<Lot?> GetLot(Guid id);
        Task<Lot?> UpdateLot(Guid id, Lot lot);
        Task<Lot?> AddLot(Lot lot);
        Task DeleteLot(Guid id);
    }
}
