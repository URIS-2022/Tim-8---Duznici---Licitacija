using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace Auth.API.Controllers;

[ApiController]
[Route("[controller]")]
public class PingAuthDbController : ControllerBase
{
    private readonly string? _connectionString;

    public PingAuthDbController(IConfiguration configuration)
    {
        _connectionString = configuration.GetConnectionString("DefaultConnection");
    }

    [HttpGet]
    public IActionResult GetTestConnection()
    {
        using SqlConnection connection = new(_connectionString);
        try
        {
            connection.Open();
            return Ok("Connection to SQL Server Successful!");
        }
        catch (SqlException e)
        {
            return StatusCode(500, "Error connecting to SQL Server: " + e.Message);
        }
    }
}

