using Gateway.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers;

/// <summary>
/// API controller for managing Documents.
/// </summary>
[ApiExplorerSettings(GroupName = "Bidding")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class PublicBiddingLotController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for PublicBiddingLotController
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public PublicBiddingLotController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_BIDDING")}/api/Address");
    }

    /// <summary>
    /// Get all public bidding lots
    /// </summary>
    /// <returns> List of public bidding lots </returns>
    /// <response code="200"> List of public bidding lots </response>
    [HttpGet]
    public Task<IActionResult> GetPublicBiddingLots()
        => serviceProxy.Get();

    /// <summary>
    /// Get a public bidding lot by Id
    /// </summary>
    /// <param name="id">Id of the public bidding lot</param>
    /// <returns> A public bidding lot </returns>
    /// <response code="200">Returns the public bidding lot</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetPublicBiddingLot(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Create a new public bidding lot
    /// </summary>
    /// <param name="requestModel">public bidding lot to be created</param>
    /// <returns> A newly created public bidding lot </returns>
    /// <response code="201">Returns the newly created public bidding lot</response>
    [HttpPost]
    public Task<IActionResult> PostPublicBiddingLot(object requestModel)
        => serviceProxy.Post(requestModel);

    /// <summary>
    /// Update a public bidding lot
    /// </summary>
    /// <param name="id">Id of the public bidding lot</param>
    /// <param name="requestModel">public bidding lot to be updated</param>
    /// <returns> A newly updated public bidding lot </returns>
    /// <response code="200">Returns the newly updated public bidding lot</response>
    [HttpPatch("{id}")]
    public Task<IActionResult> PatchPublicBiddingLot(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Delete a public bidding lot
    /// </summary>
    /// <param name="id">Id of the public bidding lot</param>
    /// <returns> A no content response </returns>
    /// <response code="204">Returns a no content response</response>
    /// <response code="404">If the public bidding lot is not found</response>
    [HttpDelete("{id}")]
    public Task<IActionResult> DeletePublicBiddingLot(string id)
        => serviceProxy.Delete(id);
}
