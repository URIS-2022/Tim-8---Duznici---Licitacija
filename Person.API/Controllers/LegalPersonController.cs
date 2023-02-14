using Person.API.Data.Repository;
using Person.API.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Person.API.Models;

namespace Person.API.Controllers;


[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class LegalPersonController : ControllerBase
{
    private readonly ILegalPersonRepository legalPersonRepository;
    private readonly IMapper mapper;

    public LegalPersonController(ILegalPersonRepository legalPersonRepository, IMapper mapper)
    {
        this.legalPersonRepository = legalPersonRepository;
        this.mapper = mapper;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<LegalPerson?>>> GetLegalPersons()
    {
        var legalPersons = await legalPersonRepository.GetAllLegalPersons();
        if (!legalPersons.Any())
        {
            return NoContent();
        }
        IEnumerable<LegalPerson> responseModels = mapper.Map<IEnumerable<LegalPerson>>(legalPersons);
        return Ok(responseModels);
    }

    [HttpGet("{legalPersonGuid}")]
    public async Task<ActionResult<LegalPersonResponseModel>> GetLegalPerson(Guid legalPersonGuid)
    {
        var legalPerson = await legalPersonRepository.GetLegalPersonByGuid(legalPersonGuid);
        if (legalPerson == null)
        {
            return NotFound();
        }
        var responseModel = mapper.Map<LegalPersonResponseModel>(legalPerson);
        return responseModel;
    }


    [HttpPatch("{id}")]
    public async Task<ActionResult<LegalPersonResponseModel>> PatchLegalPerson(Guid id, [FromBody] LegalPersonRequestModel patchModel)
    {
        var person = await legalPersonRepository.GetLegalPersonByGuid(id);
        if (person == null)
        {
            return NotFound();
        }

        mapper.Map(patchModel, person);

        var updated = await legalPersonRepository.UpdateLegalPerson(id, person);
        if (updated == null)
        {
            return BadRequest();
        }

        var responseModel = mapper.Map<LegalPersonResponseModel>(updated);

        return Ok(responseModel);
    }


    [HttpPost]
    public async Task<ActionResult<LegalPersonResponseModel>> PostLegalPerson(LegalPersonRequestModel requestLegalPerson)
    {
        LegalPerson legalPerson = mapper.Map<LegalPerson>(requestLegalPerson);
        LegalPerson? createdLegalPerson = await legalPersonRepository.CreateLegalPerson(legalPerson);
        if (createdLegalPerson == null)
        {
            return BadRequest();
        }
        LegalPersonResponseModel responseModel = mapper.Map<LegalPersonResponseModel>(createdLegalPerson);
        return CreatedAtAction("GetLegalPersons", new { name = responseModel.Name }, responseModel);
    }


    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteLegalPerson(Guid id)
    {
        var legalPerson = await legalPersonRepository.GetLegalPersonByGuid(id);
        if (legalPerson == null)
        {
            return NotFound();
        }
        await legalPersonRepository.DeleteLegalPerson(legalPerson.LegalPersonId);

        return NoContent();
    }
}