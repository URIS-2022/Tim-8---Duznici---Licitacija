using Auth.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.Data.Repository;
/// <summary>
/// Implementation of the ISystemUserRepository
/// interface for managing SystemUser entities in the database.
/// </summary>
public class SystemUserRepository : ISystemUserRepository
{
    private readonly AuthDbContext context;

    /// <summary>
    /// Initializes a new instance of the SystemUserRepository class.
    /// </summary>
    /// <param name="context">The database context to use for data access.</param>
    public SystemUserRepository(AuthDbContext context)
    {
        this.context = context;
    }

    /// <inheritdoc cref="ISystemUserRepository.GetAll"/>
    public async Task<SystemUser> Add(SystemUser systemUser)
    {
        context.SystemUsers.Add(systemUser);
        await context.SaveChangesAsync();
        return systemUser;
    }

    /// <inheritdoc cref="ISystemUserRepository.Delete(Guid)"/>
    public async Task Delete(Guid guid)
    {
        var systemUser = await context.SystemUsers.FindAsync(guid);
        if (systemUser == null)
        {
            throw new InvalidOperationException("SystemUser not found");
        }
        context.SystemUsers.Remove(systemUser);
        await context.SaveChangesAsync();
    }

    /// <inheritdoc cref="ISystemUserRepository.Delete(string)"/>
    public async Task Delete(string username)
    {
        var systemUser = await context.SystemUsers.FirstOrDefaultAsync(x => x.Username == username);
        if (systemUser == null)
        {
            throw new InvalidOperationException("SystemUser not found");
        }
        context.SystemUsers.Remove(systemUser);
        await context.SaveChangesAsync();
    }

    /// <inheritdoc cref="ISystemUserRepository.GetAll"/>
    public async Task<IEnumerable<SystemUser>> GetAll()
    {
        return await context.SystemUsers.ToListAsync();
    }

    /// <inheritdoc cref="ISystemUserRepository.GetByCredentials(string, string)"/>
    public async Task<SystemUser> GetByCredentials(string username, string password)
    {
        SystemUser? user = await context.SystemUsers.SingleOrDefaultAsync(x => x.Username == username && x.Password == password);

        return user ?? throw new InvalidOperationException("The requested SystemUser was not found.");
    }

    /// <inheritdoc cref="ISystemUserRepository.GetByGuid(Guid)"/>
    public async Task<SystemUser?> GetByGuid(Guid guid)
    {
        SystemUser? user = await context.SystemUsers.SingleOrDefaultAsync(x => x.Guid == guid);

        return user;
    }

    /// <inheritdoc cref="ISystemUserRepository.GetByUsername(string)"/>
    public async Task<SystemUser?> GetByUsername(string username)
    {
        SystemUser? user = await context.SystemUsers.SingleOrDefaultAsync(x => x.Username == username);

        return user;
    }

    /// <inheritdoc cref="ISystemUserRepository.Update(SystemUser)"/>
    public async Task<SystemUser> Update(SystemUser systemUser)
    {
        var existingSystemUser = await context.SystemUsers.FindAsync(systemUser.Guid);
        if (existingSystemUser == null)
        {
            throw new InvalidOperationException($"The SystemUser with ID '{systemUser.Guid}' was not found.");
        }

        context.Entry(existingSystemUser).CurrentValues.SetValues(systemUser);
        await context.SaveChangesAsync();

        return existingSystemUser;
    }
}
