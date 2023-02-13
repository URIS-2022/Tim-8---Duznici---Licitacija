using Gateway.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Complaint;

/// <summary>
/// Controller for managing Complaints
/// </summary>
[ApiExplorerSettings(GroupName = "Complaint")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class ComplaintsController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for ComplaintController
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public ComplaintsController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_COMPLAINT")}/api/Complaints");
    }

    /// <summary>
    /// Deletes a complaint
    /// </summary>
    /// <param name="id">id of the complaint to be deleted</param>
    /// <returns>IActionResult indicating the status of the operation</returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> DeleteSystemUser(string id) => serviceProxy.Delete(id);

    /// <summary>
    /// Gets a complaint
    /// </summary>
    /// <param name="id">Id of the complaint to retrieve</param>
    /// <returns>IActionResult indicating the status of the operation</returns>
    [HttpGet("{id}")]
    public Task<IActionResult> GetComplaint(string id) => serviceProxy.GetById(id);

    /// <summary>
    /// Gets a list of all complaints
    /// </summary>
    /// <returns>IActionResult indicating the status of the operation</returns>
    [HttpGet]
    [Produces("application/json", "application/xml")]
    public Task<IActionResult> GetComplaints() => serviceProxy.Get();

    /// <summary>
    /// Adds a new complaint
    /// </summary>
    /// <param name="requestModel">Request body with complaint information</param>
    /// <returns>IActionResult indicating the status of the operation</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> PostComplaint(object requestModel) => serviceProxy.Post(requestModel);

    /// <summary>
    /// Patches a system user
    /// </summary>
    /// <param name="id">id of the user to update</param>
    /// <param name="requestModel">Request body with updated complaint information</param>
    /// <returns>IActionResult indicating the status of the operation</returns>
    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> PatchComplaint(string id, object requestModel) => serviceProxy.Patch(id, requestModel);
}
