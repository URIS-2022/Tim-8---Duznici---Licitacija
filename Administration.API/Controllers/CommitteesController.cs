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
        var committees = await committeeRepository.GetCommittees();
        if (!committees.Any())
        {
            return NoContent();
        }
        var responseModel = mapper.Map<IEnumerable<CommitteeGetResponseModel>>(committees);
        return Ok(responseModel);
    }

    // GET: api/Committees/5
    [HttpGet("{id}")]
    public async Task<ActionResult<CommitteeGetResponseModel>> GetCommittee(Guid id)
    {
        var committee = await committeeRepository.GetCommittee(id);
        if (committee == null)
        {
            return NotFound();
        }
        var responseModel = mapper.Map<CommitteeGetResponseModel>(committee);
        return responseModel;
    }

    // PATCH: api/Committees/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchCommittee(Guid id, CommitteePatchRequestModel patchModel)
    {
        var committee = await committeeRepository.GetCommittee(id);
        if (committee == null)
        {
            return NotFound();
        }

        mapper.Map(patchModel, committee);

        var updated = await committeeRepository.UpdateCommittee(id, committee);
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
    public async Task<ActionResult<CommitteePostResponseModel>> PostCommittee(CommitteePostRequestModel postModel)
    {
        var committee = mapper.Map<Committee>(postModel);
        Committee? created = await committeeRepository.AddCommittee(committee);
        if (created == null)
        {
            return BadRequest();
        }
        var responseModel = mapper.Map<CommitteePostResponseModel>(created);
        return CreatedAtAction("GetCommittee", new { id = created.Guid }, responseModel);
    }

    // DELETE: api/Committees/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteCommittee(Guid id)
    {
        var committee = await committeeRepository.GetCommittee(id);
        if (committee == null)
        {
            return NotFound();
        }
        await committeeRepository.DeleteCommittee(committee.Guid);

        return NoContent();
    }
}
