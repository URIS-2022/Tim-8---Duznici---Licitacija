using Complaint.API.Data.Repository;
using Microsoft.AspNetCore.Mvc;

namespace Complaint.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class ComplaintsController : ControllerBase
{
    private readonly IComplaintRepository _complaintRepository;

    public ComplaintsController(IComplaintRepository complaintRepository)
    {
        _complaintRepository = complaintRepository;
    }

    // GET: api/Complaints
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Entities.Complaint>>> GetComplaint()
    {
        var complaints = await _complaintRepository.GetComplaints();
        if (!complaints.Any())
        {
            return NoContent();
        }

        return Ok(complaints.ToList());
    }

    // GET: api/Complaints/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Entities.Complaint>> GetComplaint(Guid id)
    {
        var complaint = await _complaintRepository.GetComplaint(id);
        if (complaint == null)
        {
            return NotFound();
        }

        return complaint;
    }

    // PATCH: api/Complaints/5
    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchComplaint(Guid id, [FromBody] Entities.Complaint patchModel)
    {
        var complaint = await _complaintRepository.GetComplaint(id);
        if (complaint == null)
        {
            return NotFound();
        }

        var updated = await _complaintRepository.UpdateComplaint(id, complaint);
        if (updated != null)
        {
            return BadRequest();
        }

        return NoContent();
    }

    // POST: api/Complaints
    [HttpPost]
    public async Task<ActionResult<Entities.Complaint>> PostComplaint(Entities.Complaint complaint)
    {
        var created = await _complaintRepository.AddComplaint(complaint);
        if (created != null)
        {
            return BadRequest();
        }

        return CreatedAtAction("GetComplaint", new { id = created.Guid }, created);
    }

    // DELETE: api/Complaints/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComplaint(Guid id)
    {
        var deleted = _complaintRepository.DeleteComplaint(id);

        if (deleted == null)
        {
            return NotFound();
        }

        return NoContent();
    }
}
