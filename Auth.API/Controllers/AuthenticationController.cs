using Auth.API.Models;
using Auth.API.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthenticationController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("authenticate")]
    public async Task<IActionResult> Authenticate([FromBody] SystemUser userParam)
    {
        SystemUser user = await _authService.Authenticate(userParam.UserName, userParam.Password);

        if (user == null)
        {
            return BadRequest(new { message = "Username or password is incorrect" });
        }

        JwtSecurityTokenHandler tokenHandler = new();
        byte[] key = Encoding.ASCII.GetBytes("H+MbQeThWmZq4t7w");
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new Claim[]
    {
        new Claim(ClaimTypes.Name, user.Id.ToString()),
        new Claim(ClaimTypes.Role, user.Role)
    }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        string tokenString = tokenHandler.WriteToken(token);

        return Ok(new
        {
            user.Id,
            user.UserName,
            user.Role,
            Token = tokenString
        });
    }
}

