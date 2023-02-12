using AutoMapper;
using Landlot.API.Data.Repository;
using Landlot.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Landlot.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class LandController : ControllerBase
    {
        private readonly ILandRepository _landRepository;
        private readonly IMapper mapper;

        public LandController(ILandRepository landRepository, IMapper mapper)
        {
            _landRepository = landRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LandModel>>> GetLand()
        {
            var lands = await _landRepository.GetLands();
            if (!lands.Any())
            {
                return NoContent();
            }
            var responseModel = mapper.Map<IEnumerable<LandModel>>(lands);
            return Ok(responseModel);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<LandModel>> GetComplaint(Guid id)
        {
            var land = await _landRepository.GetLand(id);
            if (land == null)
            {
                return NotFound();
            }
            var responseModel = mapper.Map<LandModel>(land);
            return responseModel;
        }

        [HttpPatch("{id}")]
        public async Task<ActionResult<LandUpdateModel>> PatchLand(Guid id, [FromBody] LandUpdateModel patchModel)
        {
            var land = await _landRepository.GetLand(id);
            if (land == null)
            {
                return NotFound();
            }

            mapper.Map(patchModel, land);

            var updated = await _landRepository.UpdateLand(id, land);
            if (updated == null)
            {
                return BadRequest();
            }

            var responseModel = mapper.Map<LandUpdateModel>(updated);

            return Ok(responseModel);
        }

        [HttpPost]
        public async Task<ActionResult<LandCreationModel>> PostLand(LandModel postModel)
        {
            var land = mapper.Map<Entities.Land>(postModel);
            Entities.Land? created = await _landRepository.AddLand(land);
            if (created == null)
            {
                return BadRequest();
            }
            var responseModel = mapper.Map<LandCreationModel>(created);
            return CreatedAtAction("GetLand", new { id = created.LandGuid }, responseModel);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLand(Guid id)
        {
            var land = await _landRepository.GetLand(id);
            if (land == null)
            {
                return NotFound();
            }
            await _landRepository.GetLand(land.LandGuid);

            return NoContent();
        }
    }
}
