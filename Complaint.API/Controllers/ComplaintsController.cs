using AutoMapper;
using Complaint.API.Data.Repository;
using Complaint.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Complaint.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class ComplaintsController : ControllerBase
{
    private readonly IComplaintRepository _complaintRepository;
    private readonly IMapper mapper;

    public ComplaintsController(IComplaintRepository complaintRepository, IMapper mapper)
    {
        _complaintRepository = complaintRepository;
        this.mapper = mapper;
    }

    // GET: api/Complaints
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ComplaintGetResponseModel>>> GetComplaint()
    {
        var complaints = await _complaintRepository.GetComplaints();
        if (!complaints.Any())
        {
            return NoContent();
        }
        var responseModel = mapper.Map<IEnumerable<ComplaintGetResponseModel>>(complaints);
        return Ok(responseModel);
    }

    // GET: api/Complaints/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ComplaintGetResponseModel>> GetComplaint(Guid id)
    {
        var complaint = await _complaintRepository.GetComplaint(id);
        if (complaint == null)
        {
            return NotFound();
        }
        var responseModel = mapper.Map<ComplaintGetResponseModel>(complaint);
        return responseModel;
    }

    // PATCH: api/Complaints/5
    [HttpPatch("{id}")]
    public async Task<ActionResult<ComplaintPatchResponseModel>> PatchComplaint(Guid id, [FromBody] ComplaintPatchRequestModel patchModel)
    {
        var complaint = await _complaintRepository.GetComplaint(id);
        if (complaint == null)
        {
            return NotFound();
        }

        mapper.Map(patchModel, complaint);

        var updated = await _complaintRepository.UpdateComplaint(id, complaint);
        if (updated == null)
        {
            return BadRequest();
        }

        var responseModel = mapper.Map<ComplaintPatchResponseModel>(updated);

        return Ok(responseModel);
    }

    // POST: api/Complaints
    [HttpPost]
    public async Task<ActionResult<ComplaintPostResponseModel>> PostComplaint(ComplaintPostRequestModel postModel)
    {
        var complaint = mapper.Map<Entities.Complaint>(postModel);
        Entities.Complaint? created = await _complaintRepository.AddComplaint(complaint);
        if (created == null)
        {
            return BadRequest();
        }
        var responseModel = mapper.Map<ComplaintPostResponseModel>(created);
        return CreatedAtAction("GetComplaint", new { id = created.Guid }, responseModel);
    }

    // DELETE: api/Complaints/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteComplaint(Guid id)
    {
        var complaint = await _complaintRepository.GetComplaint(id);
        if (complaint == null)
        {
            return NotFound();
        }
        await _complaintRepository.DeleteComplaint(complaint.Guid);

        return NoContent();
    }
}
