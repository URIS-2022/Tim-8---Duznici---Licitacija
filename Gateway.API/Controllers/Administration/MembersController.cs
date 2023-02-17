using Microsoft.AspNetCore.Mvc;
using Gateway.API.Helpers;

namespace Gateway.API.Controllers;

/// <summary>
/// API controller for managing members.
/// </summary>
[ApiExplorerSettings(GroupName = "Administration")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class MembersController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Initializes a new instance of the MembersController class with the specified dependencies.
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public MembersController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_ADMINISTRATION")}/api/Members");
    }

    /// <summary>
    /// Gets all members.
    /// </summary>
    /// <returns>A collection of MemberGetResponseModel objects.</returns>
    [HttpGet]
    public Task<IActionResult> GetMembers()
        => serviceProxy.Get();

    /// <summary>
    /// Gets a member with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the member to retrieve.</param>
    /// <returns>A MemberGetResponseModel object representing the retrieved member.</returns>
    [HttpGet("{id}")]
    public Task<IActionResult> GetMember(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Updates a member with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the member to update.</param>
    /// <param name="requestModel">The MemberPatchRequestModel containing the updates to apply.</param>
    /// <returns>A MemberPatchResponseModel object representing the updated member.</returns>
    [HttpPatch("{id}")]
    public Task<IActionResult> PatchMember(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Creates a new member.
    /// </summary>
    /// <param name="postModel">The MemberPostRequestModel containing the new member data.</param>
    /// <returns>A MemberPostResponseModel object representing the newly created member.</returns>
    [HttpPost]
    public Task<IActionResult> PostMember(object postModel)
        => serviceProxy.Post(postModel);

    /// <summary>
    /// Deletes a member with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the member to delete.</param>
    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteMember(string id)
        => serviceProxy.Delete(id);
}
