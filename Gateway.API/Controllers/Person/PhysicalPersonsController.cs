using Gateway.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Person;
/// <summary>
/// Controller for managing physical persons.
/// </summary>
[ApiExplorerSettings(GroupName = "Person")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class PhysicalPersonsController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for the PhysicalPersonController.
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public PhysicalPersonsController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_PERSON")}/api/PhysicalPerson");
    }

    /// <summary>
    /// Returns a list of all physical persons.
    /// </summary>
    /// <returns>A collection of physical persons.</returns>
    /// <response code="200">Ok if the physical persons are successfully retrieved</response>
    [HttpGet]
    public Task<IActionResult> GetPhysicalPersons()
        => serviceProxy.Get();

    /// <summary>
    /// Returns an physical person with the specified id.
    /// </summary>
    /// <param name="id">The ID of the physical person.</param>
    /// <returns>The physical person with the specified id, or NotFound if the physical person is not found.</returns>
    /// <response code="200">Ok if the physical person is successfully retrieved</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetPhysicalPerson(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Updates an physical person with the specified id.
    /// </summary>
    /// <param name="id">The ID of the physical person to update.</param>
    /// <param name="requestModel">The physical person information to update.</param>
    /// <returns>The updated physical person, or NotFound if no such physical person exists, or BadRequest if the update fails.</returns>
    /// <response code="200">Ok if the physical person is successfully updated</response>
    [HttpPatch("{id}")]
    [Authorize(Roles = "Superuser,BiddingOperator,TechSecretary")]
    public Task<IActionResult> PatchPhysicalPerson(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Creates a new physical person.
    /// </summary>
    /// <param name="id">The ID of the physical person to create.</param>
    /// <param name="requestModel">The physical person information to create.</param>
    /// <returns>The created physical person, or BadRequest if the creation fails.</returns>
    /// <response code="201">Created if the physical person is successfully created</response>
    [HttpPost]
    [Authorize(Roles = "Superuser,BiddingOperator,TechSecretary")]
    public Task<IActionResult> PostPhysicalPerson(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Deletes a physical person object with the specified ID from the Buyers.
    /// </summary>
    /// <param name="id">The ID of the physical person object to delete.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the delete operation.</returns>
    /// <response code="204">NoContent if the physical person is successfully deleted</response>
    /// <response code="404">If the physical person is not found</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Superuser,BiddingOperator,TechSecretary")]
    public Task<IActionResult> DeletePhysicalPerson(string id)
        => serviceProxy.Delete(id);
}