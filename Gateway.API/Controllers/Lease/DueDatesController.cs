using Gateway.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Lease;

/// <summary>
/// API controller for managing DueDate.
/// </summary>
[ApiExplorerSettings(GroupName = "Lease")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class DueDatesController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for Due Dates
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public DueDatesController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_LEASE")}/api/DueDate");
    }

    /// <summary>
    /// Returns a list of due dates.
    /// </summary>
    /// <returns> A list of DueDateGetResponseModel, or No Content if no due date is found.</returns>
    /// <response code="200">Ok if the Due Dates are successfully retrieved</response>
    [HttpGet]
    public Task<IActionResult> GetDueDate()
        => serviceProxy.Get();

    /// <summary>
    /// Returns the due date with the specified id.
    /// </summary>
    /// <param name="id"> The ID of the due date.</param>
    /// <returns> The DueDateGetResponseModel with the specified id, or NotFound if the due date is not found.</returns>
    /// <response code="200">Ok if the Due Date is successfully retrieved</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetDueDate(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Updates the due date with the specified id.
    /// </summary>
    /// <param name="id"> The ID of the due date to update.</param>
    /// <param name="requestModel"> The DueDatePatchRequestModel with the updated values.</param>
    /// <returns> The DueDatePatchResponseModel with the updated values, or NotFound if the due date is not found.</returns>
    /// <response code="200">Ok if the Due Date is successfully updated</response>
    [HttpPatch("{id}")]
    public Task<IActionResult> PatchGuid(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Creates a new due date.
    /// </summary>
    /// <param name="requestModel"> The DueDatePostRequestModel with the values for the new due date.</param>
    /// <returns> The DueDatePostResponseModel with the values for the new due date.</returns>
    /// <response code="201">Created if the due date is successfully created</response>
    [HttpPost]
    public Task<IActionResult> PostDueDate(object requestModel)
        => serviceProxy.Post(requestModel);

    /// <summary>
    /// Deletes a lot object with the specified ID from the due date.
    /// </summary>
    /// <param name="id">The ID of the due date object to delete.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the delete operation.</returns>
    /// <response code="204">NoContent if the due date is successfully deleted</response>
    /// <response code="404">If the lot is not found</response>
    [HttpDelete("{id}")]
    public Task<IActionResult> Delete(string id)
        => serviceProxy.Delete(id);
}