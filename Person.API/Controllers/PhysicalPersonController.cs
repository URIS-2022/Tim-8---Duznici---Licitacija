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
public class PhysicalPersonController : ControllerBase
{
    private readonly IPhysicalPersonRepository physicalPersonRepository;
    private readonly IMapper mapper;

    public PhysicalPersonController(IPhysicalPersonRepository physicalPersonRepository, IMapper mapper)
    {
        this.physicalPersonRepository = physicalPersonRepository;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<PhysicalPerson?>>> GetPhysicalPersons()
    {
        var physicalPersons = await physicalPersonRepository.GetAllPhysicalPersons();
        if (!physicalPersons.Any())
        {
            return NoContent();
        }
        IEnumerable<PhysicalPerson> responseModels = mapper.Map<IEnumerable<PhysicalPerson>>(physicalPersons);
        return Ok(responseModels);
    }



    [HttpPatch("{firstname}")]
    public async Task<IActionResult> PatchPhysicalPerson(string name, PhysicalPersonUpdateModel physicalPersonUpdate)
    {
        var physicalPerson = await physicalPersonRepository.GetPhysicalPersonsByFirstName(name);
        if (physicalPerson == null || physicalPersonUpdate == null)
        {
            return BadRequest();
        }
        mapper.Map(physicalPersonUpdate, physicalPerson);

        await physicalPersonRepository.UpdatePhysicalPersons(physicalPerson);
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<PhysicalPersonResponseModel>> PostPhysicalPerson(PhysicalPersonRequestModel requestPhysicalPerson)
    {
        PhysicalPerson physicalPerson = mapper.Map<PhysicalPerson>(requestPhysicalPerson);
        PhysicalPerson? createdPhysicalPerson = await physicalPersonRepository.CreatePhysicalPersons(physicalPerson);
        if (physicalPerson == null)
        {
            return BadRequest();
        }
        PhysicalPersonResponseModel responseModel = mapper.Map<PhysicalPersonResponseModel>(createdPhysicalPerson);
        return CreatedAtAction("GetPhysicalPersons", new { firstname = responseModel.FirstName }, responseModel);
    }


    [HttpDelete("{firstname}")]
    public async Task<IActionResult> DeletePhysicalPerson(string firstName)
    {
        PhysicalPerson? physicalPerson = await physicalPersonRepository.GetPhysicalPersonsByFirstName(firstName);
        if (physicalPerson == null)
        {
            return NotFound();
        }
        await physicalPersonRepository.DeletePhysicalPersons(physicalPerson.PhysicalPersonId);

        return NoContent();
    }
}