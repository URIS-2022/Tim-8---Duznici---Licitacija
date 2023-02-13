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



    [HttpPatch("{name}")]
    public async Task<IActionResult> PatchLegalPerson(string name, LegalPersonUpdateModel legalPersonUpdate)
    {
        var legalPerson = await legalPersonRepository.GetLegalPersonsByName(name);
        if (legalPerson == null || legalPersonUpdate == null)
        {
            return BadRequest();
        }
        mapper.Map(legalPersonUpdate, legalPerson);

        await legalPersonRepository.UpdateLegalPersons(legalPerson);
        return NoContent();
    }

    [HttpPost]
    public async Task<ActionResult<LegalPersonResponseModel>> PostLegalPerson(LegalPersonRequestModel requestLegalPerson)
    {
        LegalPerson legalPerson = mapper.Map<LegalPerson>(requestLegalPerson);
        LegalPerson? createdLegalPerson = await legalPersonRepository.CreateLegalPersons(legalPerson);
        if (legalPerson == null)
        {
            return BadRequest();
        }
        LegalPersonResponseModel responseModel = mapper.Map<LegalPersonResponseModel>(createdLegalPerson);
        return CreatedAtAction("GetLegalPersons", new { name = responseModel.Name }, responseModel);
    }


    [HttpDelete("{name}")]
    public async Task<IActionResult> DeleteLegalPerson(string name)
    {
        LegalPerson? legalPerson = await legalPersonRepository.GetLegalPersonsByName(name);
        if (legalPerson == null)
        {
            return NotFound();
        }
        await legalPersonRepository.DeleteLegalPersons(legalPerson.LegalPersonId);

        return NoContent();
    }
}