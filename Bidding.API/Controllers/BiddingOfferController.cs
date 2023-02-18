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

        /// <summary>
        /// Initializes a new instance of the <see cref="BiddingOfferController"/> class.
        /// </summary>
        /// <param name="biddingOfferRepository">The repository for accessing bidding offers.</param>
        /// <param name="mapper">The mapper for mapping between models and entities.</param>

        public BiddingOfferController(IBiddingOfferRepository biddingOfferRepository, IMapper mapper)
        {
            _biddingOfferRepository = biddingOfferRepository;
            _mapper = mapper;
        }

        /// <summary>
        /// Gets all bidding offers.
        /// </summary>
        /// <returns>A collection of BiddingOfferResponseModel objects.</returns>

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

        /// <summary>
        /// Gets a specific bidding offer by its unique identifier.
        /// </summary>
        /// <param name="guid">The unique identifier of the bidding offer to retrieve.</param>
        /// <returns>A BiddingOfferResponseModel object.</returns>

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

        /// <summary>
        /// Updates a specific bidding offer with the given GUID.
        /// </summary>
        /// <param name="guid">The GUID of the bidding offer to update.</param>
        /// <param name="biddingOfferUpdate">The updated information for the bidding offer.</param>
        /// <returns>An IActionResult representing the result of the update operation.</returns>

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

        /// <summary>
        /// Deletes a specific bidding offer with the given GUID.
        /// </summary>
        /// <param name="guid">The GUID of the bidding offer to delete.</param>
        /// <returns>An IActionResult representing the result of the delete operation.</returns>

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
