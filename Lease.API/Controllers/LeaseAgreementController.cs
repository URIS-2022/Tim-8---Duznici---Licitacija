using AutoMapper;
using Lease.API.Data.Repository;
using Lease.API.Models.LeaseAgreementModels;
using Microsoft.AspNetCore.Mvc;

namespace Lease.API.Controllers;

[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class LeaseAgreementController : ControllerBase
{
    private readonly ILeaseAgreementRepository _LeaseAgreementRepository;
    private readonly IMapper mapper;

    public LeaseAgreementController(ILeaseAgreementRepository LeaseAgreementRepository, IMapper mapper)
    {
        _LeaseAgreementRepository = LeaseAgreementRepository;
        this.mapper = mapper;

    }

    // GET: api/LeaseAgreements
    [HttpGet]
    public async Task<ActionResult<IEnumerable<LeaseAgreementGetResponseModel>>> GetLeaseAgreement()
    {

        var LeaseAgreements = await _LeaseAgreementRepository.GetAll();
        if (!LeaseAgreements.Any())
        {
            return NoContent();
        }
        var responseModel = mapper.Map<IEnumerable<LeaseAgreementGetResponseModel>>(LeaseAgreements);


        return Ok(responseModel);
    }

    // GET: api/LeaseAgreements/5
    [HttpGet("{id}")]
    public async Task<ActionResult<LeaseAgreementGetResponseModel>> GetLeaseAgreement(Guid id)
    {
        var LeaseAgreement = await _LeaseAgreementRepository.GetByGuid(id);
        if (LeaseAgreement == null)
        {
            return NotFound();
        }
        var responseModel = mapper.Map<LeaseAgreementGetResponseModel>(LeaseAgreement);
        return responseModel;
    }

    // PATCH: api/LeaseAgreements/5
    [HttpPatch("{guid}")]
    public async Task<ActionResult<LeaseAgreementPatchResponseModel>> PatchGuid(Guid guid, [FromBody] LeaseAgreementPatchRequestModel patchModel)
    {
        if (patchModel.PersonGuid != null)
        {
            var personApiClient = new HttpClient();
            var personApiUrl = Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_PERSON");


            var legalPersonResponse = await personApiClient.GetAsync($"{personApiUrl}/api/LegalPerson/{patchModel.PersonGuid}");
            var physicalPersonResponse = await personApiClient.GetAsync($"{personApiUrl}/api/PhysicalPerson/{patchModel.PersonGuid}");
            if (!legalPersonResponse.IsSuccessStatusCode && !physicalPersonResponse.IsSuccessStatusCode)
            {
                return BadRequest("Person not found.");
            }
        }

        var LeaseAgreement = await _LeaseAgreementRepository.GetByGuid(guid);
        if (LeaseAgreement == null)
        {
            return NotFound();
        }

        mapper.Map(patchModel, LeaseAgreement);

        var updated = await _LeaseAgreementRepository.Update(LeaseAgreement);
        if (updated == null)
        {
            return BadRequest();
        }

        var responseModel = mapper.Map<LeaseAgreementPatchResponseModel>(updated);

        return Ok(responseModel);
    }

    // POST: api/LeaseAgreements
    [HttpPost]
    public async Task<ActionResult<LeaseAgreementPostResponseModel>> PostLeaseAgreement(LeaseAgreementPostRequestModel postModel)
    {
        var personApiClient = new HttpClient();
        var personApiUrl = Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_PERSON");


        var legalPersonResponse = await personApiClient.GetAsync($"{personApiUrl}/api/LegalPerson/{postModel.PersonGuid}");
        var physicalPersonResponse = await personApiClient.GetAsync($"{personApiUrl}/api/PhysicalPerson/{postModel.PersonGuid}");
        if (!legalPersonResponse.IsSuccessStatusCode && !physicalPersonResponse.IsSuccessStatusCode)
        {
            return BadRequest("Person not found.");
        }

        var LeaseAgreement = mapper.Map<Entities.LeaseAgreement>(postModel);
        Entities.LeaseAgreement? created = await _LeaseAgreementRepository.Add(LeaseAgreement);
        if (created == null)
        {
            return BadRequest();
        }
        var responseModel = mapper.Map<LeaseAgreementPostResponseModel>(created);
        return CreatedAtAction("GetLeaseAgreement", new { id = created.Guid }, responseModel);
    }

    // DELETE: api/LeaseAgreements/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        var LeaseAgreement = await _LeaseAgreementRepository.GetByGuid(id);
        if (LeaseAgreement == null)
        {
            return NotFound();
        }
        await _LeaseAgreementRepository.Delete(LeaseAgreement.Guid);

        return NoContent();
    }
}