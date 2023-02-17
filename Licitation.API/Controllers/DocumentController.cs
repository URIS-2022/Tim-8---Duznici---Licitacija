using AutoMapper;
using Licitation.API.Data.Repository;
using Licitation.API.Entities;
using Licitation.API.Models.Document;
using Microsoft.AspNetCore.Mvc;

namespace Licitation.API.Controllers
{
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
        /// Returns a list of System Users
        /// </summary>
        /// <returns>A list of System User models, or No Content if no System User found</returns>
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

        // GET: api/Documents/5
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

        // PATCH: api/Documents/5
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

        // POST: api/Documents
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

        // DELETE: api/Documents/5
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