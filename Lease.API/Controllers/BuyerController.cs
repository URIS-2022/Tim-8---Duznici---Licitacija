using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Lease.API.Data.Repository;


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
    public async Task<ActionResult<IEnumerable<Models.Buyer.BuyerGetResponseModel>>> GetBuyer()
    {
        var Buyers = await _BuyerRepository.GetAll();
        if (!Buyers.Any())
        {
            return NoContent();
        }
        var responseModel = mapper.Map<IEnumerable<Models.Buyer.BuyerGetResponseModel>>(Buyers);
        return Ok(responseModel);
    }

    // GET: api/Buyers/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Models.Buyer.BuyerGetResponseModel>> GetBuyer(Guid id)
    {
        var Buyer = await _BuyerRepository.GetByGuid(id);
        if (Buyer == null)
        {
            return NotFound();
        }
        var responseModel = mapper.Map<Models.Buyer.BuyerGetResponseModel>(Buyer);
        return responseModel;
    }

    // PATCH: api/Buyers/5
    [HttpPatch("{guid}")]
    public async Task<ActionResult<Models.Buyer.BuyerPatchResponseModel>> PatchGuid(Guid guid, [FromBody] Models.Buyer.BuyerPatchRequestModel patchModel)
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

        var responseModel = mapper.Map<Models.Buyer.BuyerPatchResponseModel>(updated);

        return Ok(responseModel);
    }

    // POST: api/Buyers
    [HttpPost]
    public async Task<ActionResult<Models.Buyer.BuyerPostResponseModel>> PostBuyer(Models.Buyer.BuyerPostRequestModel postModel)
    {
        var Buyer = mapper.Map<Entities.Buyer>(postModel);
        Entities.Buyer? created = await _BuyerRepository.Add(Buyer);
        if (created == null)
        {
            return BadRequest();
        }
        var responseModel = mapper.Map<Models.Buyer.BuyerPostResponseModel>(created);
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