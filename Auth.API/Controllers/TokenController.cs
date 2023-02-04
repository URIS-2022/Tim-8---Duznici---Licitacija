using Auth.API.Models;
using Auth.API.Services;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IAuthService authService;
    private readonly IMapper mapper;

    public TokenController(IAuthService authService, IMapper mapper)
    {
        this.authService = authService;
        this.mapper = mapper;
    }

    [HttpPost("generate")]
    public async Task<IActionResult> GenerateToken([FromBody] JwtTokenRequestModel userParam)
    {
        SystemUser user = await authService.GetSystemUserByCredentials(userParam.Username, userParam.Password);

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
                new Claim(ClaimTypes.Role, user.Role.ToString())
            }),
            Expires = DateTime.UtcNow.AddDays(7),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

        JwtTokenResponseModel response = new(
            token: tokenHandler.WriteToken(token),
            expiresIn: ((int)(tokenDescriptor.Expires - DateTime.UtcNow).Value.TotalSeconds),
            issuedAt: DateTime.UtcNow
            );

        return Ok(response);
    }
    [HttpPost("introspection")]
    public async Task<IActionResult> IntrospectToken([FromBody] IntrospectionRequestModel requestModel)
    {
        var handler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("H+MbQeThWmZq4t7w")),
            ValidateIssuer = false,
            ValidateAudience = false
        };

        var claimsPrincipal = handler.ValidateToken(requestModel.Token, validationParameters, out _);

        var nameClaim = claimsPrincipal.FindFirst(ClaimTypes.Name);
        if (nameClaim == null)
        {
            return BadRequest("JWT Claims are not valid");
        }

        SystemUser systemUser = await authService.GetSystemUserByGuid(Guid.Parse(nameClaim.Value));

        var response = mapper.Map<SystemUserResponseModel>(systemUser);

        return Ok(response);
    }
}

