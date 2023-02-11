namespace Complaint.API.Data.Repository;

/// <summary>
/// The interface for complaint repository, provides methods for getting, updating, adding and deleting a complaint
/// </summary>
public interface IComplaintRepository
{
    /// <summary>
    /// Gets a list of all complaints.
    /// </summary>
    /// <returns>A list of complaints.</returns>
    Task<IEnumerable<Entities.Complaint>> GetComplaints();

    /// <summary>
    /// Gets a specific complaint by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the complaint.</param>
    /// <returns>The complaint with the specified identifier.</returns>
    Task<Entities.Complaint?> GetComplaint(Guid id);

    /// <summary>
    /// Updates a specific complaint.
    /// </summary>
    /// <param name="id">The identifier of the complaint to update.</param>
    /// <param name="patchDocument">The updated values for the complaint.</param>
    /// <returns>The updated complaint.</returns>
    Task<Entities.Complaint?> UpdateComplaint(Guid id, Entities.Complaint patchDocument);

    /// <summary>
    /// Adds a new complaint.
    /// </summary>
    /// <param name="complaint">The complaint to add.</param>
    /// <returns>The added complaint.</returns>
    Task<Entities.Complaint?> AddComplaint(Entities.Complaint complaint);

    /// <summary>
    /// Deletes a specific complaint.
    /// </summary>
    /// <param name="id">The identifier of the complaint to delete.</param>
    /// <returns>The deleted complaint.</returns>
    Task DeleteComplaint(Guid id);
}