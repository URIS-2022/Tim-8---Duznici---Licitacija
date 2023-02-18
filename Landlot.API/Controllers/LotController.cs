using AutoMapper;
using Landlot.API.Data.Repository;
using Landlot.API.Entities;
using Landlot.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Landlot.API.Controllers
{
    /// <summary>
    /// Controller for managing lots of land.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class LotController : ControllerBase
    {
        private readonly ILotRepository lotRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="LotController"/> class.
        /// </summary>
        /// <param name="lotRepository">The lot repository.</param>
        /// <param name="mapper">The mapper.</param>
        public LotController(ILotRepository lotRepository, IMapper mapper)

        {
            this.lotRepository = lotRepository;
            this.mapper = mapper;
        }
        /// <summary>
        /// Retrieves a list of lot objects from the lot repository.
        /// </summary>
        /// <returns> A list of lot view models.</returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LotGetResponseModel>>> GetLot()
        {
            var lots = await lotRepository.GetLots();
            if (!lots.Any())
            {
                return NoContent();
            }
            var responseModel = mapper.Map<IEnumerable<LotGetResponseModel>>(lots);
            return Ok(responseModel);
        }

        /// <summary>
        /// Retrieves a lot object with the specified ID from the lot repository.
        /// </summary>
        /// <param name="LotGuid">The ID of the lot object to retrieve.</param>
        /// <returns>A lot view model.</returns>

        [HttpGet("{LotGuid}")]
        public async Task<ActionResult<LotGetResponseModel>> GetLot(Guid LotGuid)
        {
            var lot = await lotRepository.GetLot(LotGuid);
            if (lot == null)
            {
                return NotFound();
            }
            var responseModel = mapper.Map<LotGetResponseModel>(lot);
            return responseModel;
        }

        /// <summary>
        /// Updates a lot object with the specified ID in the lot repository.
        /// </summary>
        /// <param name="id">The ID of the lot object to update.</param>
        /// <param name="patchModel">A <see cref="LotPatchRequestModel"/> that contains the updated lot data.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the update operation.</returns>


        [HttpPatch("{id}")]
        public async Task<ActionResult<LotPatchResponseModel>> PatchLot(Guid id,[FromBody] LotPatchRequestModel patchModel)
        {

            var personApiClient = new HttpClient();
            var personApiUrl = Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_PERSON");
            

            var legalPersonResponse = await personApiClient.GetAsync($"{personApiUrl}/api/LegalPerson/{patchModel.LotUser}");
            var physicalPersonResponse = await personApiClient.GetAsync($"{personApiUrl}/api/PhysicalPerson/{patchModel.LotUser}");
            if (!legalPersonResponse.IsSuccessStatusCode && !physicalPersonResponse.IsSuccessStatusCode)
            {
                return BadRequest("Person not found.");
            }

            var lot = await lotRepository.GetLot(id);
            if (lot == null)
            {
                return NotFound();
            }

            mapper.Map(patchModel, lot);

            var updated = await lotRepository.UpdateLot(id, lot);
            if (updated == null)
            {
                return BadRequest();
            }

            var responseModel = mapper.Map<LotPatchResponseModel>(updated);

            return Ok(responseModel);
        }

        /// <summary>
        /// Creates a new lot object in the lot repository.
        /// </summary>
        /// <param name="postModel">A <see cref="LotPostRequestModel"/> that contains the data for the new lot object.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the create operation.</returns>
        [HttpPost]
        public async Task<ActionResult<LotPostResponseModel>> PostLot(LotPostRequestModel postModel)
        {
            var personApiClient = new HttpClient();
            var personApiUrl = Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_PERSON");


            var legalPersonResponse = await personApiClient.GetAsync($"{personApiUrl}/api/LegalPerson/{postModel.LotUser}");
            var physicalPersonResponse = await personApiClient.GetAsync($"{personApiUrl}/api/PhysicalPerson/{postModel.LotUser}");
            if (!legalPersonResponse.IsSuccessStatusCode && !physicalPersonResponse.IsSuccessStatusCode)
            {
                return BadRequest("Person not found.");
            }

            var lot = mapper.Map<Lot>(postModel);
            Lot? created = await lotRepository.AddLot(lot);
            if (created == null)
            {
                return BadRequest();
            }
            var responseModel = mapper.Map<LotPostResponseModel>(created);
            return CreatedAtAction("GetLot", new { id = created.LotGuid }, responseModel);
        }

        /// <summary>
        /// Deletes a lot object with the specified ID from the lot repository.
        /// </summary>
        /// <param name="id">The ID of the lot object to delete.</param>
        /// <returns>An <see cref="IActionResult"/> representing the result of the delete operation.</returns>

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLot(Guid id)
        {
            var lot = await lotRepository.GetLot(id);
            if (lot == null)
            {
                return NotFound();
            }
            await lotRepository.DeleteLot(lot.LotGuid);

            return NoContent();
        }

    }
}
