using Gateway.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Bidding;

/// <summary>
/// API controller for managing Documents.
/// </summary>
[ApiExplorerSettings(GroupName = "Bidding")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class PublicBiddingController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for PublicBiddingController
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public PublicBiddingController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_BIDDING")}/api/Address");
    }

    /// <summary>
    /// Get all public biddings
    /// </summary>
    /// <returns> List of public biddings </returns>
    /// <response code="200"> List of public biddings </response>
    [HttpGet]
    public Task<IActionResult> GetPublicBiddings()
        => serviceProxy.Get();

    /// <summary>
    /// Get a public bidding by Id
    /// </summary>
    /// <param name="id">Id of the public bidding</param>
    /// <returns> A public bidding </returns>
    /// <response code="200">Returns the public bidding</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetPublicBidding(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Create a new public bidding
    /// </summary>
    /// <param name="requestModel">public bidding to be created</param>
    /// <returns> A newly created public bidding </returns>
    /// <response code="201">Returns the newly created public bidding</response>
    [HttpPost]
    public Task<IActionResult> PostPublicBidding(object requestModel)
        => serviceProxy.Post(requestModel);

    /// <summary>
    /// Update a public bidding
    /// </summary>
    /// <param name="id">Id of the public bidding</param>
    /// <param name="requestModel">public bidding to be updated</param>
    /// <returns> A newly updated public bidding </returns>
    /// <response code="200">Returns the newly updated public bidding</response>
    [HttpPatch("{id}")]
    public Task<IActionResult> PatchPublicBidding(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Delete a public bidding
    /// </summary>
    /// <param name="id">Id of the public bidding</param>
    /// <returns> A no content response </returns>
    /// <response code="204">Returns no content</response>
    /// <response code="404">Returns not found</response>
    [HttpDelete("{id}")]
    public Task<IActionResult> DeletePublicBidding(string id)
        => serviceProxy.Delete(id);
}
