using Lease.API.Entities;

namespace Lease.API.Data.Repository;

/// <summary>
/// The interface for due date repository, provides methods for getting, updating, adding and deleting a due date
/// </summary>
public interface IDueDateRepository
{
    /// <summary>
    /// Gets a specific due date by its identifier.
    /// </summary>
    /// <param name="id"> The identifier of the due date.</param>
    /// <returns> The due date with the specified identifier.</returns>
    Task<DueDate?> GetByGuid(Guid id);

    /// <summary>
    /// Gets a list of all due dates.
    /// </summary>
    /// <returns> A list of due dates.</returns>
    Task<List<DueDate>> GetAll();

    /// <summary>
    /// Adds a new due date.
    /// </summary>
    /// <param name="DueDate"></param>
    /// <returns></returns>
    Task<DueDate?> Add(DueDate DueDate);

    /// <summary>
    /// Updates a specific due date.
    /// </summary>
    /// <param name="DueDate"></param>
    /// <returns></returns>
    Task<DueDate?> Update(DueDate DueDate);

    /// <summary>
    /// Deletes a specific due date.
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    Task<DueDate?> Delete(Guid id);

}

