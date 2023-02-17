using Gateway.API.Helpers;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Auth;

/// <summary>
/// Controller for managing JWT resources
/// </summary>
[ApiExplorerSettings(GroupName = "Auth")]
[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for TokenController
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
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
