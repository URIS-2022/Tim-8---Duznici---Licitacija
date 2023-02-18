using AutoMapper;
using Bidding.API.Data.Repository;
using Bidding.API.Entities;
using Bidding.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Bidding.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class RepresentativeController : ControllerBase
    {
        private readonly IRepresentativeRepository _representativeRepository;
        private readonly IMapper _mapper;

        public RepresentativeController(IRepresentativeRepository representativeRepository, IMapper mapper)
        {
            _representativeRepository = representativeRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<RepresentativeResponseModel>>> GetRepresentatives()
        {
            var representatives = await _representativeRepository.GetAllRepresentatives();
            if (!representatives.Any())
            {
                return NoContent();
            }
            IEnumerable<RepresentativeResponseModel> responseModels = _mapper.Map<IEnumerable<RepresentativeResponseModel>>(representatives);
            return Ok(responseModels);
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<RepresentativeResponseModel>> GetRepresentative(Guid guid)
        {
            Representative representative = await _representativeRepository.GetRepresentativeByGuid(guid);
            if (representative == null)
            {
                return NotFound();
            }
            RepresentativeResponseModel responseModel = _mapper.Map<RepresentativeResponseModel>(representative);
            return Ok(responseModel);
        }

        [HttpPost]
        public async Task<ActionResult<RepresentativeResponseModel>> PostRepresentative(RepresentativeRequestModel requestModel)
        {
            Representative representative = _mapper.Map<Representative>(requestModel);
            Representative createdRepresentative = await _representativeRepository.AddRepresentative(representative);
            if (createdRepresentative == null)
            {
                return BadRequest();
            }
            RepresentativeResponseModel responseModel = _mapper.Map<RepresentativeResponseModel>(createdRepresentative);
            return CreatedAtAction("GetRepresentative", new { guid = createdRepresentative.Guid }, responseModel);
        }

        [HttpPatch("{guid}")]
        public async Task<IActionResult> PatchRepresentative(Guid guid, RepresentativeUpdateModel representativeUpdate)
        {
            var representative = await _representativeRepository.GetRepresentativeByGuid(guid);
            if (representative == null || representativeUpdate == null)
            {
                return BadRequest();
            }
            _mapper.Map(representativeUpdate, representative);

            var updatedRepresentative = await _representativeRepository.UpdateRepresentative(representative);
            if (updatedRepresentative == null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteRepresentative(Guid guid)
        {
            var representative = await _representativeRepository.GetRepresentativeByGuid(guid);
            if (representative == null)
            {
                return NotFound();
            }

            await _representativeRepository.DeleteRepresentative(guid);

            return NoContent();
        }
    }
}
