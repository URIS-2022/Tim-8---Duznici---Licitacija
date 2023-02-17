using Auth.API.Data.Repository;
using Auth.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Auth.API.Controllers;

/// <summary>
/// TokenController class is responsible for generating and introspecting JWT tokens.
/// </summary>
[Route("api/[controller]")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly ISystemUserRepository systemUserRepository;
    private readonly IMapper mapper;

    /// <summary>
    /// Constructor for TokenController class.
    /// </summary>
    /// <param name="systemUserRepository">Reference to ISystemUserRepository instance.</param>
    /// <param name="mapper">Reference to IMapper instance.</param>
    public TokenController(ISystemUserRepository systemUserRepository, IMapper mapper)
    {
        this.systemUserRepository = systemUserRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Generates JWT token based on the given username and password.
    /// </summary>
    /// <param name="userParam">Model containing username and password.</param>
    /// <returns>JWT token response model if the authentication is successful, otherwise returns Bad Request.</returns>
    [HttpPost("generate")]
    public async Task<IActionResult> GenerateToken([FromBody] JwtTokenRequestModel userParam)
    {
        userParam.Password = BCrypt.Net.BCrypt.HashPassword(userParam.Password, Environment.GetEnvironmentVariable("BCRYPT_SALT"));
        var user = await systemUserRepository.GetByCredentials(userParam.Username, userParam.Password);

        if (user == null)
        {
            return BadRequest(new { message = "Username or password is incorrect" });
        }

        JwtSecurityTokenHandler tokenHandler = new();
        byte[] key = Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_ENCRYPT_KEY") ?? "null");
        SecurityTokenDescriptor tokenDescriptor = new()
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, user.Guid.ToString()),
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

    /// <summary>
    /// Introspects the given JWT token.
    /// </summary>
    /// <param name="requestModel">Model containing the token to be introspected.</param>
    /// <returns>SystemUserResponseModel if the token is valid, otherwise returns Bad Request.</returns>
    [HttpPost("introspection")]
    public async Task<IActionResult> IntrospectToken([FromBody] IntrospectionRequestModel requestModel)
    {
        var handler = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters
        {
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Environment.GetEnvironmentVariable("JWT_ENCRYPT_KEY") ?? "null")),
            ValidateIssuer = false,
            ValidateAudience = false
        };

        var claimsPrincipal = handler.ValidateToken(requestModel.Token, validationParameters, out _);

        var nameClaim = claimsPrincipal.FindFirst(ClaimTypes.Name);
        if (nameClaim == null)
        {
            return BadRequest("JWT Claims are not valid");
        }

        var systemUser = await systemUserRepository.GetByGuid(Guid.Parse(nameClaim.Value));
        if (systemUser == null)
        {
            return BadRequest();
        }

        var response = mapper.Map<SystemUserResponseModel>(systemUser);

        return Ok(response);
    }
}

