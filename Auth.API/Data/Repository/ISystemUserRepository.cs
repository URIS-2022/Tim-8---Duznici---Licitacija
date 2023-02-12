using Auth.API.Entities;

namespace Auth.API.Data.Repository;

/// <summary>
/// Repository for managing SystemUser entities.
/// </summary>
public interface ISystemUserRepository
{
    /// <summary>
    /// Gets all SystemUsers from the database.
    /// </summary>
    /// <returns>An asynchronous task that returns an enumerable of SystemUser entities.</returns>
    Task<IEnumerable<SystemUser>> GetAll();

    /// <summary>
    /// Gets a SystemUser by its Guid identifier.
    /// </summary>
    /// <param name="guid">The Guid identifier of the SystemUser.</param>
    /// <returns>An asynchronous task that returns the SystemUser entity with the specified Guid identifier, or null if no such entity exists.</returns>
    Task<SystemUser?> GetByGuid(Guid guid);

    /// <summary>
    /// Gets a SystemUser by its username.
    /// </summary>
    /// <param name="username">The username of the SystemUser.</param>
    /// <returns>An asynchronous task that returns the SystemUser entity with the specified username, or null if no such entity exists.</returns>
    Task<SystemUser?> GetByUsername(string username);

    /// <summary>
    /// Gets a SystemUser by its username and password.
    /// </summary>
    /// <param name="username">The username of the SystemUser.</param>
    /// <param name="password">The password of the SystemUser.</param>
    /// <returns>An asynchronous task that returns the SystemUser entity with the specified username and password, or null if no such entity exists.</returns>
    Task<SystemUser?> GetByCredentials(string username, string password);

    /// <summary>
    /// Adds a new SystemUser to the database.
    /// </summary>
    /// <param name="systemUser">The SystemUser entity to add to the database.</param>
    /// <returns>An asynchronous task that returns the added SystemUser entity.</returns>
    Task<SystemUser?> Add(SystemUser systemUser);

    /// <summary>
    /// Updates an existing SystemUser in the database.
    /// </summary>
    /// <param name="systemUser">The SystemUser entity to update in the database.</param>
    /// <returns>An asynchronous task that returns the updated SystemUser entity.</returns>
    Task<SystemUser?> Update(SystemUser systemUser);

    /// <summary>
    /// Deletes a SystemUser from the database by its Guid identifier.
    /// </summary>
    /// <param name="guid">The Guid identifier of the SystemUser to delete.</param>
    /// <returns>An asynchronous task that represents the operation.</returns>
    Task Delete(Guid guid);

    /// <summary>
    /// Deletes a SystemUser from the database by its username.
    /// </summary>
    /// <param name="username">The username of the SystemUser to delete.</param>
    /// <returns>An asynchronous task that represents the operation.</returns>
    Task Delete(string username);
}
