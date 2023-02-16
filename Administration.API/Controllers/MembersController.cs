using Administration.API.Data.Repository;
using Administration.API.Entities;
using Administration.API.Models.Member;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Administration.API.Controllers;

/// <summary>
/// API controller for managing members.
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class MembersController : ControllerBase
{
    private readonly IMemberRepository memberRepository;
    private readonly IMapper mapper;

    /// <summary>
    /// Initializes a new instance of the MembersController class with the specified dependencies.
    /// </summary>
    /// <param name="memberRepository">The repository used for interacting with member data.</param>
    /// <param name="mapper">The object mapper used for mapping between models and entities.</param>
    public MembersController(IMemberRepository memberRepository, IMapper mapper)
    {
        this.memberRepository = memberRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Gets all members.
    /// </summary>
    /// <returns>A collection of MemberGetResponseModel objects.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<MemberGetResponseModel>>> GetMembers()
    {
        var members = await memberRepository.GetMembers();
        if (!members.Any())
        {
            return NoContent();
        }
        var responseModel = mapper.Map<IEnumerable<MemberGetResponseModel>>(members);
        return Ok(responseModel);
    }

    /// <summary>
    /// Gets a member with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the member to retrieve.</param>
    /// <returns>A MemberGetResponseModel object representing the retrieved member.</returns>
    [HttpGet("{id}")]
    public async Task<ActionResult<MemberGetResponseModel>> GetMember(Guid id)
    {
        var member = await memberRepository.GetMember(id);
        if (member == null)
        {
            return NotFound();
        }
        var responseModel = mapper.Map<MemberGetResponseModel>(member);
        return responseModel;
    }

    /// <summary>
    /// Updates a member with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the member to update.</param>
    /// <param name="patchModel">The MemberPatchRequestModel containing the updates to apply.</param>
    /// <returns>A MemberPatchResponseModel object representing the updated member.</returns>
    [HttpPatch("{id}")]
    public async Task<IActionResult> PatchMember(Guid id, MemberPatchRequestModel patchModel)
    {
        var member = await memberRepository.GetMember(id);
        if (member == null)
        {
            return NotFound();
        }

        mapper.Map(patchModel, member);

        var updated = await memberRepository.UpdateMember(id, member);
        if (updated == null)
        {
            return BadRequest();
        }

        var responseModel = mapper.Map<MemberPatchResponseModel>(updated);

        return Ok(responseModel);
    }

    /// <summary>
    /// Creates a new member.
    /// </summary>
    /// <param name="postModel">The MemberPostRequestModel containing the new member data.</param>
    /// <returns>A MemberPostResponseModel object representing the newly created member.</returns>
    [HttpPost]
    public async Task<ActionResult<MemberPostResponseModel>> PostMember(MemberPostRequestModel postModel)
    {
        var member = mapper.Map<Member>(postModel);
        Member? created = await memberRepository.AddMember(member);
        if (created == null)
        {
            return BadRequest();
        }
        var responseModel = mapper.Map<MemberPostResponseModel>(created);
        return CreatedAtAction("GetMember", new { id = created.Guid }, responseModel);
    }

    /// <summary>
    /// Deletes a member with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the member to delete.</param>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteMember(Guid id)
    {
        var member = await memberRepository.GetMember(id);
        if (member == null)
        {
            return NotFound();
        }
        await memberRepository.DeleteMember(member.Guid);

        return NoContent();
    }
}
