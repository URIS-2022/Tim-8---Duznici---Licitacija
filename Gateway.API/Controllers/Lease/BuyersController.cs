using Gateway.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Lease;

/// <summary>
/// API controller for managing lands.
/// </summary>
[ApiExplorerSettings(GroupName = "Lease")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class BuyersController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for Buyers
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public BuyersController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_LEASE")}/api/Buyer");
    }

    /// <summary>
    /// Gets a list of lot objects from the Buyers.
    /// </summary>
    /// <returns> A list of lot objects.</returns>
    /// <response code="200">Returns the list of lot objects</response>
    [HttpGet]
    public Task<IActionResult> GetBuyer()
        => serviceProxy.Get();

    /// <summary>
    /// Gets a lot object with the specified ID from the Buyers.
    /// </summary>
    /// <param name="id"> The ID of the lot object to get.</param>
    /// <returns> An <see cref="IActionResult"/> representing the result of the get operation.</returns>
    /// <response code="200">Returns the lot</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetBuyer(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Updates a lot object with the specified ID in the Buyers.
    /// </summary>
    /// <param name="id"> The ID of the lot object to update.</param>
    /// <param name="requestModel"> The lot object to update.</param>
    /// <returns> An <see cref="IActionResult"/> representing the result of the update operation.</returns>
    /// <response code="204">Returns no content</response>
    [HttpPatch("{guid}")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> PatchGuid(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Creates a new lot object in the Buyers.
    /// </summary>
    /// <param name="requestModel"> The lot object to create.</param>
    /// <returns> An <see cref="IActionResult"/> representing the result of the create operation.</returns>
    /// <response code="201">Returns the newly created lot</response>
    [HttpPost]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> PostBuyer(object requestModel)
        => serviceProxy.Post(requestModel);

    /// <summary>
    /// Deletes a lot object with the specified ID from the Buyers.
    /// </summary>
    /// <param name="id">The ID of the buyer object to delete.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the delete operation.</returns>
    /// <response code="204">Returns no content</response>
    /// <response code="404">If the lot is not found</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> Delete(string id)
        => serviceProxy.Delete(id);
}