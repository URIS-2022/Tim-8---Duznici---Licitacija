using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Preparation.API.Data.Repository;
using Preparation.API.Models;
using Preparation.API.Entities;

namespace Preparation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json", "application/xml")]
    [Consumes("application/json", "application/xml")]
    public class DocumentsController : ControllerBase
    {
        private readonly IDocumentRepository documentRepository;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the SystemUsersController class
        /// </summary>
        /// <param name="systemUserRepository">An instance of ISystemUserRepository to handle the System Users</param>
        /// <param name="mapper">An instance of IMapper to map between System User entities and models</param>
        public DocumentsController(IDocumentRepository documentRepository, IMapper mapper)
        {
            this.documentRepository = documentRepository;
            this.mapper = mapper;
        }

        /// <summary>
        /// Returns a list of System Users
        /// </summary>
        /// <returns>A list of System User models, or No Content if no System User found</returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentResponseModel>>> GetDocuments()
        {
            var documents = await documentRepository.GetAll();
            if (!documents.Any())
            {
                return NoContent();
            }
            IEnumerable<DocumentResponseModel> responseModels = mapper.Map<IEnumerable<DocumentResponseModel>>(documents);
            return Ok(responseModels);
        }

        /// <summary>
        /// Returns a specific System User based on the username
        /// </summary>
        /// <param name="username">The username of the System User to retrieve</param>
        /// <returns>The System User model, or Not Found if the System User is not found</returns>
        [HttpGet("{number}")]
        public async Task<ActionResult<DocumentResponseModel>> GetByNumber(string ReferenceNumber)
        {
            Document? document = await documentRepository.GetByNumber(ReferenceNumber);
            if (document == null)
            {
                return NotFound();
            }
            DocumentResponseModel responseModel = mapper.Map<DocumentResponseModel>(document);
            return Ok(responseModel);
        }

        
        /// <summary>
        /// Updates a specific System User based on the username
        /// </summary>
        /// <param name="username">The username of the System User to update</param>
        /// <param name="systemUserUpdate">The updated System User information</param>
        /// <returns>No Content if the System User is updated successfully, or Bad Request if the System User or the update information is invalid</returns>
        [HttpPatch("{number}")]
        public async Task<IActionResult> PutDocument(string ReferenceNumber, DocumentUpdateModel documentUpdate)
        {
            var document = await documentRepository.GetByNumber(ReferenceNumber);
            if (document == null || documentUpdate == null)
            {
                return BadRequest();
            }
            mapper.Map(documentUpdate, document);

            await documentRepository.Update(document);
            return NoContent();
        }

        /// <summary>
        /// Creates a new System User
        /// </summary>
        /// <param name="requestModel">The new System User information</param>
        /// <returns>The created System User model, with a location header pointing to the URL of the newly created System User</returns>
        [HttpPost]
        public async Task<ActionResult<DocumentResponseModel>> PostDocument(DocumentRequestModel requestModel)
        {
            Document requestedDocument = mapper.Map<Document>(requestModel);
            Document? createdDocument = await documentRepository.Add(requestedDocument);
            if (createdDocument == null)
            {
                return BadRequest();
            }
            DocumentResponseModel responseModel = mapper.Map<DocumentResponseModel>(createdDocument);
            return CreatedAtAction("GetDocument", new { number = responseModel.ReferenceNumber }, responseModel);
        }

        /// <summary>
        /// Deletes a specific System User based on the username
        /// </summary>
        /// <param name="username">The username of the System User to delete</param>
        /// <returns>No Content if the System User is deleted successfully, or Not Found if the System User is not found</returns>
        [HttpDelete("{number}")]
        public async Task<IActionResult> DeleteDocument(string ReferenceNumber)
        {
            Document? document = await documentRepository.GetByNumber(ReferenceNumber);
            if (document == null)
            {
                return NotFound();
            }
            await documentRepository.Delete(document.Guid);

            return NoContent();
        }
    }
}
