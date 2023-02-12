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
        public async Task<ActionResult<IEnumerable<Lot>>> GetLot()
        {
            var lots = await lotRepository.GetLots();
            if (!lots.Any())
            {
                return NoContent();
            }
            IEnumerable<Lot> responseModel = mapper.Map<IEnumerable<Lot>>(lots);
            return Ok(responseModel);
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<LotUpdateModel>> PatchLot(Guid id, LotUpdateModel patchModel)
        {
            Lot? lot = await lotRepository.GetLot(id);
            if (lot == null)
            {
                return NotFound();
            }

            mapper.Map(patchModel, lot);

            Lot updated = await lotRepository.UpdateLot(id, lot);
            if (updated == null)
            {
                return BadRequest();
            }

            LotUpdateModel responseModel = mapper.Map<LotUpdateModel>(lot);

            return Ok(responseModel);
        }

        [HttpPost]
        public async Task<ActionResult<LotModel>> PostLot(LotCreationModel postModel)
        {
            var lot = mapper.Map<Lot>(postModel);
            Lot? createdLot = await lotRepository.AddLot(lot);
            if (createdLot == null)
            {
                return BadRequest();
            }
            var responseModel = mapper.Map<Lot>(createdLot);
            return CreatedAtAction("GetLot", new { id = createdLot.LotGuid }, responseModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLot(Guid id)
        {
            Lot? lot = await lotRepository.GetLot(id);
            if (lot == null)
            {
                return NotFound();
            }
            await lotRepository.DeleteLot(lot.LotGuid);

            return NoContent();
        }

    }
}
