using Auth.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Data.Repository;

public class SystemUserRepository : ISystemUserRepository
{
    private readonly AuthDbContext _context;

    public SystemUserRepository(AuthDbContext context)
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
