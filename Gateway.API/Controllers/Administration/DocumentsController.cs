using Microsoft.AspNetCore.Mvc;
using Gateway.API.Helpers;

namespace Gateway.API.Controllers;

/// <summary>
/// API controller for managing Documents.
/// </summary>
[ApiExplorerSettings(GroupName = "Administration")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class DocumentsController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Initializes a new instance of the DocumentsController class
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public DocumentsController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_ADMINISTRATION")}/api/Documents");
    }

    /// <summary>
    /// Returns a list of documents.
    /// </summary>
    /// <returns>A list of DocumentGetResponseModel, or No Content if no document is found.</returns>
    [HttpGet]
    public Task<IActionResult> GetDocuments()
        => serviceProxy.Get();

    /// <summary>
    /// Returns the document with the specified id.
    /// </summary>
    /// <param name="id">The id of the document.</param>
    /// <returns>The DocumentGetResponseModel with the specified id, or NotFound if the document is not found.</returns>
    [HttpGet("{id}")]
    public Task<IActionResult> GetDocument(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Updates the document with the specified id.
    /// </summary>
    /// <param name="id">The id of the document to update.</param>
    /// <param name="requestModel">The DocumentPatchRequestModel with the updated values.</param>
    /// <returns>The DocumentPatchResponseModel with the updated values, or NotFound if the document is not found.</returns>
    [HttpPatch("{id}")]
    public Task<IActionResult> PatchDocument(string id, [FromBody] object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Creates a new document.
    /// </summary>
    /// <param name="postModel">The DocumentPostRequestModel with the values for the new document.</param>
    /// <returns>The DocumentPostResponseModel for the newly created document.</returns>
    [HttpPost]
    public Task<IActionResult> PostDocument(object postModel)
        => serviceProxy.Post(postModel);

    /// <summary>
    /// Deletes a Document by ID
    /// </summary>
    /// <param name="id">The ID of the Document to delete</param>
    /// <returns>NoContent if the Document is successfully deleted, NotFound if the Document is not found</returns>
    [HttpDelete("{id}")]
    public Task<IActionResult> DeleteDocument(string id)
        => serviceProxy.Delete(id);
}
