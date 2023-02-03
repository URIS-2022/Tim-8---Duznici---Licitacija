using Auth.API.Data;
using Auth.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Services;
public interface IAuthService
{
    Task<SystemUser> Authenticate(string username, string password);
}

public class AuthService : IAuthService
{
    private readonly AuthDbContext _context;

    public AuthService(AuthDbContext context)
    {
        _context = context;
    }

    public async Task<SystemUser> Authenticate(string username, string password)
    {
        SystemUser? user = await _context.SystemUser.SingleOrDefaultAsync(x => x.UserName == username && x.Password == password);

        return user ?? throw new FileNotFoundException();
    }
}
