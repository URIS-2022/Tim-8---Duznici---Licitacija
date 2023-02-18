using Gateway.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Licitation;

/// <summary>
/// API controller for managing Licitations.
/// </summary>
[ApiExplorerSettings(GroupName = "Licitation")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class LicitationsController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Initializes a new instance of the LicitacionController class
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public LicitationsController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_LICITATION")}/api/Licitation");
    }

    /// <summary>
    /// Returns a list of Licitacions
    /// </summary>
    /// <returns>A list of Licitacion models, or No Content if no Licitacion found</returns>
    /// <response code="200">Ok if the Licitacions are successfully retrieved</response>
    [HttpGet]
    public Task<IActionResult> GetLicitations()
        => serviceProxy.Get();

    /// <summary>
    /// Returns the licitation with the specified ID.
    /// </summary>
    /// <param name="id"> The ID of the licitation to return.</param>
    /// <returns> The licitation with the specified ID, or NotFound if the licitation is not found.</returns>
    /// <response code="200">Ok if the licitation is successfully retrieved</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetByGuid(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Deletes a licitation object with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the licitation object to delete.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the delete operation.</returns>
    /// <response code="204">NoContent if the licitation is successfully deleted</response>
    /// <response code="404">If the licitation is not found</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> Delete(string id)
        => serviceProxy.Delete(id);

    /// <summary>
    /// Creates a new Licitation
    /// </summary>
    /// <param name="requestModel">The new Licitation information</param>
    /// <returns>The created Licitation model, with a location header pointing to the URL of the newly created Licitation</returns>
    /// <response code="201">Created if the Licitation is successfully created</response>
    [HttpPost]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> PostLicitation(object requestModel)
        => serviceProxy.Post(requestModel);

    /// <summary>
    /// Updates a Licitation
    /// </summary>
    /// <param name="id"> The ID of the Licitation to update.</param>
    /// <param name="requestModel"> The updated Licitation information.</param>
    /// <returns>A no content response</returns>
    ///  <response code="204">Ok if the Licitation is successfully updated</response>
    [HttpPatch("{id}")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> PatchLicitation(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Updates a land in a licitation
    /// </summary>
    /// <param name="id"> The ID of the Licitation land to update.</param>
    /// <param name="postModel"> The updated Licitation land information.</param>
    /// <returns> Licitation land model</returns>
    /// <response code="204">Ok if the Licitation land is successfully updated</response>
    [HttpPost("{id}/licitationLands")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> PostLicitationLand(Guid id, object postModel)
        => serviceProxy.Post(postModel, $"{id}/licitationLands");

    /// <summary>
    /// Updates a public bidding in a licitation
    /// </summary>
    /// <param name="id"> The ID of the Licitation public bidding to update.</param>
    /// <param name="postModel"> The updated Licitation public bidding information.</param>
    /// <returns> Licitation public bidding model</returns>
    /// <response code="201"> Created if the Licitation public bidding is successfully updated</response>
    [HttpPost("{id}/publicBiddings")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> PostPublicBidding(string id, object postModel)
        => serviceProxy.Post(postModel, $"{id}/publicBiddings");


    /// <summary>
    /// Deletes a licitation land object with the specified ID.
    /// </summary>
    /// <param name="id"> The ID of the licitation object to delete from.</param>
    /// <param name="licitationLandId"> The ID of the licitation land object to delete.</param>
    /// <returns> An <see cref="IActionResult"/> representing the result of the delete operation.</returns>
    /// <response code="204"> NoContent if the licitation land is successfully deleted</response>
    /// <response code="404"> If the licitation land is not found</response>
    [HttpDelete("{id}/licitationLands/{licitationLandId}")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> DeleteLicitationLand(string id, string licitationLandId)
        => serviceProxy.Delete($"{id}/licitationLands/{licitationLandId}");

    /// <summary>
    /// Deletes a public bidding object with the specified ID.
    /// </summary>
    /// <param name="id"> The ID of the licitation object to delete from.</param>
    /// <param name="publicBiddingId"> The ID of the public bidding object to delete.</param>
    /// <returns> An <see cref="IActionResult"/> representing the result of the delete operation.</returns>
    /// <response code="204"> NoContent if the public bidding is successfully deleted</response>
    /// <response code="404"> If the public bidding is not found</response>
    [HttpDelete("{id}/publicBiddings/{publicBiddingId}")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> DeletePublicBidding(Guid id, Guid publicBiddingId)
        => serviceProxy.Delete($"{id}/publicBiddings/{publicBiddingId}");
}
