using Person.API.Data.Repository;
using Person.API.Entities;
using Person.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Person.API.Controllers;
/// <summary>
/// Controller for managing contact persons.
/// </summary>

[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class ContactPersonController : ControllerBase
{
    private readonly IContactPersonRepository contactPersonRepository;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor for the ContactPersonController.
    /// </summary>
    /// <param name="contactPersonRepository">The repository for managing contact persons.</param>
    /// <param name="mapper">The mapper for mapping between domain models and DTOs.</param>
    public ContactPersonController(IContactPersonRepository contactPersonRepository, IMapper mapper)
    {
        this.contactPersonRepository = contactPersonRepository;
        this.mapper = mapper;
    }
    /// <summary>
    /// Gets all contact persons.
    /// </summary>
    /// <returns>A collection of contact persons.</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContactPerson?>>> GetContactPersons()
    {
        var contactPersons = await contactPersonRepository.GetAllContactPersons();
        if (!contactPersons.Any())
        {
            return NoContent();
        }
        IEnumerable<ContactPerson> responseModels = mapper.Map<IEnumerable<ContactPerson>>(contactPersons);
        return Ok(responseModels);
    }
    /// <summary>
    /// Gets an contact person by its ID.
    /// </summary>
    /// <param name="ContactPersonGuid">The ID of the contact person to get.</param>
    /// <returns>The contact person with the specified ID, or NotFound if no such contact person exists.</returns>
    [HttpGet("{ContactPersonGuid}")]
    public async Task<ActionResult<ContactPersonResponseModel>> GetContactPerson(Guid ContactPersonGuid)
    {
        var person = await contactPersonRepository.GetContactPersonByGuid(ContactPersonGuid);
        if (person == null)
        {
            return NotFound();
        }
        var responseModel = mapper.Map<ContactPersonResponseModel>(person);
        return responseModel;
    }
    /// <summary>
    /// Updates an contact person with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the contact person to update.</param>
    /// <param name="patchModel">The contact person information to update.</param>
    /// <returns>The updated contact person, or NotFound if no such contact person exists, or BadRequest if the update fails.</returns>
    [HttpPatch("{id}")]
    public async Task<ActionResult<ContactPersonResponseModel>> PatchContactPerson(Guid id, [FromBody] ContactPersonRequestModel patchModel)
    {
        var person = await contactPersonRepository.GetContactPersonByGuid(id);
        if (person == null)
        {
            return NotFound();
        }

        mapper.Map(patchModel, person);

        var updated = await contactPersonRepository.UpdateContactPerson(id, person);
        if (updated == null)
        {
            return BadRequest();
        }

        var responseModel = mapper.Map<ContactPersonResponseModel>(updated);

        return Ok(responseModel);
    }
    /// <summary>
    /// Creates a new contact person.
    /// </summary>
    /// <param name="requestContactPerson">The information for the new contact person.</param>
    /// <returns>The newly created contact person, or BadRequest if the contact person creation fails.</returns>

    [HttpPost]
    public async Task<ActionResult<ContactPersonResponseModel>> PostContactPerson(ContactPersonRequestModel requestContactPerson)
    {
        ContactPerson contactPerson = mapper.Map<ContactPerson>(requestContactPerson);
        ContactPerson? createdContactPerson = await contactPersonRepository.CreateContactPerson(contactPerson);
        if (contactPerson == null)
        {
            return BadRequest();
        }
        ContactPersonResponseModel responseModel = mapper.Map<ContactPersonResponseModel>(createdContactPerson);
        return CreatedAtAction("GetContactPersons", new { firstname = responseModel.FirstName }, responseModel);
    }

    /// <summary>
    /// Deletes the contact person with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the contact person to delete.</param>
    /// <returns>NoContent if the contact person is deleted successfully, or NotFound if no such contact person exists.</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContactPerson (Guid id)
    {
        var contactPerson = await contactPersonRepository.GetContactPersonByGuid(id);
        if (contactPerson == null)
        {
            return NotFound();
        }
        await contactPersonRepository.DeleteContactPerson(contactPerson.ContactPersonId);

        return NoContent();
    }
}