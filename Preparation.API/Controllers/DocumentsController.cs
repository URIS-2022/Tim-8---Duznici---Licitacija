using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Preparation.API.Data.Repository;
using Preparation.API.Models;

namespace Preparation.API.Controllers
{
    /// <summary>
    /// API controller for managing Documents.
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
        /// Initializes a new instance of the DocumentsController class
        /// </summary>
        /// <param name="documentRepository">An instance of IDocumentRepository to handle the Documents</param>
        /// <param name="mapper">An instance of IMapper to map between Document entities and models</param>
        public DocumentsController(IDocumentRepository documentRepository, IMapper mapper)
        {
            _documentRepository = documentRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Returns a list of documents.
        /// </summary>
        /// <returns>A list of DocumentGetResponseModel, or No Content if no document is found.</returns>
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
        /// Returns the document with the specified id.
        /// </summary>
        /// <param name="id">The id of the document.</param>
        /// <returns>The DocumentGetResponseModel with the specified id, or NotFound if the document is not found.</returns>
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
        /// Updates the document with the specified id.
        /// </summary>
        /// <param name="id">The id of the document to update.</param>
        /// <param name="patchModel">The DocumentPatchRequestModel with the updated values.</param>
        /// <returns>The DocumentPatchResponseModel with the updated values, or NotFound if the document is not found.</returns>
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
        /// Creates a new document.
        /// </summary>
        /// <param name="postModel">The DocumentPostRequestModel with the values for the new document.</param>
        /// <returns>The DocumentPostResponseModel for the newly created document.</returns>
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
        /// Deletes a Document by ID
        /// </summary>
        /// <param name="id">The ID of the Document to delete</param>
        /// <returns>NoContent if the Document is successfully deleted, NotFound if the Document is not found</returns>
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
