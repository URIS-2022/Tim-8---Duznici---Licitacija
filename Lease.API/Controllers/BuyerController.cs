using AutoMapper;
using Microsoft.AspNetCore.Mvc;

using AutoMapper;
using Lease.API.Data.Repository;
using Lease.API.Models;
using Microsoft.AspNetCore.Mvc;
using Lease.API.Models.Buyer;

namespace Lease.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class BuyerController : ControllerBase
{
    private readonly IBuyerRepository _BuyerRepository;
    private readonly IMapper mapper;

    public BuyerController(IBuyerRepository BuyerRepository, IMapper mapper)
    {
        _BuyerRepository = BuyerRepository;
        this.mapper = mapper;
    }

    // GET: api/Buyers
    [HttpGet]
    public async Task<ActionResult<IEnumerable<BuyerGetResponseModel>>> GetBuyer()
    {
        var Buyers = await _BuyerRepository.GetAll();
        if (!Buyers.Any())
        {
            return NoContent();
        }
        var responseModel = mapper.Map<IEnumerable<BuyerGetResponseModel>>(Buyers);
        return Ok(responseModel);
    }

    // GET: api/Buyers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<BuyerGetResponseModel>> GetBuyer(Guid id)
    {
        var Buyer = await _BuyerRepository.GetByGuid(id);
        if (Buyer == null)
        {
            return NotFound();
        }
        var responseModel = mapper.Map<BuyerGetResponseModel>(Buyer);
        return responseModel;
    }

    // PATCH: api/Buyers/5
    [HttpPatch("{guid}")]
    public async Task<ActionResult<BuyerPatchResponseModel>> PatchGuid(Guid guid, [FromBody] BuyerPatchRequestModel patchModel)
    {
        var Buyer = await _BuyerRepository.GetByGuid(guid);
        if (Buyer == null)
        {
            return NotFound();
        }

        mapper.Map(patchModel, Buyer);

        var updated = await _BuyerRepository.Update(Buyer);
        if (updated == null)
        {
            return BadRequest();
        }

        var responseModel = mapper.Map<BuyerPatchResponseModel>(updated);

        return Ok(responseModel);
    }

    // POST: api/Buyers
    [HttpPost]
    public async Task<ActionResult<BuyerPostResponseModel>> PostBuyer(BuyerPostRequestModel postModel)
    {
        var Buyer = mapper.Map<Entities.Buyer>(postModel);
        Entities.Buyer? created = await _BuyerRepository.Add(Buyer);
        if (created == null)
        {
            return BadRequest();
        }
        var responseModel = mapper.Map<BuyerPostResponseModel>(created);
        return CreatedAtAction("GetBuyer", new { id = created.Guid }, responseModel);
    }

    // DELETE: api/Buyers/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var Buyer = await _BuyerRepository.GetByGuid(id);
        if (Buyer == null)
        {
            return NotFound();
        }
        await _BuyerRepository.Delete(Buyer.Guid);

        return NoContent();
    }
}