using Auth.API.Entities;

namespace Auth.API.Data.Repository
{
    public interface ISystemUserRepository
    {
        Task<SystemUser> GetSystemUserByCredentials(string username, string password);
        Task<SystemUser> GetSystemUserByGuid(Guid guid);
    }
}
