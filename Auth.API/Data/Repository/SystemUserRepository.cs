using Auth.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Data.Repository;

public class SystemUserRepository : ISystemUserRepository
{
    private readonly AuthDbContext context;

    public SystemUserRepository(AuthDbContext context)
    {
        this.context = context;
    }

    public Task<SystemUser> Add(SystemUser systemUser)
    {
        throw new NotImplementedException();
    }

    public Task Delete(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<IEnumerable<SystemUser>> GetAll()
    {
        throw new NotImplementedException();
    }

    public async Task<SystemUser> GetByCredentials(string username, string password)
    {
        SystemUser? user = await context.SystemUser.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);

        return user ?? throw new InvalidOperationException("The requested SystemUser was not found.");
    }

    public async Task<SystemUser> GetByGuid(Guid guid)
    {
        SystemUser? user = await context.SystemUser.SingleOrDefaultAsync(x => x.Id == guid);

        return user ?? throw new InvalidOperationException("The requested SystemUser was not found.");
    }

    public async Task<SystemUser> GetByUsername(string username)
    {
        SystemUser? user = await context.SystemUser.SingleOrDefaultAsync(x => x.Username == username);

        return user ?? throw new InvalidOperationException("The requested SystemUser was not found.");
    }

    public async Task<SystemUser> Update(SystemUser systemUser)
    {
        var existingSystemUser = await context.SystemUser.FindAsync(systemUser.Id);
        if (existingSystemUser == null)
        {
            throw new InvalidOperationException($"The SystemUser with ID '{systemUser.Id}' was not found.");
        }

        context.Entry(existingSystemUser).CurrentValues.SetValues(systemUser);
        await context.SaveChangesAsync();

        return existingSystemUser;
    }
}
