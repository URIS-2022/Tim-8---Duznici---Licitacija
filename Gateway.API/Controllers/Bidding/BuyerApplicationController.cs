using Gateway.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Bidding;

/// <summary>
/// API controller for managing Buyer Applications.
/// </summary>
[ApiExplorerSettings(GroupName = "Bidding")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class BuyerApplicationController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for BuyerApplicationController
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public BuyerApplicationController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_BIDDING")}/api/Address");
    }

    /// <summary>
    /// Get all Buyer Applications
    /// </summary>
    /// <returns> List of Buyer Applications </returns>
    /// <response code="200">List of Buyer Applications</response>
    /// <response code="204"> No Buyer Applications found </response>
    [HttpGet]
    public Task<IActionResult> GetBuyerApplications()
        => serviceProxy.Get();

    /// <summary>
    /// Get a Buyer Application by Id
    /// </summary>
    /// <param name="id">Id of the Buyer Application</param>
    /// <returns> A Buyer Application </returns>
    /// <response code="200">Returns the Buyer Application</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetBuyerApplication(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Create a new Buyer Application
    /// </summary>
    /// <param name="requestModel">Buyer Application to be created</param>
    /// <returns> A newly created Buyer Application </returns>
    /// <response code="201">Returns the newly created Buyer Application</response>
    [HttpPost]
    [Authorize(Roles = "Superuser,BiddingOperator,Bidder,Operator")]
    public Task<IActionResult> PostBuyerApplication(object requestModel)
        => serviceProxy.Post(requestModel);

    /// <summary>
    /// Update a Buyer Application
    /// </summary>
    /// <param name="id">Id of the Buyer Application</param>
    /// <param name="requestModel">Buyer Application to be updated</param>
    /// <returns> A newly updated Buyer Application </returns>
    /// <response code="200">Returns the newly updated Buyer Application</response>
    [HttpPatch("{id}")]
    [Authorize(Roles = "Superuser,BiddingOperator,Operator")]
    public Task<IActionResult> PatchBuyerApplication(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Delete a Buyer Application
    /// </summary>
    /// <param name="id">Id of the Buyer Application</param>
    /// <returns> A no content response </returns>
    /// <response code="204"> Buyer Application deleted </response>
    /// <response code="404"> Buyer Application not found </response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Superuser,BiddingOperator,Operator")]
    public Task<IActionResult> DeleteBuyerApplication(string id)
        => serviceProxy.Delete(id);
}
