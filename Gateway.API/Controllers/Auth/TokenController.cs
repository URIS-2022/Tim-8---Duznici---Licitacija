using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Auth;

[ApiExplorerSettings(GroupName = "Auth")]
[Route("api/v1/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly HttpClient _httpClient;
    public TokenController(IHttpClientFactory httpClientFactory)
    {
        _httpClient = httpClientFactory.CreateClient();
    }
    [HttpGet]
    public async Task<IActionResult> Auth()
        => await ProxyTo(Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_AUTH_API"));

    private async Task<ContentResult> ProxyTo(string url)
        => Content(await _httpClient.GetStringAsync(url));
}
