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

   
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteContactPerson (Guid id)
    {
        var contactPerson = await contactPersonRepository.GetContactPersonByGuid(id);
        if (contactPerson == null)
        {
            return NotFound();
        }
        await contactPersonRepository.DeleteContactPersons(contactPerson.ContactPersonId);

        return NoContent();
    }
}