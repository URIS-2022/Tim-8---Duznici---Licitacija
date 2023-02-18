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
    public class PublicBiddingLotController : ControllerBase
    {
        private readonly IPublicBiddingLotRepository _publicBiddingLotRepository;
        private readonly IMapper _mapper;

        public PublicBiddingLotController(IPublicBiddingLotRepository publicBiddingLotRepository, IMapper mapper)
        {
            _publicBiddingLotRepository = publicBiddingLotRepository;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<PublicBiddingLotNewResponseModel>>> GetPublicBiddingLots()
        {
            var publicBiddingLots = await _publicBiddingLotRepository.GetAllBiddingLots();
            if (!publicBiddingLots.Any())
            {
                return NoContent();
            }
            IEnumerable<PublicBiddingLotNewResponseModel> responseModels = _mapper.Map<IEnumerable<PublicBiddingLotNewResponseModel>>(publicBiddingLots);
            return Ok(responseModels);
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<PublicBiddingLotNewResponseModel>> GetPublicBiddingLot(Guid guid)
        {
            PublicBiddingLot publicBiddingLot = await _publicBiddingLotRepository.GetPublicBiddingLotByGuid(guid);
            if (publicBiddingLot == null)
            {
                return NotFound();
            }
            PublicBiddingLotNewResponseModel responseModel = _mapper.Map<PublicBiddingLotNewResponseModel>(publicBiddingLot);
            return Ok(responseModel);
        }

        [HttpPost]
        public async Task<ActionResult<PublicBiddingLotNewResponseModel>> PostPublicBiddingLot(PublicBiddingLotRequestModel requestModel)
        {
            PublicBiddingLot publicBiddingLot = _mapper.Map<PublicBiddingLot>(requestModel);
            PublicBiddingLot createdPublicBiddingLot = await _publicBiddingLotRepository.AddBiddingLot(publicBiddingLot);
            if (createdPublicBiddingLot == null)
            {
                return BadRequest();
            }
            PublicBiddingLotNewResponseModel responseModel = _mapper.Map<PublicBiddingLotNewResponseModel>(createdPublicBiddingLot);
            return CreatedAtAction("GetPublicBiddingLot", new { guid = createdPublicBiddingLot.Guid }, responseModel);
        }

        [HttpPatch("{guid}")]
        public async Task<IActionResult> PatchPublicBiddingLot(Guid guid, PublicBiddingLotUpdateModel publicBiddingLotUpdate)
        {
            var publicBiddingLot = await _publicBiddingLotRepository.GetPublicBiddingLotByGuid(guid);
            if (publicBiddingLot == null || publicBiddingLotUpdate == null)
            {
                return BadRequest();
            }
            _mapper.Map(publicBiddingLotUpdate, publicBiddingLot);

            var updatedPublicBiddingLot = await _publicBiddingLotRepository.UpdateBiddingLot(publicBiddingLot);
            if (updatedPublicBiddingLot == null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeletePublicBiddingLot(Guid guid)
        {
            var publicBiddingLot = await _publicBiddingLotRepository.GetPublicBiddingLotByGuid(guid);
            if (publicBiddingLot == null)
            {
                return NotFound();
            }

            await _publicBiddingLotRepository.DeleteBiddingLot(guid);

            return NoContent();
        }
    }
}
