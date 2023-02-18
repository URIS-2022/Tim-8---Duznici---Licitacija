using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Person.API.Data.Repository;
using Person.API.Entities;
using Person.API.Models;

namespace Person.API.Controllers;
/// <summary>
/// Controller for managing legal persons.
/// </summary>

[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class LegalPersonController : ControllerBase
{
    private readonly ILegalPersonRepository legalPersonRepository;
    private readonly IMapper mapper;
    /// <summary>
    /// Constructor for the LegalPersonController.
    /// </summary>
    /// <param name="legalPersonRepository">The repository for managing legal persons.</param>
    /// <param name="mapper">The mapper for mapping between domain models and DTOs.</param>
    public LegalPersonController(ILegalPersonRepository legalPersonRepository, IMapper mapper)
    {
        this.legalPersonRepository = legalPersonRepository;
        this.mapper = mapper;
    }
    /// <summary>
    /// Returns a list of all legal persons.
    /// </summary>
    /// <returns>A collection of legal persons.</returns>
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
    /// <summary>
    /// Returns an legal person with the specified id.
    /// </summary>
    /// <param name="legalPersonGuid">The ID of the legal person to get.</param>
    /// <returns>The legal person with the specified ID, or NotFound if no such legal person exists.</returns>
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
    /// <summary>
    /// Updates an legal person with the specified id.
    /// </summary>
    /// <param name="id">The ID of the legal person to update.</param>
    /// <param name="patchModel">The legal person information to update.</param>
    /// <returns>The updated legal person, or NotFound if no such legal person exists, or BadRequest if the update fails.</returns>

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

    /// <summary>
    /// Creates a new legal person.
    /// </summary>
    /// <param name="requestLegalPerson">The information for the new legal person.</param>
    /// <returns>The newly created legal person, or BadRequest if the legal person creation fails.</returns>
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
    /// <summary>
    /// Deletes the legal person with the specified id.
    /// </summary>
    /// <param name="id">The ID of the legal person to delete.</param>
    /// <returns>NoContent if the legal person is deleted successfully, or NotFound if no such legal person exists.</returns>

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