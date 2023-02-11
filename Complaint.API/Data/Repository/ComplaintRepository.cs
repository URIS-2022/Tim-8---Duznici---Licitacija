using Microsoft.EntityFrameworkCore;

namespace Complaint.API.Data.Repository;

/// <summary>
/// Implementation of the IComplaintRepository
/// interface for managing Complaint entities in the database.
/// </summary>
public class ComplaintRepository : IComplaintRepository
{
    private readonly ComplaintDbContext _context;

    /// <summary>
    /// Initializes a new instance of the ComplaintRepository class.
    /// </summary>
    /// <param name="context">The database context to use for data access.</param>
    public ComplaintRepository(ComplaintDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc cref="IComplaintRepository.GetComplaints"/>
    public async Task<IEnumerable<Entities.Complaint>> GetComplaints()
    {
        return await _context.Complaints.ToListAsync();
    }

    /// <inheritdoc cref="IComplaintRepository.GetComplaint"/>
    public async Task<Entities.Complaint?> GetComplaint(Guid id)
    {
        return await _context.Complaints.FindAsync(id);
    }

    /// <inheritdoc cref="IComplaintRepository.UpdateComplaint"/>
    public async Task<Entities.Complaint?> UpdateComplaint(Guid id, Entities.Complaint updateModel)
    {
        var complaint = await _context.Complaints.FirstOrDefaultAsync(c => c.Guid == id);
        if (complaint == null)
        {
            return null;
        }
        _context.Entry(complaint).CurrentValues.SetValues(updateModel);
        await _context.SaveChangesAsync();
        return complaint;
    }

    /// <inheritdoc cref="IComplaintRepository.AddComplaint"/>
    public async Task<Entities.Complaint?> AddComplaint(Entities.Complaint complaint)
    {
        var created = _context.Complaints.Add(complaint);
        await _context.SaveChangesAsync();
        return created.Entity;
    }

    /// <inheritdoc cref="IComplaintRepository.DeleteComplaint"/>
    public async Task<Entities.Complaint?> DeleteComplaint(Guid id)
    {
        var complaint = await _context.Complaints.FindAsync(id);
        if (complaint == null)
        {
            return null;
        }

        _context.Complaints.Remove(complaint);
        await _context.SaveChangesAsync();
        return complaint;
    }
}


