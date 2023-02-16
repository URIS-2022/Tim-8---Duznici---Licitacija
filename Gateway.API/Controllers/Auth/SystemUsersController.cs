using Gateway.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Auth;

/// <summary>
/// Controller for managing System Users
/// </summary>
[ApiExplorerSettings(GroupName = "Auth")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class SystemUsersController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for SystemUsersController
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public SystemUsersController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_AUTH")}/api/SystemUsers");
    }

    /// <summary>
    /// Deletes a system user
    /// </summary>
    /// <param name="username">Username of the user to be deleted</param>
    /// <returns>IActionResult indicating the status of the operation</returns>
    [HttpDelete("{username}")]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> DeleteSystemUser(string username) => serviceProxy.Delete(username);

    /// <summary>
    /// Gets a system user
    /// </summary>
    /// <param name="username">Username of the user to retrieve</param>
    /// <returns>IActionResult indicating the status of the operation</returns>
    [HttpGet("{username}")]
    public Task<IActionResult> GetSystemUser(string username) => serviceProxy.GetById(username);

    /// <summary>
    /// Gets a list of all system users
    /// </summary>
    /// <returns>IActionResult indicating the status of the operation</returns>
    [HttpGet]
    [Produces("application/json", "application/xml")]
    public Task<IActionResult> GetSystemUsers() => serviceProxy.Get();

    /// <summary>
    /// Adds a new system user
    /// </summary>
    /// <param name="requestModel">Request body with user information</param>
    /// <returns>IActionResult indicating the status of the operation</returns>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> PostSystemUser(object requestModel) => serviceProxy.Post(requestModel);

    /// <summary>
    /// Patches a system user
    /// </summary>
    /// <param name="username">Username of the user to update</param>
    /// <param name="requestModel">Request body with updated user information</param>
    /// <returns>IActionResult indicating the status of the operation</returns>
    [HttpPatch("{username}")]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> PatchSystemUser(string username, object requestModel) => serviceProxy.Patch(username, requestModel);
}
