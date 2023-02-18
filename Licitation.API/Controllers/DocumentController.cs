using AutoMapper;
using Licitation.API.Data.Repository;
using Licitation.API.Models.Document;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Contains API endpoints to handle Documents.
/// </summary>
namespace Licitation.API.Controllers
{
    /// <summary>
    /// Represents a controller to handle Document requests.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the DocumentsController class.
        /// </summary>
        /// <param name="documentRepository">An instance of IDocumentRepository to handle the Documents.</param>
        /// <param name="mapper">An instance of IMapper to map between Document entities and models.</param>
        public DocumentsController(IDocumentRepository documentRepository, IMapper mapper)
        {
            _documentRepository = documentRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Returns a list of Document models.
        /// </summary>
        /// <returns>A list of DocumentGetResponseModel models, or No Content if no Document found.</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentGetResponseModel>>> GetDocuments()
        {
            var documents = await _documentRepository.GetDocuments();
            if (!documents.Any())
            {
                return NoContent();
            }
            IEnumerable<DocumentGetResponseModel> responseModels = mapper.Map<IEnumerable<DocumentGetResponseModel>>(documents);
            return Ok(responseModels);
        }

        /// <summary>
        /// Returns a Document model with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Document to retrieve.</param>
        /// <returns>A DocumentGetResponseModel model with the specified ID, or NotFound if no Document found.</returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<DocumentGetResponseModel>> GetDocument(Guid id)
        {
            var document = await _documentRepository.GetDocument(id);
            if (document == null)
            {
                return NotFound();
            }
            var responseModel = mapper.Map<DocumentGetResponseModel>(document);
            return responseModel;
        }

        /// <summary>
        /// Updates the specified Document with a set of changes.
        /// </summary>
        /// <param name="id">The ID of the Document to update.</param>
        /// <param name="patchModel">A DocumentPatchRequestModel containing the changes to apply.</param>
        /// <returns>A DocumentPatchResponseModel model with the updated Document, or NotFound if no Document found.</returns>
        [HttpPatch("{id}")]
        public async Task<ActionResult<DocumentPatchResponseModel>> PatchDocument(Guid id, [FromBody] DocumentPatchRequestModel patchModel)
        {
            var document = await _documentRepository.GetDocument(id);
            if (document == null)
            {
                return NotFound();
            }

            mapper.Map(patchModel, document);

            var updated = await _documentRepository.UpdateDocument(id, document);
            if (updated == null)
            {
                return BadRequest();
            }

            var responseModel = mapper.Map<DocumentPatchResponseModel>(updated);

            return Ok(responseModel);
        }

        /// <summary>
        /// Creates a new Document with the specified properties.
        /// </summary>
        /// <param name="postModel">A DocumentPostRequestModel containing the properties of the new Document.</param>
        /// <returns>A DocumentPostResponseModel model with the created Document, or BadRequest if the Document could not be created.</returns>
        [HttpPost]
        public async Task<ActionResult<DocumentPostResponseModel>> PostDocument(DocumentPostRequestModel postModel)
        {
            var document = mapper.Map<Entities.Document>(postModel);
            Entities.Document? created = await _documentRepository.AddDocument(document);
            if (created == null)
            {
                return BadRequest();
            }
            var responseModel = mapper.Map<DocumentPostResponseModel>(created);
            return CreatedAtAction("GetDocument", new { id = created.Guid }, responseModel);
        }

        /// <summary>
        /// Deletes the Document with the specified ID.
        /// </summary>
        /// <param name="id">The ID of the Document to delete.</param>
        /// <returns>NoContent if the Document was successfully deleted, or NotFound if no Document found.</returns>
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDocument(Guid id)
        {
            var document = await _documentRepository.GetDocument(id);
            if (document == null)
            {
                return NotFound();
            }
            await _documentRepository.DeleteDocument(document.Guid);

            return NoContent();
        }

    }
}