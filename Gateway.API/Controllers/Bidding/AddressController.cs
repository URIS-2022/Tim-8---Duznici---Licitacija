using Gateway.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers;

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

    //Give me XML Comments for all of these methods
    /// <summary>
    ///  Get all Addresses from the Bidding service
    /// </summary>
    /// <returns> A list of Addresses </returns>
    [HttpGet]
    public Task<IActionResult> GetAddresses()
        => serviceProxy.Get();

    /// <summary>
    /// Get an Address by Id from the Bidding service
    /// </summary>
    /// <returns> An Address </returns>
    /// <param name="id"> The Id of the Address to be retrieved </param>
    [HttpGet("{id}")]
    public Task<IActionResult> GetAddress(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Post an Address to the Bidding service
    /// </summary>
    /// <returns> An Address </returns>
    [HttpPost]
    public Task<IActionResult> PostAddress(object requestModel)
        => serviceProxy.Post(requestModel);
    
    /// <summary>
    /// Patch an Address to the Bidding service
    /// </summary>
    /// <returns> An Address </returns>
    /// <param name="id"> The Id of the Address to be patched </param>
    [HttpPatch("{id}")]
    public Task<IActionResult> PatchAddress(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Delete an Address from the Bidding service
    /// </summary>
    /// <params name="id"> The Id of the Address to be deleted </params>
    /// <returns> A no content response </returns>
    /// <param name="id"> The Id of the Address to be deleted </param>
    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteAddress(string id)
        => serviceProxy.Delete(id);
}
