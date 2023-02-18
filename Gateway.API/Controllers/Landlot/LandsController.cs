using Gateway.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Landlot;

/// <summary>
/// Controller for managing lands.
/// </summary>
[ApiExplorerSettings(GroupName = "Landlot")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class LandsController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for LandsController
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public LandsController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_LANDLOT")}/api/Land");
    }

    /// <summary>
    /// Retrieves a list of land objects from the land repository.
    /// </summary>
    /// <returns> A list of land view models.</returns>
    /// <response code="200">Returns the list of lands</response>
    [HttpGet]
    public Task<IActionResult> GetLand()
        => serviceProxy.Get();
    /// <summary>
    /// Retrieves a land object with the specified ID from the land repository.
    /// </summary>
    /// <param name="id">The ID of the land object to retrieve.</param>
    /// <returns>A land view model.</returns>
    /// <response code="200">Returns the land</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetLand(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Updates a land object with the specified ID in the land repository.
    /// </summary>
    /// <param name="id">The ID of the land object to update.</param>
    /// <param name="requestModel">A that contains the updated land data.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the update operation.</returns>
    /// <response code="204">Returns no content</response>
    [HttpPatch("{id}")]
    public Task<IActionResult> PatchLand(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Creates a new land object in the land repository.
    /// </summary>
    /// <param name="requestModel">A object that contains the data for the new land object.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the create operation.</returns>
    /// <response code="201">Returns the newly created land</response>
    [HttpPost]
    public Task<IActionResult> PostLand(object requestModel)
        => serviceProxy.Post(requestModel);

    /// <summary>
    /// Deletes a land object with the specified ID from the land repository.
    /// </summary>
    /// <param name="id">The ID of the land object to delete.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the delete operation.</returns>
    /// <response code="204">Returns no content</response>
    /// <response code="404">Returns not found</response>
    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteLand(string id)
        => serviceProxy.Delete(id);
}
