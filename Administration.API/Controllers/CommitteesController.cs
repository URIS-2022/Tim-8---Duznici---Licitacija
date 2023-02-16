using Administration.API.Data.Repository;
using Administration.API.Entities;
using Administration.API.Models.Committee;
using Administration.API.Models.CommitteeMember;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Administration.API.Controllers;

/// <summary>
/// Represents the API endpoint for managing committees and their members.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class CommitteesController : ControllerBase
{
    private readonly ICommitteeRepository committeeRepository;
    private readonly ICommitteeMemberRepository cmRepository;
    private readonly IMapper mapper;

    /// <summary>
    /// Represents a controller for managing committees.
    /// </summary>
    /// <param name="committeeRepository">The repository for managing committees.</param>
    /// <param name="cmRepository">The repository for managing committee members.</param>
    /// <param name="mapper">The mapper for mapping models to entities and vice versa.</param>
    public CommitteesController(ICommitteeRepository committeeRepository, ICommitteeMemberRepository cmRepository, IMapper mapper)
    {
        this.committeeRepository = committeeRepository;
        this.cmRepository = cmRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Returns a list of all committees.
    /// </summary>
    /// <returns>A list of committees</returns>
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

    /// <summary>
    /// Returns the details of a specific committee.
    /// </summary>
    /// <param name="id">The ID of the committee</param>
    /// <returns>The details of the committee</returns>
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

    /// <summary>
    /// Updates the specified committee with the given changes.
    /// </summary>
    /// <param name="id">The ID of the committee to update</param>
    /// <param name="patchModel">The changes to apply to the committee</param>
    /// <returns>The updated committee</returns>
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

    /// <summary>
    /// Updates the specified member of a committee with the given changes.
    /// </summary>
    /// <param name="id">The ID of the committee to update the member for</param>
    /// <param name="memberId">The ID of the member to update</param>
    /// <param name="patchModel">The changes to apply to the member</param>
    /// <returns>The updated member</returns>
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

    /// <summary>
    /// Creates a new committee.
    /// </summary>
    /// <param name="postModel">The model for creating a committee.</param>
    /// <returns>The created committee.</returns>
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

    /// <summary>
    /// Creates a new committee member for a committee.
    /// </summary>
    /// <param name="id">The ID of the committee to which the member belongs.</param>
    /// <param name="postModel">The model for creating a committee member.</param>
    /// <returns>The created committee member.</returns>
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

    /// <summary>
    /// Deletes a committee by ID.
    /// </summary>
    /// <param name="id">The ID of the committee to delete.</param>
    /// <returns>A response indicating the success or failure of the operation.</returns>
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

    /// <summary>
    /// Deletes a committee member by ID.
    /// </summary>
    /// <param name="id">The ID of the committee to which the member belongs.</param>
    /// <param name="memberId">The ID of the member to delete.</param>
    /// <returns>A response indicating the success or failure of the operation.</returns>
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
