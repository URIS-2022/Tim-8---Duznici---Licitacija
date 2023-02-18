using Gateway.API.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Gateway.API.Controllers.Preparation;

/// <summary>
/// API controller for managing Documents.
/// </summary>
[ApiExplorerSettings(GroupName = "Preparation")]
[Route("api/[controller]")]
[ApiController]
[Produces("application/json", "application/xml")]
[Consumes("application/json", "application/xml")]
public class PreparationDocumentsController : ControllerBase
{
    private readonly HttpServiceProxy serviceProxy;

    /// <summary>
    /// Initializes a new instance of the DocumentsController class
    /// </summary>
    /// <param name="httpClient">Instance of HttpClient to be used for making requests</param>
    public PreparationDocumentsController(HttpClient httpClient)
    {
        serviceProxy = new(httpClient, $"{Environment.GetEnvironmentVariable("SERVICE_ENDPOINT_PREPARATION")}/api/Documents");
    }

    /// <summary>
    /// Returns a list of documents.
    /// </summary>
    /// <returns>A list of DocumentGetResponseModel, or No Content if no document is found.</returns>
    /// <response code="200">Ok if the Documents are successfully retrieved</response>
    [HttpGet]
    public Task<IActionResult> GetDocuments()
        => serviceProxy.Get();

    /// <summary>
    /// Returns the document with the specified id.
    /// </summary>
    /// <param name="id">The id of the document.</param>
    /// <returns>The DocumentGetResponseModel with the specified id, or NotFound if the document is not found.</returns>
    /// <response code="200">Ok if the Document is successfully retrieved</response>
    [HttpGet("{id}")]
    public Task<IActionResult> GetDocument(string id)
        => serviceProxy.GetById(id);

    /// <summary>
    /// Updates the document with the specified id.
    /// </summary>
    /// <param name="id">The id of the document to update.</param>
    /// <param name="requestModel">The DocumentPatchRequestModel with the updated values.</param>
    /// <returns>The DocumentPatchResponseModel with the updated values, or NotFound if the document is not found.</returns>
    /// <response code="200">Ok if the Document is successfully updated</response>
    [HttpPatch("{id}")]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> PatchDocument(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Creates a new document.
    /// </summary>
    /// <param name="id">The id of the document to create.</param>
    /// <param name="requestModel">The DocumentPostRequestModel with the values for the new document.</param>
    /// <returns>The DocumentPostResponseModel for the newly created document.</returns>
    /// <response code="201">Created if the Document is successfully created</response>
    [HttpPost]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> PostDocument(string id, object requestModel)
        => serviceProxy.Patch(id, requestModel);

    /// <summary>
    /// Deletes a document object with the specified ID.
    /// </summary>
    /// <param name="id">The ID of the document object to delete.</param>
    /// <returns>An <see cref="IActionResult"/> representing the result of the delete operation.</returns>
    /// <response code="204">NoContent if the document is successfully deleted</response>
    /// <response code="404">If the document is not found</response>
    [HttpDelete("{id}")]
    [Authorize(Roles = "Admin")]
    public Task<IActionResult> DeleteDocument(string id)
        => serviceProxy.Delete(id);
}
