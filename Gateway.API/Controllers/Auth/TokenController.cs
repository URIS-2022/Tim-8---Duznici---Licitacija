using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Auth;

[ApiExplorerSettings(GroupName = "Auth")]
[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    HttpServiceProxy serviceProxy;
    public TokenController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_AUTH")}/api/Token");
    }

    /// <summary>
    /// Generates JWT token based on the given username and password.
    /// </summary>
    /// <param name="userParam">Model containing username and password.</param>
    /// <returns>JWT token response model if the authentication is successful, otherwise returns Bad Request.</returns>
    [HttpPost("generate")]
    public Task<IActionResult> GenerateToken(object userParam) => serviceProxy.Post(userParam, endpoint: "generate");

    /// <summary>
    /// Introspects the given JWT token.
    /// </summary>
    /// <param name="requestModel">Model containing the token to be introspected.</param>
    /// <returns>SystemUserResponseModel if the token is valid, otherwise returns Bad Request.</returns>
    [HttpPost("introspection")]
    public Task<IActionResult> IntrospectToken(object requestModel) => serviceProxy.Post(requestModel, endpoint: "introspection");
}
