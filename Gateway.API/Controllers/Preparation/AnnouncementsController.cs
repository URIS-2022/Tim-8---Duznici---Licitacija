using Gateway.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Gateway.API.Controllers.Preparation;

/// <summary>
/// Provides endpoints for Announcements management
/// </summary>
[ApiExplorerSettings(GroupName = "Preparation")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class AnnouncementsController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Initializes a new instance of the AnnouncementsController class
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public AnnouncementsController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_PREPARATION")}/api/Announcements");
    }

    /// <summary>
    /// Gets a list of Announcements.
    /// </summary>
    /// <returns>A list of AnnouncementGetResponseModel, or No Content if there are no announcements.</returns>
    /// <response code="200">Ok if the Announcements are successfully retrieved</response>
    [HttpGet]
    public Task<IActionResult> GetAnnouncements()
    => serviceProxy.Get();

    /// <summary>
    /// Gets the Announcement with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the Announcement to retrieve.</param>
    /// <returns>An AnnouncementGetResponseModel representing the retrieved Announcement, or NotFound if the Announcement does not exist.</returns>
    /// <response code="200">Ok if the Announcement is successfully retrieved</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetAnnouncement(string id)
    => serviceProxy.GetById(id);

    /// <summary>
    /// Updates the Announcement with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the Announcement to update.</param>
    /// <param name="requestModel">An AnnouncementPatchRequestModel containing the properties to update.</param>
    /// <returns>An AnnouncementPatchResponseModel representing the updated Announcement, or BadRequest if the update failed or the Announcement does not exist.</returns>
    /// <response code="200">Ok if the Announcement is successfully updated</response>
    [HttpPatch("{id}")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> PatchAnnouncement(string id, object requestModel)
    => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Creates a new Announcement.
    /// </summary>
    /// <param name="id">The ID of the Announcement to create.</param>
    /// <param name="requestModel">An AnnouncementPostRequestModel containing the properties of the Announcement to create.</param>
    /// <returns>A CreatedAtActionResult containing a URL to the new Announcement and the AnnouncementPostResponseModel of the created Announcement, or BadRequest if the creation failed.</returns>
    /// <response code="201">Created if the Announcement is successfully created</response>
    [HttpPost]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> PostAnnouncement(string id, object requestModel)
    => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Deletes a Announcement object with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the Announcement object to delete.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the delete operation.</returns>
    /// <response code="204">NoContent if the Announcement is successfully deleted</response>
    /// <response code="404">If the Announcement is not found</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> DeleteAnnouncement(string id)
    => serviceProxy.Delete(id);
}
