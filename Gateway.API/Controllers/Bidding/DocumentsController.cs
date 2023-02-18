using Gateway.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Gateway.API.Controllers.Bidding;

/// <summary>
/// API controller for managing Bidding Documents.
/// </summary>
[ApiExplorerSettings(GroupName = "Bidding")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class DocumentsController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Constructor for DocumentController
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public DocumentsController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_BIDDING")}/api/Document");
    }

    /// <summary>
    /// Get all Documents
    /// </summary>
    /// <returns> List of Documents </returns>
    /// <response code="200">Returns the list of Documents</response>
    [HttpGet]
    public Task<IActionResult> GetDocuments()
        => serviceProxy.Get();

    /// <summary>
    /// Get a Document by Id
    /// </summary>
    /// <param name="id">Id of the Document</param>
    /// <returns> A Document </returns>
    /// <response code="200">Returns the Document</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetDocument(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Create a new Document
    /// </summary>
    /// <param name="requestModel">Document to be created</param>
    /// <returns> A newly created Document </returns>
    /// <response code="201">Returns the newly created Document</response>
    [HttpPost]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> PostDocument(object requestModel)
        => serviceProxy.Post(requestModel);

    /// <summary>
    /// Update a Document
    /// </summary>
    /// <param name="id">Id of the Document</param>
    /// <param name="requestModel">Document to be updated</param>
    /// <returns> An updated Document </returns>
    /// <response code="200">Returns the updated Document</response>
    [HttpPatch("{id}")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> PatchDocument(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Delete a Document
    /// </summary>
    /// <param name="id">Id of the Document</param>
    /// <returns> A no content response </returns>
    /// <response code="204">Returns no content</response>
    /// <response code="404">If the Document is not found</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Superuser")]
    public Task<IActionResult> DeleteDocument(string id)
        => serviceProxy.Delete(id);
}
