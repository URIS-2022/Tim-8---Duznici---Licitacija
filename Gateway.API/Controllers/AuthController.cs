﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http.Headers;
using System.Text.Json;

namespace Gateway.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{

    [HttpGet("WeatherForecast")]
    [Authorize(Roles = "Admin")]
    public async Task<IActionResult> GetWeatherForecast()
    {
        using HttpClient httpClient = new();
        string? endpoint = Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_AUTH_API");
        httpClient.DefaultRequestHeaders.Accept.Clear();
        httpClient.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
        HttpResponseMessage response = await httpClient.GetAsync($"{endpoint}/WeatherForecast");
        if (!response.IsSuccessStatusCode)
        {
            return BadRequest();
        }
        if (response.IsSuccessStatusCode)
        {
            string content = await response.Content.ReadAsStringAsync();
            IEnumerable<object>? forecasts = JsonSerializer.Deserialize<IEnumerable<object>>(content);
            return Ok(forecasts);
        }
        else
        {
            string error = await response.Content.ReadAsStringAsync();
            return BadRequest(error);
        }
    }
}
