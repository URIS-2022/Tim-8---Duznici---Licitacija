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
    public class BiddingOfferController : ControllerBase
    {
        private readonly IBiddingOfferRepository _biddingOfferRepository;
        private readonly IMapper _mapper;

        public BiddingOfferController(IBiddingOfferRepository biddingOfferRepository, IMapper mapper)
        {
            _biddingOfferRepository = biddingOfferRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BiddingOfferResponseModel>>> GetBiddingOffers()
        {
            var biddingOffers = await _biddingOfferRepository.GetAllBiddingOffers();
            if (!biddingOffers.Any())
            {
                return NoContent();
            }
            IEnumerable<BiddingOfferResponseModel> responseModels = _mapper.Map<IEnumerable<BiddingOfferResponseModel>>(biddingOffers);
            return Ok(responseModels);
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<BiddingOfferResponseModel>> GetBiddingOffer(Guid guid)
        {
            BiddingOffer biddingOffer = await _biddingOfferRepository.GetBiddingOfferByGuid(guid);
            if (biddingOffer == null)
            {
                return NotFound();
            }
            BiddingOfferResponseModel responseModel = _mapper.Map<BiddingOfferResponseModel>(biddingOffer);
            return Ok(responseModel);
        }

        [HttpGet("{offer}")]
        public async Task<ActionResult<BiddingOfferResponseModel>> GetBiddingOfferByOffer(float offer)
        {
            BiddingOffer biddingOffer = await _biddingOfferRepository.GetBiddingOfferByOffer(offer);
            if (biddingOffer == null)
            {
                return NotFound();
            }
            BiddingOfferResponseModel responseModel = _mapper.Map<BiddingOfferResponseModel>(biddingOffer);
            return Ok(responseModel);
        }

        [HttpPost]
        public async Task<ActionResult<BiddingOfferResponseModel>> PostBiddingOffer(BiddingOfferRequestModel requestModel)
        {
            BiddingOffer biddingOffer = _mapper.Map<BiddingOffer>(requestModel);
            BiddingOffer createdBiddingOffer = await _biddingOfferRepository.AddBiddingOffer(biddingOffer);
            if (createdBiddingOffer == null)
            {
                return BadRequest();
            }
            BiddingOfferResponseModel responseModel = _mapper.Map<BiddingOfferResponseModel>(createdBiddingOffer);
            return CreatedAtAction("GetBiddingOffer", new { guid = createdBiddingOffer.Guid }, responseModel);
        }

        [HttpPatch("{guid}")]
        public async Task<IActionResult> PatchBiddingOffer(Guid guid, BiddingOfferUpdateModel biddingOfferUpdate)
        {
            var biddingOffer = await _biddingOfferRepository.GetBiddingOfferByGuid(guid);
            if (biddingOffer == null || biddingOfferUpdate == null)
            {
                return BadRequest();
            }
            _mapper.Map(biddingOfferUpdate, biddingOffer);

            var updatedBiddingOffer = await _biddingOfferRepository.UpdateBiddingOffer(biddingOffer);
            if (updatedBiddingOffer == null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteBiddingOffer(Guid guid)
        {
            var biddingOffer = await _biddingOfferRepository.GetBiddingOfferByGuid(guid);
            if (biddingOffer == null)
            {
                return NotFound();
            }

            await _biddingOfferRepository.DeleteBiddingOffer(guid);

            return NoContent();
        }
    }
}
