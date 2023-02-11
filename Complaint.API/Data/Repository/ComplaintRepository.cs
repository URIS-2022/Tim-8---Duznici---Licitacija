using Microsoft.EntityFrameworkCore;

namespace Complaint.API.Data.Repository;

/// <summary>
/// Implementation of the IComplaintRepository
/// interface for managing Complaint entities in the database.
/// </summary>
public class ComplaintRepository : IComplaintRepository
{
    private readonly ComplaintDbContext context;

    /// <summary>
    /// Initializes a new instance of the ComplaintRepository class.
    /// </summary>
    /// <param name="context">The database context to use for data access.</param>
    public ComplaintRepository(ComplaintDbContext context)
    {
        this.context = context;
    }

    /// <inheritdoc cref="IComplaintRepository.GetComplaints"/>
    public async Task<IEnumerable<Entities.Complaint>> GetComplaints()
    {
        return await context.Complaints.ToListAsync();
    }

    /// <inheritdoc cref="IComplaintRepository.GetComplaint"/>
    public async Task<Entities.Complaint?> GetComplaint(Guid id)
    {
        return await context.Complaints.FindAsync(id);
    }

    /// <inheritdoc cref="IComplaintRepository.UpdateComplaint"/>
    public async Task<Entities.Complaint?> UpdateComplaint(Guid id, Entities.Complaint updateModel)
    {
        var complaint = await context.Complaints.FirstOrDefaultAsync(c => c.Guid == id);
        if (complaint == null)
        {
            return null;
        }
        context.Entry(complaint).CurrentValues.SetValues(updateModel);
        await context.SaveChangesAsync();
        return complaint;
    }

    /// <inheritdoc cref="IComplaintRepository.AddComplaint"/>
    public async Task<Entities.Complaint?> AddComplaint(Entities.Complaint complaint)
    {
        var created = context.Complaints.Add(complaint);
        await context.SaveChangesAsync();
        return created.Entity;
    }

    /// <inheritdoc cref="IComplaintRepository.DeleteComplaint"/>
    public async Task DeleteComplaint(Guid id)
    {
        var systemUser = await context.Complaints.FindAsync(id);
        if (systemUser == null)
        {
            throw new InvalidOperationException("Compalint not found");
        }
        context.Complaints.Remove(systemUser);
        await context.SaveChangesAsync();
    }
}


