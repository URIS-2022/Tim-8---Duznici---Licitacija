using AutoMapper;
using Lease.API.Data.Repository;
using Lease.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lease.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class DueDateController : ControllerBase
{
    private readonly IDueDateRepository _DueDateRepository;
    private readonly IMapper mapper;

    public DueDateController(IDueDateRepository DueDateRepository, IMapper mapper)
    {
        _DueDateRepository = DueDateRepository;
        this.mapper = mapper;
    }

    // GET: api/DueDates
    [HttpGet]
    public async Task<ActionResult<IEnumerable<DueDateGetResponseModel>>> GetDueDate()
    {
        var DueDates = await _DueDateRepository.GetAll();
        if (!DueDates.Any())
        {
            return NoContent();
        }
        var responseModel = mapper.Map<IEnumerable<DueDateGetResponseModel>>(DueDates);
        return Ok(responseModel);
    }

    // GET: api/DueDates/5
    [HttpGet("{id}")]
    public async Task<ActionResult<DueDateGetResponseModel>> GetDueDate(Guid id)
    {
        var DueDate = await _DueDateRepository.GetByGuid(id);
        if (DueDate == null)
        {
            return NotFound();
        }
        var responseModel = mapper.Map<DueDateGetResponseModel>(DueDate);
        return responseModel;
    }

    // PATCH: api/DueDates/5
    [HttpPatch("{guid}")]
    public async Task<ActionResult<DueDatePatchResponseModel>> PatchGuid(Guid guid, [FromBody] DueDatePatchRequestModel patchModel)
    {
        var DueDate = await _DueDateRepository.GetByGuid(guid);
        if (DueDate == null)
        {
            return NotFound();
        }

        mapper.Map(patchModel, DueDate);

        var updated = await _DueDateRepository.Update(DueDate);
        if (updated == null)
        {
            return BadRequest();
        }

        var responseModel = mapper.Map<DueDatePatchResponseModel>(updated);

        return Ok(responseModel);
    }

    // POST: api/DueDates
    [HttpPost]
    public async Task<ActionResult<DueDatePostResponseModel>> PostDueDate(DueDatePostRequestModel postModel)
    {
        var DueDate = mapper.Map<Entities.DueDate>(postModel);
        Entities.DueDate? created = await _DueDateRepository.Add(DueDate);
        if (created == null)
        {
            return BadRequest();
        }
        var responseModel = mapper.Map<DueDatePostResponseModel>(created);
        return CreatedAtAction("GetDueDate", new { id = created.Guid }, responseModel);
    }

    // DELETE: api/DueDates/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var DueDate = await _DueDateRepository.GetByGuid(id);
        if (DueDate == null)
        {
            return NotFound();
        }
        await _DueDateRepository.Delete(DueDate.Guid);

        return NoContent();
    }
}