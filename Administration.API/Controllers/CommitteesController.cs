using Administration.API.Data.Repository;
using Administration.API.Entities;
using Administration.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Administration.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class CommitteesController : ControllerBase
{
    private readonly ICommitteeRepository committeeRepository;
    private readonly IMapper mapper;

    public CommitteesController(ICommitteeRepository committeeRepository, IMapper mapper)
    {
        this.committeeRepository = committeeRepository;
        this.mapper = mapper;
    }

    // GET: api/Committees
    [HttpGet]
    public async Task<ActionResult<IEnumerable<CommitteeGetResponseModel>>> GetCommittees()
    {
        var complaints = await committeeRepository.GetCommittees();
        if (!complaints.Any())
        {
            return NoContent();
        }
        var responseModel = mapper.Map<IEnumerable<CommitteeGetResponseModel>>(complaints);
        return Ok(responseModel);
    }

    // GET: api/Committees/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CommitteeGetResponseModel>> GetCommittee(Guid id)
    {
        var complaint = await committeeRepository.GetCommittee(id);
        if (complaint == null)
        {
            return NotFound();
        }
        var responseModel = mapper.Map<CommitteeGetResponseModel>(complaint);
        return responseModel;
    }

    // PATCH: api/Committees/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchCommittee(Guid id, Committee patchModel)
    {
        var complaint = await committeeRepository.GetCommittee(id);
        if (complaint == null)
        {
            return NotFound();
        }

        mapper.Map(patchModel, complaint);

        var updated = await committeeRepository.UpdateCommittee(id, complaint);
        if (updated == null)
        {
            return BadRequest();
        }

        var responseModel = mapper.Map<CommitteePatchResponseModel>(updated);

        return Ok(responseModel);
    }

    // POST: api/Committees
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost]
    public async Task<ActionResult<CommitteePostResponseModel>> PostCommittee(CommitteePostResponseModel postModel)
    {
        var complaint = mapper.Map<Committee>(postModel);
        Committee? created = await committeeRepository.AddCommittee(complaint);
        if (created == null)
        {
            return BadRequest();
        }
        var responseModel = mapper.Map<CommitteePostResponseModel>(created);
        return CreatedAtAction("GetComplaint", new { id = created.Guid }, responseModel);
    }

    // DELETE: api/Committees/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCommittee(Guid id)
    {
        var complaint = await committeeRepository.GetCommittee(id);
        if (complaint == null)
        {
            return NotFound();
        }
        await committeeRepository.DeleteCommittee(complaint.Guid);

        return NoContent();
    }
}
