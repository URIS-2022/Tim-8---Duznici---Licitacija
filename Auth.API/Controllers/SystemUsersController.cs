using Auth.API.Data.Repository;
using Auth.API.Entities;
using Auth.API.Models;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers;

/// <summary>
/// SystemUsersController class provides REST API for handling System Users
/// </summary>
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class SystemUsersController : ControllerBase
{
    private readonly ISystemUserRepository systemUserRepository;
    private readonly IMapper mapper;

    /// <summary>
    /// Initializes a new instance of the SystemUsersController class
    /// </summary>
    /// <param name="systemUserRepository">An instance of ISystemUserRepository to handle the System Users</param>
    /// <param name="mapper">An instance of IMapper to map between System User entities and models</param>
    public SystemUsersController(ISystemUserRepository systemUserRepository, IMapper mapper)
    {
        this.systemUserRepository = systemUserRepository;
        this.mapper = mapper;
    }

    /// <summary>
    /// Returns a list of System Users
    /// </summary>
    /// <returns>A list of System User models, or No Content if no System User found</returns>
    [HttpGet]
    public async Task<ActionResult<IEnumerable<SystemUserResponseModel>>> GetSystemUsers()
    {
        var systemUsers = await systemUserRepository.GetAll();
        if (!systemUsers.Any())
        {
            return NoContent();
        }
        IEnumerable<SystemUserResponseModel> responseModels = mapper.Map<IEnumerable<SystemUserResponseModel>>(systemUsers);
        return Ok(responseModels);
    }

    /// <summary>
    /// Returns a specific System User based on the username
    /// </summary>
    /// <param name="username">The username of the System User to retrieve</param>
    /// <returns>The System User model, or Not Found if the System User is not found</returns>
    [HttpGet("{username}")]
    public async Task<ActionResult<SystemUserResponseModel>> GetSystemUser(string username)
    {
        SystemUser? systemUser = await systemUserRepository.GetByUsername(username);
        if (systemUser == null)
        {
            return NotFound();
        }
        SystemUserResponseModel responseModel = mapper.Map<SystemUserResponseModel>(systemUser);
        return Ok(responseModel);
    }

    /// <summary>
    /// Updates a specific System User based on the username
    /// </summary>
    /// <param name="username">The username of the System User to update</param>
    /// <param name="systemUserUpdate">The updated System User information</param>
    /// <returns>No Content if the System User is updated successfully, or Bad Request if the System User or the update information is invalid</returns>
    [HttpPatch("{username}")]
    public async Task<IActionResult> PatchSystemUser(string username, SystemUserUpdateModel systemUserUpdate)
    {
        var systemUser = await systemUserRepository.GetByUsername(username);
        if (systemUser == null || systemUserUpdate == null)
        {
            return BadRequest();
        }
        mapper.Map(systemUserUpdate, systemUser);

        await systemUserRepository.Update(systemUser);
        return NoContent();
    }

    /// <summary>
    /// Creates a new System User
    /// </summary>
    /// <param name="requestModel">The new System User information</param>
    /// <returns>The created System User model, with a location header pointing to the URL of the newly created System User</returns>
    [HttpPost]
    public async Task<ActionResult<SystemUserResponseModel>> PostSystemUser(SystemUserRequestModel requestModel)
    {
        SystemUser requestedSystemUser = mapper.Map<SystemUser>(requestModel);
        SystemUser? createdSystemUser = await systemUserRepository.Add(requestedSystemUser);
        if (createdSystemUser == null)
        {
            return BadRequest();
        }
        SystemUserResponseModel responseModel = mapper.Map<SystemUserResponseModel>(createdSystemUser);
        return CreatedAtAction("GetSystemUser", new { username = responseModel.Username }, responseModel);
    }

    /// <summary>
    /// Deletes a specific System User based on the username
    /// </summary>
    /// <param name="username">The username of the System User to delete</param>
    /// <returns>No Content if the System User is deleted successfully, or Not Found if the System User is not found</returns>
    [HttpDelete("{username}")]
    public async Task<IActionResult> DeleteSystemUser(string username)
    {
        SystemUser? systemUser = await systemUserRepository.GetByUsername(username);
        if (systemUser == null)
        {
            return NotFound();
        }
        await systemUserRepository.Delete(systemUser.Guid);

        return NoContent();
    }
}