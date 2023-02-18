using Bidding.API.Data.Repository;
using Bidding.API.Entities;
using Bidding.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Bidding.API.Controllers
{

    /// <summary>
    /// Controller for managing buyer applications.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class BuyerApplicationController : ControllerBase
    {
        private readonly IBuyerApplicationRepository _buyerApplicationRepository;
        private readonly IMapper _mapper;

        public BuyerApplicationController(IBuyerApplicationRepository buyerApplicationRepository, IMapper mapper)
        {
            _buyerApplicationRepository = buyerApplicationRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Retrieves all buyer applications.
        /// </summary>
        /// <returns>A list of all buyer applications.</returns>

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BuyerApplicationResponseModel>>> GetBuyerApplications()
        {
            var buyerApplications = await _buyerApplicationRepository.GetAllBuyerApplications();
            if (!buyerApplications.Any())
            {
                return NoContent();
            }
            IEnumerable<BuyerApplicationResponseModel> responseModels = _mapper.Map<IEnumerable<BuyerApplicationResponseModel>>(buyerApplications);
            return Ok(responseModels);
        }

        /// <summary>
        /// Retrieves a single buyer application by its GUID.
        /// </summary>
        /// <param name="guid">The GUID of the buyer application to retrieve.</param>
        /// <returns>The specified buyer application.</returns>

        [HttpGet("{guid}")]
        public async Task<ActionResult<BuyerApplicationResponseModel>> GetBuyerApplication(Guid guid)
        {
            BuyerApplication buyerApplication = await _buyerApplicationRepository.GetBuyerApplicationByGuid(guid);
            if (buyerApplication == null)
            {
                return NotFound();
            }
            BuyerApplicationResponseModel responseModel = _mapper.Map<BuyerApplicationResponseModel>(buyerApplication);
            return Ok(responseModel);
        }
        [HttpPost]
        public async Task<ActionResult<BuyerApplicationResponseModel>> PostBuyerApplication(BuyerApplicationRequestModel requestModel)
        {
            BuyerApplication buyerApplication = _mapper.Map<BuyerApplication>(requestModel);
            BuyerApplication createdBuyerApplication = await _buyerApplicationRepository.AddBuyerApplication(buyerApplication);
            if (createdBuyerApplication == null)
            {
                return BadRequest();
            }
            BuyerApplicationResponseModel responseModel = _mapper.Map<BuyerApplicationResponseModel>(createdBuyerApplication);
            return CreatedAtAction("GetBuyerApplication", new { guid = createdBuyerApplication.Guid }, responseModel);
        }
        /// <summary>
        /// Updates an existing buyer application.
        /// </summary>
        /// <param name="guid">The GUID of the buyer application to update.</param>
        /// <param name="buyerApplicationUpdate">The details to update the buyer application with.</param>
        /// <returns>A status code indicating the result of the operation.</returns>
        [HttpPatch("{guid}")]
        public async Task<IActionResult> PatchBuyerApplication(Guid guid, BuyerApplicationUpdateModel buyerApplicationUpdate)
        {
            var buyerApplication = await _buyerApplicationRepository.GetBuyerApplicationByGuid(guid);
            if (buyerApplication == null || buyerApplicationUpdate == null)
            {
                return BadRequest();
            }
            _mapper.Map(buyerApplicationUpdate, buyerApplication);

            var updatedBuyerApplication = await _buyerApplicationRepository.UpdateBuyerApplication(buyerApplication);
            if (updatedBuyerApplication == null)
            {
                return BadRequest();
            }

            return NoContent();
        }
        /// <summary>
        /// Deletes the buyer application with the specified GUID.
        /// </summary>
        /// <param name="guid">The GUID of the buyer application to delete.</param>
        /// <returns>A task that represents the asynchronous operation. The task result contains the HTTP action result indicating success or failure of the operation.</returns>
        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteBuyerApplication(Guid guid)
        {
            var buyerApplication = await _buyerApplicationRepository.GetBuyerApplicationByGuid(guid);
            if (buyerApplication == null)
            {
                return NotFound();
            }

            await _buyerApplicationRepository.DeleteBuyerApplication(guid);

            return NoContent();
        }
    }
}
