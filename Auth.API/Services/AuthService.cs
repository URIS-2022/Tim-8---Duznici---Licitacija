using Auth.API.Data;
using Auth.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Services;

public class AuthService : IAuthService
{
    private readonly AuthDbContext _context;

    public AuthService(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<SystemUser> GetSystemUserByCredentials(string username, string password)
    {
        SystemUser? user = await _context.SystemUser.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);

        return user ?? throw new FileNotFoundException();
    }

    public async Task<SystemUser> GetSystemUserByGuid(Guid guid)
    {
        SystemUser? user = await _context.SystemUser.SingleOrDefaultAsync(x => x.Id == guid);

        return user ?? throw new FileNotFoundException();
    }
}
