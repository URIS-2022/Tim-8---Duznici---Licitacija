using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Auth;

[ApiExplorerSettings(GroupName = "Auth")]
[Route("api/[controller]")]
[ApiController]
public class SystemUsersController : ControllerBase
{
    HttpServiceProxy serviceProxy;
    public SystemUsersController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_AUTH")}/api/SystemUsers");
    }

    [HttpDelete("{username}")]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> DeleteSystemUser(string username) => serviceProxy.Delete(username);

    [HttpGet("{username}")]
    public Task<IActionResult> GetSystemUser(string username) => serviceProxy.GetById(username);

    [HttpGet]
    public Task<IActionResult> GetSystemUsers() => serviceProxy.Get();

    [HttpPost]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> PostSystemUser(object requestModel) => serviceProxy.Post(requestModel);

    [HttpPatch("{username}")]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> PatchSystemUser(string username, object systemUserUpdate) => serviceProxy.Patch(username, systemUserUpdate);
}
