using Gateway.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Person;
/// <summary>
/// Controller for managing legal persons.
/// </summary>
[ApiExplorerSettings(GroupName = "Person")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class LegalPersonsController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;
    /// <summary>
    /// Constructor for the LegalPersonController.
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public LegalPersonsController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_PERSON")}/api/LegalPerson");
    }
    /// <summary>
    /// Returns a list of all legal persons.
    /// </summary>
    /// <returns>A collection of legal persons.</returns>
    /// <response code="200">Ok if the Legal Persons are successfully retrieved</response>
    [HttpGet]
    public Task<IActionResult> GetLegalPersons()
        => serviceProxy.Get();

    /// <summary>
    /// Returns an legal person with the specified id.
    /// </summary>
    /// <param name="id">The ID of the legal person to get.</param>
    /// <returns>The legal person with the specified ID, or NotFound if no such legal person exists.</returns>
    /// <response code="200">Ok if the Legal Person is successfully retrieved</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetLegalPerson(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Updates an legal person with the specified id.
    /// </summary>
    /// <param name="id">The ID of the legal person to update.</param>
    /// <param name="requestModel">The legal person information to update.</param>
    /// <returns>The updated legal person, or NotFound if no such legal person exists, or BadRequest if the update fails.</returns>
    /// <response code="204"> NoContent if the Legal Person is successfully updated</response>
    [HttpPatch("{id}")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> PatchLegalPerson(string id, object requestModel)
    => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Creates a new legal person.
    /// </summary>
    /// <param name="requestModel"> The legal person information to create.</param>
    /// <returns> The created legal person, or BadRequest if the creation fails.</returns>
    /// <response code="201">Created if the Legal Person is successfully created</response>
    [HttpPost]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> PostLegalPerson(object requestModel)
    => serviceProxy.Post(requestModel);

    /// <summary>
    /// Deletes a legal person object with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the legal person object to delete.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the delete operation.</returns>
    /// <response code="204">NoContent if the legal person is successfully deleted</response>
    /// <response code="404">If the legal person is not found</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> DeleteLegalPerson(string id)
        => serviceProxy.Delete(id);
}