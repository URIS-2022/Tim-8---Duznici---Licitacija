using Gateway.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Bidding;

/// <summary>
/// API controller for managing Bidding Offers.
/// </summary>
[ApiExplorerSettings(GroupName = "Bidding")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class BiddingOffersController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for BiddingOffersController
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public BiddingOffersController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_BIDDING")}/api/BiddingOffer");
    }

    /// <summary>
    /// Get all Bidding Offers
    /// </summary>
    /// <returns> List of Bidding Offers </returns>
    /// <response code="200">Returns the list of Bidding Offers</response>
    [HttpGet]
    public Task<IActionResult> GetBiddingOffers()
        => serviceProxy.Get();

    /// <summary>
    /// Get a Bidding Offer by Id
    /// </summary>
    /// <param name="id">Id of the Bidding Offer</param>
    /// <returns> A Bidding Offer </returns>
    /// <response code="200">Returns the Bidding Offer</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetBiddingOffer(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Create a new Bidding Offer
    /// </summary>
    /// <param name="requestModel">Bidding Offer to be created</param>
    /// <returns> A newly created Bidding Offer </returns>
    /// <response code="201">Returns the newly created Bidding Offer</response>
    [HttpPost]
    public Task<IActionResult> PostBiddingOffer(object requestModel)
        => serviceProxy.Post(requestModel);

    /// <summary>
    /// Update a Bidding Offer
    /// </summary>
    /// <param name="id">Id of the Bidding Offer</param>
    /// <param name="requestModel">Bidding Offer to be updated</param>
    /// <returns>A newly updated Bidding Offer </returns>
    /// <response code="200">Returns the newly updated Bidding Offer</response>
    [HttpPatch("{id}")]
    public Task<IActionResult> PatchBiddingOffer(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Delete a Bidding Offer
    /// </summary>
    /// <param name="id">Id of the Bidding Offer</param>
    /// <returns> A no content response </returns>
    /// <response code="204">Returns no content </response>
    /// <response code="404">If the Bidding Offer is not found</response>
    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteBiddingOffer(string id)
        => serviceProxy.Delete(id);
}
