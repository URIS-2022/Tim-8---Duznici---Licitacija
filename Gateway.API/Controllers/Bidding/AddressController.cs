using Gateway.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Bidding;

/// <summary>
/// API controller for managing Addresses.
/// </summary>
[ApiExplorerSettings(GroupName = "Bidding")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class AddressController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for AddressController
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public AddressController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_BIDDING")}/api/Address");
    }

    /// <summary>
    ///  Get all Addresses from the Bidding service
    /// </summary>
    /// <returns> A list of Addresses </returns>
    /// <response code="200">Returns the list of Addresses</response>
    [HttpGet]
    public Task<IActionResult> GetAddresses()
        => serviceProxy.Get();

    /// <summary>
    /// Get an Address by Id from the Bidding service
    /// </summary>
    /// <returns> An Address </returns>
    /// <param name="id"> The Id of the Address to be retrieved </param>
    /// <response code="200">Returns the Address</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetAddress(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Post an Address to the Bidding service
    /// </summary>
    /// <returns> An Address </returns>
    /// <param name="requestModel"> The Address to be posted </param>
    /// <response code="201">Returns the newly created Address</response>
    [HttpPost]
    [Authorize(Roles = "Superuser,BiddingOperator,Bidder,Operator")]
    public Task<IActionResult> PostAddress(object requestModel)
        => serviceProxy.Post(requestModel);

    /// <summary>
    /// Patch an Address to the Bidding service
    /// </summary>
    /// <returns> An Address </returns>
    /// <param name="id"> The Id of the Address to be patched </param>
    /// <param name="requestModel"> The Address to be patched </param>
    /// <response code="204">Returns the patched Address</response>
    [HttpPatch("{id}")]
    [Authorize(Roles = "Superuser,BiddingOperator,Operator")]
    public Task<IActionResult> PatchAddress(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Delete an Address from the Bidding service
    /// </summary>
    /// <params name="id"> The Id of the Address to be deleted </params>
    /// <returns> A no content response </returns>
    /// <response code="204">Returns a no content response</response>
    /// <response code="404">Returns a not found response</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Superuser,BiddingOperator,Operator")]
    public Task<IActionResult> DeleteAddress(string id)
        => serviceProxy.Delete(id);
}
