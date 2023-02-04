using Auth.API.Entities;

namespace Auth.API.Data.Repository
{
    public interface ISystemUserRepository
    {
        Task<IEnumerable<SystemUser>> GetAll();
        Task<SystemUser> GetByGuid(Guid guid);
        Task<SystemUser> GetByUsername(string username);
        Task<SystemUser> GetByCredentials(string username, string password);
        Task<SystemUser> Add(SystemUser systemUser);
        Task<SystemUser> Update(SystemUser systemUser);
        Task Delete(Guid id);
    }
}
