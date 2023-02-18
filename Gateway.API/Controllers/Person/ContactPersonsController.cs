using Gateway.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Person;
/// <summary>
/// Controller for managing contact persons.
/// </summary>
[ApiExplorerSettings(GroupName = "Person")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class ContactPersonsController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for the ContactPersonController.
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public ContactPersonsController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_PERSON")}/api/ContactPerson");
    }

    /// <summary>
    /// Returns a list of all contact persons.
    /// </summary>
    /// <returns>A collection of contact persons.</returns>
    /// <response code="200">Ok if the contact persons are successfully retrieved</response>
    [HttpGet]
    public Task<IActionResult> GetContactPersons()
        => serviceProxy.Get();

    /// <summary>
    /// Returns an contact person with the specified id.
    /// </summary>
    /// <param name="id">The ID of the contact person to get.</param>
    /// <returns>The contact person with the specified ID, or NotFound if no such contact person exists.</returns>
    /// <response code="200">Ok if the contact person is successfully retrieved</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetContactPerson(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Updates an contact person with the specified id.
    /// </summary>
    /// <param name="id">The ID of the contact person to update.</param>
    /// <param name="requestModel">The contact person information to update.</param>
    /// <returns>The updated contact person, or NotFound if no such contact person exists, or BadRequest if the update fails.</returns>
    /// <response code="204"> NoContent if the contact person is successfully updated</response>
    [HttpPatch("{id}")]
    public Task<IActionResult> PatchContactPerson(string id, object requestModel)
    => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Creates a new contact person.
    /// </summary>
    /// <param name="requestModel">The information for the new contact person.</param>
    /// <returns>The newly created contact person, or BadRequest if the contact person creation fails.</returns>
    /// <response code="201">Created if the contact person is successfully created</response>
    [HttpPost]
    public Task<IActionResult> PostContactPerson(object requestModel)
    => serviceProxy.Post(requestModel);

    /// <summary>
    /// Deletes the contact person with the specified id.
    /// </summary>
    /// <param name="id">The ID of the contact person to delete.</param>
    /// <returns>NoContent if the contact person is deleted successfully, or NotFound if no such contact person exists.</returns>
    /// <response code="204">NoContent if the contact person is deleted successfully</response>
    /// <response code="404">NotFound if no such contact person exists</response>
    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteContactPerson(string id)
        => serviceProxy.Delete(id);
}