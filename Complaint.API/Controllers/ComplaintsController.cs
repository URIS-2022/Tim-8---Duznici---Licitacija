using AutoMapper;
using Complaint.API.Data.Repository;
using Complaint.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Complaint.API.Controllers;

/// <summary>
/// Controller for managing Complaints
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class ComplaintsController : ControllerBase
{
    private readonly IComplaintRepository _complaintRepository;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor for ComplaintController
    /// </summary>
    /// <param name="complaintRepository"> Instance of IComplaintRepository to be used for making requests</param>
    /// <param name="mapper"> Instance of IMapper to be used for mapping models</param>
    public ComplaintsController(IComplaintRepository complaintRepository, IMapper mapper)
    {
        _complaintRepository = complaintRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Gets a list of all complaints
    /// </summary>
    /// <returns> IActionResult indicating the status of the operation</returns>
    /// <response code="200">Returns the list of complaints</response>
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

    /// <summary>
    /// Gets a complaint
    /// </summary>
    /// <param name="id"> Id of the complaint to retrieve</param>
    /// <returns> IActionResult indicating the status of the operation</returns>
    /// <response code="200">Returns the complaint</response>
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

    /// <summary>
    /// Deletes a complaint
    /// </summary>
    /// <param name="id"> id of the complaint to be deleted</param>
    /// <param name="patchModel"> Model containing the properties to be updated</param>
    /// <returns> IActionResult indicating the status of the operation</returns>
    /// <response code="204">Returns no content</response>
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

    /// <summary>
    /// Creates a new complaint
    /// </summary>
    /// <param name="postModel"> Model containing the properties of the complaint to be created</param>
    /// <returns> IActionResult indicating the status of the operation</returns>
    /// <response code="201">Returns the created complaint</response>
    [HttpPost]
    public async Task<ActionResult<ComplaintPostResponseModel>> PostComplaint(ComplaintPostRequestModel postModel)
    {
        var complaint = mapper.Map<Entities.Complaint>(postModel);
        var created = await _complaintRepository.AddComplaint(complaint);
        if (created == null)
        {
            return BadRequest();
        }
        var responseModel = mapper.Map<ComplaintPostResponseModel>(created);
        return CreatedAtAction("GetComplaint", new { id = created.Guid }, responseModel);
    }

    /// <summary>
    /// Deletes a complaint
    /// </summary>
    /// <param name="id"> id of the complaint to be deleted</param>
    /// <returns> IActionResult indicating the status of the operation</returns>
    /// <response code="204">Returns no content</response>
    /// <response code="404">Returns not found if the complaint does not exist</response>
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
