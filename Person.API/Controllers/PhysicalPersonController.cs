using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Person.API.Data.Repository;
using Person.API.Entities;
using Person.API.Models;

namespace Person.API.Controllers;
/// <summary>
/// Controller for managing physical persons.
/// </summary>

[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class PhysicalPersonController : ControllerBase
{
    private readonly IPhysicalPersonRepository physicalPersonRepository;
    private readonly IMapper mapper;
    /// <summary>
    /// Constructor for the PhysicalPersonController.
    /// </summary>
    /// <param name="physicalPersonRepository">The repository for managing physical persons.</param>
    /// <param name="mapper">The mapper for mapping between domain models and DTOs.</param>
    public PhysicalPersonController(IPhysicalPersonRepository physicalPersonRepository, IMapper mapper)
    {
        this.physicalPersonRepository = physicalPersonRepository;
        this.mapper = mapper;
    }
    /// <summary>
    /// Returns a list of all physical persons.
    /// </summary>
    /// <returns>A collection of physical persons.</returns>
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
    /// <summary>
    /// Returns an physical person with the specified id.
    /// </summary>
    /// <param name="PhysicalPersonGuid">The ID of the physical person to get.</param>
    /// <returns>The physical person with the specified ID, or NotFound if no such physical person exists.</returns>
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
    /// <summary>
    /// Updates an physical person with the specified id.
    /// </summary>
    /// <param name="id">The ID of the physical person to update.</param>
    /// <param name="patchModel">The physical person information to update.</param>
    /// <returns>The updated physical person, or NotFound if no such physical person exists, or BadRequest if the update fails.</returns>
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
    /// <summary>
    /// Creates a new physical person.
    /// </summary>
    /// <param name="requestPhysicalPerson">The information for the new physical person.</param>
    /// <returns>The newly created physical person, or BadRequest if the physical person creation fails.</returns>

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
    /// <summary>
    /// Deletes the physical person with the specified id.
    /// </summary>
    /// <param name="id">The ID of the physical person to delete.</param>
    /// <returns>NoContent if the physical person is deleted successfully, or NotFound if no such physical person exists.</returns>

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