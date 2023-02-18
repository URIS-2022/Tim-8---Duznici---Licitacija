using Gateway.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Lease;

/// <summary>
/// API controller for managing Lease Agreement.
/// </summary>
[ApiExplorerSettings(GroupName = "Lease")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class LeaseAgreementsController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for Lease Agreements
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public LeaseAgreementsController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_LEASE")}/api/LeaseAgreement");
    }

    /// <summary>
    /// Returns a list of lease agreements.
    /// </summary>
    /// <returns> A list of LeaseAgreementGetResponseModel, or No Content if no lease agreement is found.</returns>
    /// <response code="200">Ok if the Lease Agreements are successfully retrieved</response>
    [HttpGet]
    public Task<IActionResult> GetLeaseAgreement()
        => serviceProxy.Get();

    /// <summary>
    /// Returns the lease agreement with the specified id.
    /// </summary>
    /// <param name="id"> The ID of the lease agreement.</param>
    /// <returns> The LeaseAgreementGetResponseModel with the specified id, or NotFound if the lease agreement is not found.</returns>
    /// <response code="200">Ok if the Lease Agreement is successfully retrieved</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetLeaseAgreement(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Updates the lease agreement with the specified id.
    /// </summary>
    /// <param name="id"> The ID of the lease agreement to update.</param>
    /// <param name="requestModel"> The LeaseAgreementPatchRequestModel with the updated values.</param>
    /// <returns> The LeaseAgreementPatchResponseModel with the updated values, or NotFound if the lease agreement is not found.</returns>
    /// <response code="200">Ok if the Lease Agreement is successfully updated</response>
    [HttpPatch("{guid}")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> PatchGuid(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Creates a new lease agreement.
    /// </summary>
    /// <param name="requestModel"> The LeaseAgreementPostRequestModel with the values for the new lease agreement.</param>
    /// <returns> The LeaseAgreementPostResponseModel with the values for the new lease agreement.</returns>
    /// <response code="201">Created if the lease agreement is successfully created</response>
    [HttpPost]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> PostLeaseAgreement(object requestModel)
        => serviceProxy.Post(requestModel);

    /// <summary>
    /// Deletes a lot object with the specified ID from the Lease Agreement.
    /// </summary>
    /// <param name="id">The ID of the Lease Agreement object to delete.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the delete operation.</returns>
    /// <response code="204">NoContent if the due date is successfully deleted</response>
    /// <response code="404">If the lot is not found</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> Delete(string id)
        => serviceProxy.Delete(id);
}