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
        private readonly ILotRepository _lotRepository;
        private readonly IMapper mapper;

        public LotController(ILotRepository lotRepository, IMapper mapper)
        {
            _lotRepository = lotRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Lot>>> GetLot()
        {
            var lots = await _lotRepository.GetLots();
            if (!lots.Any())
            {
                return NoContent();
            }
            IEnumerable<Lot> responseModel = mapper.Map<IEnumerable<Lot>>(lots);
            return Ok(responseModel);
        }
    }
}
