using Gateway.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Person;

/// <summary>
/// API controller for managing Addresses.
/// </summary>
[ApiExplorerSettings(GroupName = "Person")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class AddressesController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;
    /// <summary>
    /// Constructor for the AddressController.
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public AddressesController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_PERSON")}/api/Address");
    }

    /// <summary>
    /// Returns a list of addresses.
    /// </summary>
    /// <returns>A collection of addresses.</returns>
    [HttpGet]
    public Task<IActionResult> GetAddresses()
        => serviceProxy.Get();

    /// <summary>
    /// Returns the address with the specified id.
    /// </summary>
    /// <param name="id">The ID of the address to get.</param>
    /// <returns>The address with the specified ID, or NotFound if no such address exists.</returns>
    /// <response code="200">Ok if the address is successfully retrieved</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetAddress(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Updates an address with the specified id.
    /// </summary>
    /// <param name="id">The ID of the address to update.</param>
    /// <param name="requestModel">The address information to update.</param>
    /// <returns>The updated address, or NotFound if no such address exists, or BadRequest if the update fails.</returns>
    /// <response code="204"> NoContent if the address is successfully updated</response>
    [HttpPatch("{id}")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> PatchAddress(string id, object requestModel)
    => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Creates a new address.
    /// </summary>
    /// <param name="requestModel">The information for the new address.</param>
    /// <returns>The newly created address, or BadRequest if the address creation fails.</returns>
    /// <response code="201">The newly created address</response>
    [HttpPost]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> PostAddress(object requestModel)
    => serviceProxy.Post(requestModel);

    /// <summary>
    /// Deletes an Address person with the specified id.
    /// </summary>
    /// <param name="id">The ID of the Address to delete.</param>
    /// <returns>NoContent if the Address is deleted successfully, or NotFound if no such Address exists.</returns>
    /// <response code="204">NoContent if the Address is deleted successfully</response>
    /// <response code="404">NotFound if no such Address exists</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> DeleteAddress(string id)
        => serviceProxy.Delete(id);
}