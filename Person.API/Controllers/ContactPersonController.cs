using Person.API.Data.Repository;
using Person.API.Entities;
using Person.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Person.API.Controllers;


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

   

    [HttpPatch("{username}")]
    public async Task<IActionResult> PatchContactPerson(string firstName, ContactPersonUpdateModel contactPersonUpdate)
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