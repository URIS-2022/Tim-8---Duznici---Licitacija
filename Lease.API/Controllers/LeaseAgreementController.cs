using Lease.API.Data.Repository;
using Lease.API.Models;
using Lease.API.Entities;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;

namespace Lease.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class LeaseAgreementsController : ControllerBase
{
    private readonly ILeaseAgreementRepository LeaseAgreementRepository;
    private readonly IMapper mapper;

    /// <summary>
    /// Initializes a new instance of the LeaseAgreementsController class
    /// </summary>
    /// <param name="LeaseAgreementRepository">An instance of ILeaseAgreementRepository to handle the System Users</param>
    /// <param name="mapper">An instance of IMapper to map between System User entities and models</param>
    public LeaseAgreementsController(ILeaseAgreementRepository LeaseAgreementRepository, IMapper mapper)
    {
        this.LeaseAgreementRepository = LeaseAgreementRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Returns a list of System Users
    /// </summary>
    /// <returns>A list of System User models, or No Content if no System User found</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeaseAgreementResponseModel>>> GetLeaseAgreements()
    {
        var LeaseAgreements = await LeaseAgreementRepository.GetAll();
        if (!LeaseAgreements.Any())
        {
            return NoContent();
        }
        IEnumerable<LeaseAgreementResponseModel> responseModels = mapper.Map<IEnumerable<LeaseAgreementResponseModel>>(LeaseAgreements);
        return Ok(responseModels);
    }

    /// <summary>
    /// Returns a specific System User based on the username
    /// </summary>
    /// <returns>The System User model, or Not Found if the System User is not found</returns>
    /// 
    [HttpGet("referenceNumber")]
    public async Task<ActionResult<LeaseAgreementResponseModel>> GetLeaseAgreement(string referenceNumber)
    {
        LeaseAgreement? LeaseAgreement = await LeaseAgreementRepository.GetByReferenceNumber(referenceNumber);
        if (LeaseAgreement == null)
        {
            return NotFound();
        }
        LeaseAgreementResponseModel responseModel = mapper.Map<LeaseAgreementResponseModel>(LeaseAgreement);
        return Ok(responseModel);
    }

    /// <summary>
    /// Updates a specific System User based on the username
    /// </summary>
    /// <param name="username">The username of the System User to update</param>
    /// <param name="LeaseAgreementUpdate">The updated System User information</param>
    /// <returns>No Content if the System User is updated successfully, or Bad Request if the System User or the update information is invalid</returns>
    [HttpPatch("{guid}")]
    public async Task<IActionResult> PutLeaseAgreement(Guid guid, LeaseAgreementUpdateModel LeaseAgreementUpdate)
    {
        var LeaseAgreement = await LeaseAgreementRepository.GetByGuid(guid);
        if (LeaseAgreement == null || LeaseAgreementUpdate == null)
        {
            return BadRequest();
        }
        mapper.Map(LeaseAgreementUpdate, LeaseAgreement);

        await LeaseAgreementRepository.Update(LeaseAgreement);
        return NoContent();
    }

    /// <summary>
    /// Creates a new System User
    /// </summary>
    /// <param name="requestModel">The new System User information</param>
    /// <returns>The created System User model, with a location header pointing to the URL of the newly created System User</returns>
    [HttpPost]
    public async Task<ActionResult<LeaseAgreementResponseModel>> PostLeaseAgreement(LeaseAgreementRequestModel requestModel)
    {
        LeaseAgreement requestedLeaseAgreement = mapper.Map<LeaseAgreement>(requestModel);
        LeaseAgreement createdLeaseAgreement = await LeaseAgreementRepository.Add(requestedLeaseAgreement);
        LeaseAgreementResponseModel responseModel = mapper.Map<LeaseAgreementResponseModel>(createdLeaseAgreement);
        return CreatedAtAction("GetLeaseAgreement", new { guid = responseModel.Guid }, responseModel);
    }

    /// <summary>
    /// Deletes a specific System User based on the username
    /// </summary>
    /// <param name="guid">The username of the System User to delete</param>
    /// <returns>No Content if the System User is deleted successfully, or Not Found if the System User is not found</returns>
    [HttpDelete("{guid}")]
    public async Task<IActionResult> DeleteLeaseAgreement(Guid guid)
    {
        LeaseAgreement? LeaseAgreement = await LeaseAgreementRepository.GetByGuid(guid);
        if (LeaseAgreement == null)
        {
            return NotFound();
        }
        await LeaseAgreementRepository.Delete(LeaseAgreement.Guid);

        return NoContent();
    }
}