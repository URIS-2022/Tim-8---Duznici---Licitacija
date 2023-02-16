using AutoMapper;
using Landlot.API.Data.Repository;
using Landlot.API.Entities;
using Landlot.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Landlot.API.Controllers
{/// <summary>
 /// Controller for managing lands.
 /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class LandController : ControllerBase
    {
        private readonly ILandRepository landRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LandController"/> class.
        /// </summary>
        /// <param name="landRepository">The land repository.</param>
        /// <param name="mapper">The mapper.</param>
        public LandController(ILandRepository landRepository, IMapper mapper)

        {
            this.landRepository = landRepository;
            this.mapper = mapper;
        }
        /// <summary>
        /// Retrieves a list of land objects from the land repository.
        /// </summary>
        /// <returns> A list of land view models.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LandGetResponseModel>>> GetLand()
        {
            var lands = await landRepository.GetLands();
            if (!lands.Any())
            {
                return NoContent();
            }
            var responseModel = mapper.Map<IEnumerable<LandGetResponseModel>>(lands);
            return Ok(responseModel);
        }
        /// <summary>
        /// Retrieves a land object with the specified ID from the land repository.
        /// </summary>
        /// <param name="LandGuid">The ID of the land object to retrieve.</param>
        /// <returns>A land view model.</returns>

        [HttpGet("{LandGuid}")]
        public async Task<ActionResult<LandGetResponseModel>> GetLand(Guid LandGuid)
        {
            var land = await landRepository.GetLand(LandGuid);
            if (land == null)
            {
                return NotFound();
            }
            var responseModel = mapper.Map<LandGetResponseModel>(land);
            return responseModel;
        }

        /// <summary>
        /// Updates a land object with the specified ID in the land repository.
        /// </summary>
        /// <param name="id">The ID of the land object to update.</param>
        /// <param name="patchModel">A <see cref="LandPatchRequestModel"/> that contains the updated land data.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the update operation.</returns>

        [HttpPatch("{id}")]
        public async Task<ActionResult<LandPatchResponseModel>> PatchLand(Guid id,[FromBody] LandPatchRequestModel patchModel)
        {
            var land = await landRepository.GetLand(id);
            if (land == null)
            {
                return NotFound();
            }

            mapper.Map(patchModel, land);

            var updated = await landRepository.UpdateLand(id, land);
            if (updated == null)
            {
                return BadRequest();
            }

            var responseModel = mapper.Map<LandPatchResponseModel>(updated);

            return Ok(responseModel);
        }

        /// <summary>
        /// Creates a new land object in the land repository.
        /// </summary>
        /// <param name="postModel">A <see cref="LandPostRequestModel"/> that contains the data for the new land object.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the create operation.</returns>
        [HttpPost]
        public async Task<ActionResult<LandPostResponseModel>> PostLand(LandPostRequestModel postModel)
        {
            var land = mapper.Map<Land>(postModel);
            Land? created = await landRepository.AddLand(land);
            if (created == null)
            {
                return BadRequest();
            }
            var responseModel = mapper.Map<LandPostResponseModel>(created);
            return CreatedAtAction("GetLand", new { id = created.LandGuid }, responseModel);
        }

        /// <summary>
        /// Deletes a land object with the specified ID from the land repository.
        /// </summary>
        /// <param name="id">The ID of the land object to delete.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the delete operation.</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLand(Guid id)
        {
            var land = await landRepository.GetLand(id);
            if (land == null)
            {
                return NotFound();
            }
            await landRepository.DeleteLand(land.LandGuid);

            return NoContent();
        }
    }
}
