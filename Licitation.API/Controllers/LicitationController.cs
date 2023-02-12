using AutoMapper;
using Licitation.API.Data.Repository;
using Licitation.API.Entities;
using Licitation.API.Models.Licitation;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Licitation.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class LicitationController : ControllerBase
{
    private readonly ILicitationRepository licitationRepository;
    private readonly IMapper mapper;

    /// <summary>
    /// Initializes a new instance of the LicitacionController class
    /// </summary>
    /// <param name="licitationRepository">An instance of ILicitacionRepository to handle the Licitacions</param>
    /// <param name="mapper">An instance of IMapper to map between Licitacion entities and models</param>
    public LicitationController(ILicitationRepository licitationRepository, IMapper mapper)
    {
        this.licitationRepository = licitationRepository;
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
        LicitationEntity requestedLicitation = mapper.Map<LicitationEntity>(requestModel);
        LicitationEntity? createdLicitation = await licitationRepository.AddLicitation(requestedLicitation);
        if (createdLicitation == null)
        {
            return BadRequest();
        }
        LicitationResponseModel responseModel = mapper.Map<LicitationResponseModel>(createdLicitation);
        return CreatedAtAction("GetLicitation", new { id = responseModel.Guid }, responseModel);
    }

    // PATCH: api/LicitationEntities/5
    [HttpPatch("{id}")]
    public async Task<ActionResult<LicitationResponseModel>> PatchLicitation(Guid id, [FromBody] LicitationRequestModel patchModel)
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

    /* // POST: api/Licitation
     [HttpPost]
     public async Task<ActionResult<LicitationResponseModel>> PostLicitation(LicitationRequestModel postModel)
     {
         var complaint = mapper.Map<Entities.LicitationEntity>(postModel);
         Entities.LicitationEntity? created = await licitationRepository.AddLicitation(complaint);
         if (created == null)
         {
             return BadRequest();
         }
         var responseModel = mapper.Map<LicitationResponseModel>(created);
         return CreatedAtAction("GetComplaint", new { id = created.Guid }, responseModel);
     }*/

    /*/// <summary>
    /// Returns a specific Licitation based on the date
    /// </summary>
    /// <param name="date">The date of the Licitation to retrieve</param>
    /// <returns>The Licitation model, or Not Found if the Licitation is not found</returns>
    [HttpGet("{date}")]
    public async Task<ActionResult<LicitationResponseModel>> GetLicitation(DateTime date)
    {
        LicitationEntity? licitation = await licitationRepository.GetByDate(date);
        if (licitation == null)
        {
            return NotFound();
        }
        LicitationResponseModel responseModel = mapper.Map<LicitationResponseModel>(licitation);
        return Ok(responseModel);
    }*/

}
