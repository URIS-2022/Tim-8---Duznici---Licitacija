using AutoMapper;
using Licitation.API.Data.Repository;
using Licitation.API.Entities;
using Licitation.API.Models.Licitation;
using Licitation.API.Models.LicitationLands;
using Licitation.API.Models.LicitationPB;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller for managing Licitations.
/// </summary>
namespace Licitation.API.Controllers
{
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
        /// Initializes a new instance of the LicitacionController class.
        /// </summary>
        /// <param name="licitationRepository">An instance of ILicitacionRepository to handle the Licitacions.</param>
        /// <param name="llRepository">An instance of ILicitationLandRepository to handle the LicitacionLands.</param>
        /// <param name="publicBiddingRepository">An instance of ILicitationPublicBiddingRepository to handle the LicitacionPublicBiddings.</param>
        /// <param name="mapper">An instance of IMapper to map between Licitacion entities and models.</param>
        public LicitationController(ILicitationRepository licitationRepository, ILicitationLandRepository llRepository, ILicitationPublicBiddingRepository publicBiddingRepository, IMapper mapper)
        {
            this.licitationRepository = licitationRepository;
            this.llRepository = llRepository;
            this.publicBiddingRepository = publicBiddingRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Returns a list of Licitacions.
        /// </summary>
        /// <returns>A list of Licitacion models, or No Content if no Licitacion found.</returns>
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

        /// <summary>
        /// Returns a Licitacion with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Licitacion to retrieve.</param>
        /// <returns>The Licitacion model with the specified ID, or NotFound if the ID does not match a Licitacion.</returns>
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
        /// Deletes a Licitation by its ID.
        /// </summary>
        /// <param name="id">The ID of the Licitation to be deleted.</param>
        /// <returns>Returns a NoContent result if successful, or NotFound if the Licitation does not exist.</returns>
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
        /// Creates a new Licitation.
        /// </summary>
        /// <param name="requestModel">The new Licitation information.</param>
        /// <returns>Returns the created Licitation model, with a location header pointing to the URL of the newly created Licitation.</returns>
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

        /// <summary>
        /// Updates a Licitation by its ID using a patch model.
        /// </summary>
        /// <param name="id">The ID of the Licitation to be updated.</param>
        /// <param name="patchModel">The patch model containing the updates.</param>
        /// <returns>Returns the updated Licitation model, or BadRequest if the update fails, or NotFound if the Licitation does not exist.</returns>
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

        /// <summary>
        /// Adds a Licitation Land to an existing Licitation.
        /// </summary>
        /// <param name="id">The ID of the Licitation to which the Licitation Land should be added.</param>
        /// <param name="postModel">The Licitation Land information.</param>
        /// <returns>Returns a NoContent result if successful, or BadRequest if the add operation fails.</returns>
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


        /// <summary>
        /// POST: api/Licitation
        /// To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        /// </summary>
        /// <param name="id">The ID of the Licitation to associate with the new Public Bidding</param>
        /// <param name="postModel">The request model for creating the new Public Bidding</param>
        /// <returns>An action result containing the newly created Public Bidding</returns>
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

        /// <summary>
        /// DELETE: api/Licitaion/5
        /// Deletes a Licitation Land with the given Licitation ID and Licitation Land ID.
        /// </summary>
        /// <param name="id">The ID of the Licitation to delete the Licitation Land from</param>
        /// <param name="licitationLandId">The ID of the Licitation Land to delete</param>
        /// <returns>An action result indicating success or failure of the operation</returns>
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

        /// <summary>
        /// DELETE: api/Licitaion/5
        /// Deletes a Public Bidding with the given Licitation ID and Public Bidding ID.
        /// </summary>
        /// <param name="id">The ID of the Licitation to delete the Public Bidding from</param>
        /// <param name="publicBiddingId">The ID of the Public Bidding to delete</param>
        /// <returns>An action result indicating success or failure of the operation</returns>
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
}
