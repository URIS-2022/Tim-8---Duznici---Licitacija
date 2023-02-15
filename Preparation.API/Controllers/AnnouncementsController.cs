using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Preparation.API.Data.Repository;
using Preparation.API.Entities;
using Preparation.API.Models;

namespace Preparation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementRepository _announcementRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the AnnouncementsController class
        /// </summary>
        /// <param name="announcementRepository">An instance of IAnnouncementRepository to handle the Announcements</param>
        /// <param name="mapper">An instance of IMapper to map between Announcement entities and models</param>
        public AnnouncementsController(IAnnouncementRepository announcementRepository, IMapper mapper)
        {
            _announcementRepository = announcementRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Returns a list of System Users
        /// </summary>
        /// <returns>A list of System User models, or No Content if no System User found</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnnouncementGetResponseModel>>> GetAnnouncements()
        {
            var announcements = await _announcementRepository.GetAnnouncements();
            if (!announcements.Any())
            {
                return NoContent();
            }
            IEnumerable<AnnouncementGetResponseModel> responseModels = mapper.Map<IEnumerable<AnnouncementGetResponseModel>>(announcements);
            return Ok(responseModels);
        }

        /// GET: api/Announcements/5
        [HttpGet("{id}")]
        public async Task<ActionResult<AnnouncementGetResponseModel>> GetAnnouncement(Guid id)
        {
            var announcement = await _announcementRepository.GetAnnouncement(id);
            if (announcement == null)
            {
                return NotFound();
            }
            var responseModel = mapper.Map<AnnouncementGetResponseModel>(announcement);
            return responseModel;
        }

        // PATCH: api/Announcements/5
        [HttpPatch("{id}")]
        public async Task<ActionResult<AnnouncementPatchResponseModel>> PatchAnnouncement(Guid id, [FromBody] AnnouncementPatchRequestModel patchModel)
        {
            var announcement = await _announcementRepository.GetAnnouncement(id);
            if (announcement == null)
            {
                return NotFound();
            }

            mapper.Map(patchModel, announcement);

            var updated = await _announcementRepository.UpdateAnnouncement(id, announcement);
            if (updated == null)
            {
                return BadRequest();
            }

            var responseModel = mapper.Map<AnnouncementPatchResponseModel>(updated);

            return Ok(responseModel);
        }

        // POST: api/Announcements
        [HttpPost]
        public async Task<ActionResult<AnnouncementPostResponseModel>> PostAnnouncement(AnnouncementPostRequestModel postModel)
        {
            var announcement = mapper.Map<Entities.Announcement>(postModel);
            Entities.Announcement? created = await _announcementRepository.AddAnnouncement(announcement);
            if (created == null)
            {
                return BadRequest();
            }
            var responseModel = mapper.Map<AnnouncementPostResponseModel>(created);
            return CreatedAtAction("GetAnnouncement", new { id = created.Guid }, responseModel);
        }

        // DELETE: api/Announcements/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncement(Guid id)
        {
            var announcement = await _announcementRepository.GetAnnouncement(id);
            if (announcement == null)
            {
                return NotFound();
            }
            await _announcementRepository.DeleteAnnouncement(announcement.Guid);

            return NoContent();
        }
    }
}
