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
    public class LandController : ControllerBase
    {
        private readonly ILandRepository landRepository;
        private readonly IMapper mapper;

        public LandController(ILandRepository landRepository, IMapper mapper)
        {
            this.landRepository = landRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<LandGetResponseModel>>> GetLand()
        {
            var lands = await landRepository.GetLands();
            if (!lands.Any())
            {
                return NoContent();
            }
            var responseModel = mapper.Map<IEnumerable<LandGetResponseModel>>(lands);
            return Ok(responseModel);
        }


        [HttpGet("{LandGuid}")]
        public async Task<ActionResult<LandGetResponseModel>> GetLand(Guid LandGuid)
        {
            var land = await landRepository.GetLand(LandGuid);
            if (land == null)
            {
                return NotFound();
            }
            var responseModel = mapper.Map<LandGetResponseModel>(land);
            return responseModel;
        }


        [HttpPatch("{id}")]
        public async Task<ActionResult<LandPatchResponseModel>> PatchLand(Guid id,[FromBody] LandPatchRequestModel patchModel)
        {
            var land = await landRepository.GetLand(id);
            if (land == null)
            {
                return NotFound();
            }

            mapper.Map(patchModel, land);

            var updated = await landRepository.UpdateLand(id, land);
            if (updated == null)
            {
                return BadRequest();
            }

            var responseModel = mapper.Map<LandPatchResponseModel>(updated);

            return Ok(responseModel);
        }

        [HttpPost]
        public async Task<ActionResult<LandPostResponseModel>> PostLand(LandPostRequestModel postModel)
        {
            var land = mapper.Map<Land>(postModel);
            Land? created = await landRepository.AddLand(land);
            if (created == null)
            {
                return BadRequest();
            }
            var responseModel = mapper.Map<LandPostResponseModel>(created);
            return CreatedAtAction("GetLand", new { id = created.LandGuid }, responseModel);
        }

       

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLand(Guid id)
        {
            var land = await landRepository.GetLand(id);
            if (land == null)
            {
                return NotFound();
            }
            await landRepository.DeleteLand(land.LandGuid);

            return NoContent();
        }
    }
}
