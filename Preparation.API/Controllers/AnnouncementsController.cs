using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Preparation.API.Data.Repository;
using Preparation.API.Models;

namespace Preparation.API.Controllers
{
    /// <summary>
    /// Provides endpoints for Announcements management
    /// </summary>
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
        /// Gets a list of Announcements.
        /// </summary>
        /// <returns>A list of AnnouncementGetResponseModel, or No Content if there are no announcements.</returns>
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

        /// <summary>
        /// Gets the Announcement with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Announcement to retrieve.</param>
        /// <returns>An AnnouncementGetResponseModel representing the retrieved Announcement, or NotFound if the Announcement does not exist.</returns>
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

        /// <summary>
        /// Updates the Announcement with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Announcement to update.</param>
        /// <param name="patchModel">An AnnouncementPatchRequestModel containing the properties to update.</param>
        /// <returns>An AnnouncementPatchResponseModel representing the updated Announcement, or BadRequest if the update failed or the Announcement does not exist.</returns>
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

        /// <summary>
        /// Creates a new Announcement.
        /// </summary>
        /// <param name="postModel">An AnnouncementPostRequestModel containing the properties of the Announcement to create.</param>
        /// <returns>A CreatedAtActionResult containing a URL to the new Announcement and the AnnouncementPostResponseModel of the created Announcement, or BadRequest if the creation failed.</returns>
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

        /// <summary>
        /// Deletes an announcement with the given ID.
        /// </summary>
        /// <param name="id">The ID of the announcement to delete.</param>
        /// <returns>
        /// <list type="bullet">
        /// <item><description>HTTP 204 No Content if the announcement was successfully deleted.</description></item>
        /// <item><description>HTTP 404 Not Found if an announcement with the given ID could not be found.</description></item>
        /// </list>
        /// </returns>
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
