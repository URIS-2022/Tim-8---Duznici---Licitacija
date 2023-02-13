using Bidding.API.Data.Repository;
using Bidding.API.Entities;
using Bidding.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Bidding.API.Controllers
{
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

        [HttpGet("{amount}")]
        public async Task<ActionResult<BuyerApplicationResponseModel>> GetBuyerApplicationByAmount(int amount)
        {
            BuyerApplication buyerApplication = await _buyerApplicationRepository.GetBuyerApplicationByAmount(amount);
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
