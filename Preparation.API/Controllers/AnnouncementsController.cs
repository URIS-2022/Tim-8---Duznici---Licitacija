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
        private readonly IAnnouncementRepository announcementRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the SystemUsersController class
        /// </summary>
        /// <param name="systemUserRepository">An instance of ISystemUserRepository to handle the System Users</param>
        /// <param name="mapper">An instance of IMapper to map between System User entities and models</param>
        public AnnouncementsController(IAnnouncementRepository announcementRepository, IMapper mapper)
        {
            this.announcementRepository = announcementRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Returns a list of System Users
        /// </summary>
        /// <returns>A list of System User models, or No Content if no System User found</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AnnouncementResponseModel>>> GetAnnouncements()
        {
            var announcements = await announcementRepository.GetAll();
            if (!announcements.Any())
            {
                return NoContent();
            }
            IEnumerable<AnnouncementResponseModel> responseModels = mapper.Map<IEnumerable<AnnouncementResponseModel>>(announcements);
            return Ok(responseModels);
        }

        /// <summary>
        /// Returns a specific System User based on the username
        /// </summary>
        /// <param name="username">The username of the System User to retrieve</param>
        /// <returns>The System User model, or Not Found if the System User is not found</returns>
        [HttpGet("{licitation}")]
        public async Task<ActionResult<AnnouncementResponseModel>> GetByLicitation(Guid LicitationGuid)
        {
            Announcement? announcement = await announcementRepository.GetByLicitation(LicitationGuid);
            if (announcement == null)
            {
                return NotFound();
            }
            AnnouncementResponseModel responseModel = mapper.Map<AnnouncementResponseModel>(announcement);
            return Ok(responseModel);
        }

        /// <summary>
        /// Updates a specific System User based on the username
        /// </summary>
        /// <param name="username">The username of the System User to update</param>
        /// <param name="systemUserUpdate">The updated System User information</param>
        /// <returns>No Content if the System User is updated successfully, or Bad Request if the System User or the update information is invalid</returns>
        [HttpPatch("{Guid}")]
        public async Task<IActionResult> PutAnnouncement(Guid Guid, AnnouncementUpdateModel announcementUpdate)
        {
            var announcement = await announcementRepository.GetByGuid(Guid);
            if (announcement == null || announcementUpdate == null)
            {
                return BadRequest();
            }
            mapper.Map(announcementUpdate, announcement);

            await announcementRepository.Update(announcement);
            return NoContent();
        }

        /// <summary>
        /// Creates a new System User
        /// </summary>
        /// <param name="requestModel">The new System User information</param>
        /// <returns>The created System User model, with a location header pointing to the URL of the newly created System User</returns>
        [HttpPost]
        public async Task<ActionResult<AnnouncementResponseModel>> PostAnnouncement(AnnouncementRequestModel requestModel)
        {
            Announcement requestedAnnouncement = mapper.Map<Announcement>(requestModel);
            Announcement? createdAnnouncement = await announcementRepository.Add(requestedAnnouncement);
            if (createdAnnouncement == null)
            {
                return BadRequest();
            }
            AnnouncementResponseModel responseModel = mapper.Map<AnnouncementResponseModel>(createdAnnouncement);
            return CreatedAtAction("GetAnnaouncement", new { guid = responseModel.LicitationGuid }, responseModel);
        }


        [HttpDelete("{Guid}")]
        public async Task<IActionResult> DeleteAnnouncement(Guid Guid)
        {
            Announcement? announcement = await announcementRepository.GetByGuid(Guid);
            if (announcement == null)
            {
                return NotFound();
            }
            await announcementRepository.Delete(announcement.Guid);

            return NoContent();
        }
    }
}
