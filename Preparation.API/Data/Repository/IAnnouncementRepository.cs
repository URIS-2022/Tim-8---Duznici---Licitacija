using Preparation.API.Entities;

namespace Preparation.API.Data.Repository
{
    public interface IAnnouncementRepository
    {
        Task<IEnumerable<Announcement>> GetAll();

        Task<Announcement?> GetByGuid(Guid Guid);

        Task<Announcement?> GetByLicitation(Guid LicitationGuid);

        Task<Announcement?> Add(Announcement Announcement);

        Task<Announcement?> Update(Announcement Announcement);

        Task Delete(Guid Guid);

    }
}
