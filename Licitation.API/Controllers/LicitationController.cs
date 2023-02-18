using AutoMapper;
using Licitation.API.Data.Repository;
using Licitation.API.Entities;
using Licitation.API.Models.Licitation;
using Licitation.API.Models.LicitationLands;
using Licitation.API.Models.LicitationPB;
using Microsoft.AspNetCore.Mvc;

namespace Licitation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class LicitationController : ControllerBase
{
    private readonly ILicitationRepository licitationRepository;
    private readonly ILicitationLandRepository llRepository;
    private readonly ILicitationPublicBiddingRepository publicBiddingRepository;
    private readonly IMapper mapper;

    /// <summary>
    /// Initializes a new instance of the LicitacionController class
    /// </summary>
    /// <param name="licitationRepository">An instance of ILicitacionRepository to handle the Licitacions</param>
    /// <param name="mapper">An instance of IMapper to map between Licitacion entities and models</param>
    public LicitationController(ILicitationRepository licitationRepository, ILicitationLandRepository llRepository, ILicitationPublicBiddingRepository publicBiddingRepository, IMapper mapper)
    {
        this.licitationRepository = licitationRepository;
        this.llRepository = llRepository;
        this.publicBiddingRepository = publicBiddingRepository;
        this.mapper = mapper;
    }


    /// <summary>
    /// Returns a list of Licitacions
    /// </summary>
    /// <returns>A list of Licitacion models, or No Content if no Licitacion found</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LicitationResponseModel>>> GetLicitations()
    {
        var licitacions = await licitationRepository.GetAll();
        if (!licitacions.Any())
        {
            return NoContent();
        }
        IEnumerable<LicitationResponseModel> responseModels = mapper.Map<IEnumerable<LicitationResponseModel>>(licitacions);
        return Ok(responseModels);
    }

    // GET: api/LicitationEntities/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LicitationResponseModel>> GetByGuid(Guid id)
    {
        var licitation = await licitationRepository.GetByGuid(id);
        if (licitation == null)
        {
            return NotFound();
        }
        var responseModel = mapper.Map<LicitationResponseModel>(licitation);
        return responseModel;
    }

    /// <summary>
    /// Gets all licitation entities that occurred in a specific year.
    /// </summary>
    /// <param name="year">The year to filter by.</param>
    /// <returns>An ActionResult of type LicitationResponseModel if successful, or NotFound if no results are found.</returns>
    // GET: api/LicitationEntities/year
    [HttpGet("date/{year}")]
    public async Task<ActionResult<LicitationResponseModel>> GetByYear(int year)
    {
        var licitation = await licitationRepository.GetByYear(year);
        if (licitation == null)
        {
            return NotFound();
        }
        var responseModel = mapper.Map<LicitationResponseModel>(licitation);
        return responseModel;
    }

    // DELETE: api/LicitationEntities/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var licitation = await licitationRepository.GetByGuid(id);
        if (licitation == null)
        {
            return NotFound();
        }
        await licitationRepository.Delete(licitation.Guid);

        return NoContent();
    }

    /// <summary>
    /// Creates a new Licitation
    /// </summary>
    /// <param name="requestModel">The new Licitation information</param>
    /// <returns>The created Licitation model, with a location header pointing to the URL of the newly created Licitation</returns>
    [HttpPost]
    public async Task<ActionResult<LicitationResponseModel>> PostLicitation(LicitationRequestModel requestModel)
    {
        Entities.Licitation requestedLicitation = mapper.Map<Entities.Licitation>(requestModel);
        Entities.Licitation? createdLicitation = await licitationRepository.AddLicitation((Entities.Licitation)requestedLicitation);
        if (createdLicitation == null)
        {
            return BadRequest();
        }
        LicitationResponseModel responseModel = mapper.Map<LicitationResponseModel>(createdLicitation);
        return CreatedAtAction("GetByGuid", new { id = createdLicitation.Guid }, responseModel);
    }

    // PATCH: api/LicitationEntities/5
    [HttpPatch("{id}")]
    public async Task<ActionResult<LicitationResponseModel>> PatchLicitation(Guid id, [FromBody] LicitationUpdateModel patchModel)
    {
        var licitation = await licitationRepository.GetByGuid(id);
        if (licitation == null)
        {
            return NotFound();
        }

        mapper.Map(patchModel, licitation);

        var updated = await licitationRepository.UpdateLicitation(id, licitation);
        if (updated == null)
        {
            return BadRequest();
        }

        var responseModel = mapper.Map<LicitationResponseModel>(updated);

        return Ok(responseModel);
    }

    // POST: api/Licitation
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("{id}/licitationLands")]
    public async Task<ActionResult<LicitationResponseModel>> PostLicitationLand(Guid id, LicitationLandPostRequestModel postModel)
    {
        var licitationLand = mapper.Map<LicitationLand>(postModel);
        licitationLand.LicitationGuid = id;
        var created = await llRepository.AddLicitationLand(licitationLand);
        if (created == null)
        {
            return BadRequest();
        }
        return NoContent();
    }

    // POST: api/Licitation
    // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
    [HttpPost("{id}/publicBiddings")]
    public async Task<ActionResult<LicitationResponseModel>> PostPublicBidding(Guid id, PublicBiddingPostRequestModel postModel)
    {
        var publicBidding = mapper.Map<PublicBidding>(postModel);
        publicBidding.LicitationGuid = id;
        var created = await publicBiddingRepository.AddPublicBidding(publicBidding);
        if (created == null)
        {
            return BadRequest();
        }
        return NoContent();
    }


    // DELETE: api/Licitaion/5
    [HttpDelete("{id}/licitationLands/{licitationLandId}")]
    public async Task<IActionResult> DeleteLicitationLand(Guid id, Guid licitationLandId)
    {
        var licitation = await llRepository.GetLicitationLand(id, licitationLandId);
        if (licitation == null)
        {
            return NotFound();
        }
        await llRepository.DeleteLicitationLand(id, licitationLandId);
        return NoContent();
    }

    // DELETE: api/Licitaion/5
    [HttpDelete("{id}/publicBiddings/{publicBiddingId}")]
    public async Task<IActionResult> DeletePublicBidding(Guid id, Guid publicBiddingId)
    {
        var publicBidding = await publicBiddingRepository.GetPublicBidding(id, publicBiddingId);
        if (publicBidding == null)
        {
            return NotFound();
        }
        await publicBiddingRepository.DeletePublicBidding(id, publicBiddingId);
        return NoContent();
    }
}
