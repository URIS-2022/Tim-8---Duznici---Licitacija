using Person.API.Data.Repository;
using Person.API.Entities;
using Person.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Person.API.Models.ContactPerson;

namespace Auth.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class ContactPersonController : ControllerBase
{
    private readonly IContactPersonRepository contactPersonRepository;
    private readonly IMapper mapper;

   
    public ContactPersonController(IContactPersonRepository contactPersonRepository, IMapper mapper)
    {
        this.contactPersonRepository = contactPersonRepository;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ContactPerson>>> GetContactPersons()
    {
        var contactPersons = await contactPersonRepository.GetAllContactPersons();
        if (!contactPersons.Any())
        {
            return NoContent();
        }
        IEnumerable<ContactPerson> responseModels = mapper.Map<IEnumerable<ContactPerson>>(contactPersons);
        return Ok(responseModels);
    }

   

    [HttpPatch("{username}")]
    public async Task<IActionResult> PutContactPerson(string firstName, ContactPersonUpdateModel contactPersonUpdate)
    {
        var contactPerson = await contactPersonRepository.GetContactPersonsByFirstName(firstName);
        if (contactPerson == null || contactPersonUpdate == null)
        {
            return BadRequest();
        }
        mapper.Map(contactPersonUpdate, contactPerson);

        await contactPersonRepository.UpdateContactPersons(contactPerson);
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<ContactPersonCreationModel>> PostContactPerson(ContactPerson ContactPerson)
    {
        ContactPerson requestedContactPerson = mapper.Map<ContactPerson>(ContactPerson);
        ContactPerson? createdContactPerson = await ContactPersonRepository.CreateContactPerson(ContactPerson);
        if (ContactPerson == null)
        {
            return BadRequest();
        }
        ContactPersonCreationModel responseModel = mapper.Map<ContactPersonCreationModel>(createdContactPerson);
        return CreatedAtAction("GetSystemUser", new { username = responseModel.FirstName }, responseModel);
    }

   
    [HttpDelete("{firstname}")]
    public async Task<IActionResult> DeleteContactPerson (string firstname)
    {
        ContactPerson? contactPerson = await contactPersonRepository.GetContactPersonsByFirstName(firstname);
        if (contactPerson == null)
        {
            return NotFound();
        }
        await contactPersonRepository.DeleteContactPersons(contactPerson.ContactPersonId);

        return NoContent();
    }
}