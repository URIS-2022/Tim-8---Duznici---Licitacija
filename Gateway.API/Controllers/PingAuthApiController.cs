using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Gateway.API.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PingAuthApiController : ControllerBase
    {
        [HttpGet(Name = "PingGetWeatherForecast")]
        public async Task<IActionResult> GetTestAsync()
        {
            using HttpClient httpClient = new();
            httpClient.DefaultRequestHeaders.Accept.Clear();
            httpClient.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
            string? endpoint = Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_AUTH_API");

            HttpResponseMessage response = await httpClient.GetAsync($"{endpoint}/WeatherForecast");

            if (response.IsSuccessStatusCode)
            {
                string content = await response.Content.ReadAsStringAsync();
                IEnumerable<WeatherForecast>? forecasts = JsonSerializer.Deserialize<IEnumerable<WeatherForecast>>(content);
                return Ok(forecasts);
            }
            else
            {
                string error = await response.Content.ReadAsStringAsync();
                return BadRequest(error);
            }

        }
    }
}
