using Auth.API.Models;

namespace Auth.API.Services
{
    public interface IAuthService
    {
        Task<SystemUser> GetSystemUserByCredentials(string username, string password);
        Task<SystemUser> GetSystemUserByGuid(Guid guid);
    }
}
