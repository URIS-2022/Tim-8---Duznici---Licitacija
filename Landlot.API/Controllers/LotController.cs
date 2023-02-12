using AutoMapper;
using Landlot.API.Data.Repository;
using Landlot.API.Entities;
using Landlot.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Landlot.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class LotController : ControllerBase
    {
        private readonly ILotRepository lotRepository;
        private readonly IMapper mapper;

        public LotController(ILotRepository lotRepository, IMapper mapper)
        {
            this.lotRepository = lotRepository;
            this.mapper = mapper;
        }

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



        [HttpPatch("{id}")]
        public async Task<ActionResult<LotPatchResponseModel>> PatchLot(Guid id,[FromBody] LotPatchRequestModel patchModel)
        {
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

        [HttpPost]
        public async Task<ActionResult<LotPostResponseModel>> PostLot(LotPostRequestModel postModel)
        {
            var lot = mapper.Map<Lot>(postModel);
            Lot? created = await lotRepository.AddLot(lot);
            if (created == null)
            {
                return BadRequest();
            }
            var responseModel = mapper.Map<LotPostResponseModel>(created);
            return CreatedAtAction("GetLot", new { id = created.LotGuid }, responseModel);
        }

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
