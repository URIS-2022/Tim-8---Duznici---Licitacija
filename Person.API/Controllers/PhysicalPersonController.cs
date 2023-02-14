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

    [HttpGet("{PhysicalPersonGuid}")]
    public async Task<ActionResult<PhysicalPersonResponseModel>> GetPhysicalPerson(Guid PhysicalPersonGuid)
    {
        var person = await physicalPersonRepository.GetPhysicalPersonByGuid(PhysicalPersonGuid);
        if (person == null)
        {
            return NotFound();
        }
        var responseModel = mapper.Map<PhysicalPersonResponseModel>(person);
        return responseModel;
    }

    [HttpPatch("{id}")]
    public async Task<ActionResult<PhysicalPersonResponseModel>> PatchPhysicalPerson(Guid id, [FromBody] PhysicalPersonRequestModel patchModel)
    {
        var person = await physicalPersonRepository.GetPhysicalPersonByGuid(id);
        if (person == null)
        {
            return NotFound();
        }

        mapper.Map(patchModel, person);

        var updated = await physicalPersonRepository.UpdatePhysicalPerson(id, person);
        if (updated == null)
        {
            return BadRequest();
        }

        var responseModel = mapper.Map<PhysicalPersonResponseModel>(updated);

        return Ok(responseModel);
    }


    [HttpPost]
    public async Task<ActionResult<PhysicalPersonResponseModel>> PostPhysicalPerson(PhysicalPersonRequestModel requestPhysicalPerson)
    {
        PhysicalPerson physicalPerson = mapper.Map<PhysicalPerson>(requestPhysicalPerson);
        PhysicalPerson? createdPhysicalPerson = await physicalPersonRepository.CreatePhysicalPerson(physicalPerson);
        if (physicalPerson == null)
        {
            return BadRequest();
        }
        PhysicalPersonResponseModel responseModel = mapper.Map<PhysicalPersonResponseModel>(createdPhysicalPerson);
        return CreatedAtAction("GetPhysicalPersons", new { firstname = responseModel.FirstName }, responseModel);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePhysicalPerson(Guid id)
    {
        var physicalPerson = await physicalPersonRepository.GetPhysicalPersonByGuid(id);
        if (physicalPerson == null)
        {
            return NotFound();
        }
        await physicalPersonRepository.DeletePhysicalPerson(physicalPerson.PhysicalPersonId);

        return NoContent();
    }
}