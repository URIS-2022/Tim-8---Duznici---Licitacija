using Gateway.API.Helpers;
using Microsoft.AspNetCore.Authorization;
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
public class RepresentativeController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for RepresentativeController
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public RepresentativeController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_BIDDING")}/api/Representative");
    }

    /// <summary>
    /// Get all representatives
    /// </summary>
    /// <returns> List of representatives </returns>
    /// <response code="200"> List of representatives </response>
    [HttpGet]
    public Task<IActionResult> GetRepresentatives()
        => serviceProxy.Get();

    /// <summary>
    /// Get a representative by Id
    /// </summary>
    /// <param name="id">Id of the representative</param>
    /// <returns> A representative </returns>
    /// <response code="200">Returns the representative</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetRepresentative(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Create a new representative
    /// </summary>
    /// <param name="requestModel">representative to be created</param>
    /// <returns> A newly created representative </returns>
    /// <response code="201">Returns the newly created representative</response>
    [HttpPost]
    [Authorize(Roles = "Superuser,BiddingOperator,Bidder,Operator")]
    public Task<IActionResult> PostRepresentative(object requestModel)
        => serviceProxy.Post(requestModel);

    /// <summary>
    /// Update a representative
    /// </summary>
    /// <param name="id">Id of the representative</param>
    /// <param name="requestModel">representative to be updated</param>
    /// <returns> A updated representative </returns>
    /// <response code="200">Returns the updated representative</response>
    [HttpPatch("{id}")]
    [Authorize(Roles = "Superuser,BiddingOperator,Operator")]
    public Task<IActionResult> PatchRepresentative(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Delete a representative
    /// </summary>
    /// <param name="id">Id of the representative</param>
    /// <returns> A no content response </returns>
    /// <response code="204">Returns a no content response</response>
    /// <response code="404">If the representative is not found</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Superuser,BiddingOperator,Operator")]
    public Task<IActionResult> DeleteRepresentative(string id)
        => serviceProxy.Delete(id);
}
