using Administration.API.Data.Repository;
using Administration.API.Entities;
using Administration.API.Models.Member;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Administration.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class MembersController : ControllerBase
{
    private readonly IMemberRepository memberRepository;
    private readonly IMapper mapper;

    public MembersController(IMemberRepository memberRepository, IMapper mapper)
    {
        this.memberRepository = memberRepository;
        this.mapper = mapper;
    }

    // GET: api/Members
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

    // GET: api/Members/5
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

    // PATCH: api/Members/5
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

    // POST: api/Members
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
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

    // DELETE: api/Members/5
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
