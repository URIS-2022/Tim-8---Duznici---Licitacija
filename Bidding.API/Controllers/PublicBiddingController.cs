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
    public class PublicBiddingController : ControllerBase
    {
        private readonly IPublicBiddingRepository _publicBiddingRepository;
        private readonly IMapper _mapper;

        public PublicBiddingController(IPublicBiddingRepository publicBiddingRepository, IMapper mapper)
        {
            _publicBiddingRepository = publicBiddingRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicBiddingResponseModel>>> GetPublicBiddings()
        {
            var publicBiddings = await _publicBiddingRepository.GetAllPublicBiddings();
            if (!publicBiddings.Any())
            {
                return NoContent();
            }
            IEnumerable<PublicBiddingResponseModel> responseModels = _mapper.Map<IEnumerable<PublicBiddingResponseModel>>(publicBiddings);
            return Ok(responseModels);
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<PublicBiddingResponseModel>> GetPublicBidding(Guid guid)
        {
            PublicBidding publicBidding = await _publicBiddingRepository.GetPublicBiddingByGuid(guid);
            if (publicBidding == null)
            {
                return NotFound();
            }
            PublicBiddingResponseModel responseModel = _mapper.Map<PublicBiddingResponseModel>(publicBidding);
            return Ok(responseModel);
        }

        [HttpPost]
        public async Task<ActionResult<PublicBiddingResponseModel>> PostPublicBidding(PublicBiddingRequestModel requestModel)
        {
            PublicBidding publicBidding = _mapper.Map<PublicBidding>(requestModel);
            PublicBidding createdPublicBidding = await _publicBiddingRepository.AddPublicBidding(publicBidding);
            if (createdPublicBidding == null)
            {
                return BadRequest();
            }
            PublicBiddingResponseModel responseModel = _mapper.Map<PublicBiddingResponseModel>(createdPublicBidding);
            return CreatedAtAction("GetPublicBidding", new { guid = createdPublicBidding.Guid }, responseModel);
        }

        [HttpPatch("{guid}")]
        public async Task<IActionResult> PatchPublicBidding(Guid guid, PublicBiddingUpdateModel publicBiddingUpdate)
        {
            var publicBidding = await _publicBiddingRepository.GetPublicBiddingByGuid(guid);
            if (publicBidding == null || publicBiddingUpdate == null)
            {
                return BadRequest();
            }
            _mapper.Map(publicBiddingUpdate, publicBidding);

            var updatedPublicBidding = await _publicBiddingRepository.UpdatePublicBidding(publicBidding);
            if (updatedPublicBidding == null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeletePublicBidding(Guid guid)
        {
            var publicBidding = await _publicBiddingRepository.GetPublicBiddingByGuid(guid);
            if (publicBidding == null)
            {
                return NotFound();
            }

            await _publicBiddingRepository.DeletePublicBidding(guid);

            return NoContent();
        }
    }
}
