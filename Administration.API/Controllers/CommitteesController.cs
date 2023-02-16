using Administration.API.Data.Repository;
using Administration.API.Entities;
using Administration.API.Models.Committee;
using Administration.API.Models.CommitteeMember;
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
    private readonly ICommitteeMemberRepository cmRepository;
    private readonly IMapper mapper;

    public CommitteesController(ICommitteeRepository committeeRepository, ICommitteeMemberRepository cmRepository, IMapper mapper)
    {
        this.committeeRepository = committeeRepository;
        this.cmRepository = cmRepository;
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
    public async Task<ActionResult<CommitteePatchResponseModel>> PatchCommittee(Guid id, CommitteePatchRequestModel patchModel)
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

    // PATCH: api/Committees/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPatch("{id}/members/{memberId}")]
    public async Task<ActionResult<CommitteeMemberPatchResponseModel>> PatchCommitteeMember(Guid id, Guid memberId, CommitteeMemberPatchRequestModel patchModel)
    {
        var request = mapper.Map<CommitteeMember>(patchModel);
        request.MemberGuid = memberId;
        request.CommitteeGuid = id;

        var committeeMember = await cmRepository.GetCommitteeMember(id, memberId);
        if (committeeMember == null)
        {
            return NotFound();
        }

        mapper.Map(patchModel, committeeMember);

        var updated = await cmRepository.UpdateCommitteeMember(committeeMember);
        if (updated == null)
        {
            return BadRequest();
        }

        var responseModel = mapper.Map<CommitteeMemberPatchResponseModel>(updated);

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

    // POST: api/Committees
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("{id}/members")]
    public async Task<ActionResult<CommitteePostResponseModel>> PostCommitteeMember(Guid id, CommitteeMemberPostRequestModel postModel)
    {
        var committeeMember = mapper.Map<CommitteeMember>(postModel);
        committeeMember.CommitteeGuid = id;
        var created = await cmRepository.AddCommitteeMember(committeeMember);
        if (created == null)
        {
            return BadRequest();
        }
        return NoContent();
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

    // DELETE: api/Committees/5
    [HttpDelete("{id}/members/{memberId}")]
    public async Task<IActionResult> DeleteCommitteeMember(Guid id, Guid memberId)
    {
        var committee = await cmRepository.GetCommitteeMember(id, memberId);
        if (committee == null)
        {
            return NotFound();
        }
        await cmRepository.DeleteCommitteeMember(committee.CommitteeGuid, committee.MemberGuid);
        return NoContent();
    }
}
