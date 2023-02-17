using Gateway.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Landlot;

/// <summary>
/// Controller for managing lots of land.
/// </summary>
[ApiExplorerSettings(GroupName = "landlot")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class LotsController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for LotsController
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public LotsController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_LANDLOT")}/api/Lot");
    }

    /// <summary>
    /// Retrieves a list of lot objects from the lot repository.
    /// </summary>
    /// <returns> A list of lot view models.</returns>
    /// <response code="200">Returns the list of lots</response>
    [HttpGet]
    public Task<IActionResult> GetLot()
        => serviceProxy.Get();

    /// <summary>
    /// Retrieves a lot object with the specified ID from the lot repository.
    /// </summary>
    /// <param name="id">The ID of the lot object to retrieve.</param>
    /// <returns>A lot view model.</returns>
    /// <response code="200">Returns the lot</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetLot(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Updates a lot object with the specified ID in the lot repository.
    /// </summary>
    /// <param name="id">The ID of the lot object to update.</param>
    /// <param name="requestModel">A that contains the updated lot data.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the update operation.</returns>
    /// <response code="204">Returns no content</response>
    [HttpPatch("{id}")]
    public Task<IActionResult> PatchLot(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Creates a new lot object in the lot repository.
    /// </summary>
    /// <param name="requestModel">A that contains the data for the new lot object.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the create operation.</returns>
    /// <response code="201">Returns the newly created lot</response>
    [HttpPost]
    public Task<IActionResult> PostLot(object requestModel)
        => serviceProxy.Post(requestModel);

    /// <summary>
    /// Deletes a lot object with the specified ID from the lot repository.
    /// </summary>
    /// <param name="id">The ID of the lot object to delete.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the delete operation.</returns>
    /// <response code="204">Returns no content</response>
    /// <response code="404">If the lot is not found</response>
    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteLot(string id)
        => serviceProxy.Delete(id);

}
