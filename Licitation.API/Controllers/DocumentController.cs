﻿using AutoMapper;
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
    public class DocumentController : ControllerBase
    {
        private readonly IDocumentRepository _documentRepository;
        private readonly IMapper _mapper;

        public DocumentController(IDocumentRepository documentRepository, IMapper mapper)
        {
            _documentRepository = documentRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<DocumentResponseModel>>> GetDocuments()
        {
            var documents = await _documentRepository.GetAllDocuments();
            if (!documents.Any())
            {
                return NoContent();
            }
            IEnumerable<DocumentResponseModel> responseModels = _mapper.Map<IEnumerable<DocumentResponseModel>>(documents);
            return Ok(responseModels);
        }

        [HttpGet("{guid}")]
        public async Task<ActionResult<DocumentResponseModel>> GetDocument(Guid guid)
        {
            Document document = await _documentRepository.GetDocumentByGuid(guid);
            if (document == null)
            {
                return NotFound();
            }
            DocumentResponseModel responseModel = _mapper.Map<DocumentResponseModel>(document);
            return Ok(responseModel);
        }

        [HttpGet("{referenceNumber}")]
        public async Task<ActionResult<DocumentResponseModel>> GetDocumentByReferenceNumber(string referenceNumber)
        {
            Document document = await _documentRepository.GetDocumentByReferenceNumber(referenceNumber);
            if (document == null)
            {
                return NotFound();
            }
            DocumentResponseModel responseModel = _mapper.Map<DocumentResponseModel>(document);
            return Ok(responseModel);
        }

        [HttpPost]
        public async Task<ActionResult<DocumentResponseModel>> PostDocument(DocumentRequestModel requestModel)
        {
            Document document = _mapper.Map<Document>(requestModel);
            Document createdDocument = await _documentRepository.AddDocument(document);
            if (createdDocument == null)
            {
                return BadRequest();
            }
            DocumentResponseModel responseModel = _mapper.Map<DocumentResponseModel>(createdDocument);
            return CreatedAtAction("GetDocument", new { guid = createdDocument.Guid }, responseModel);
        }

        [HttpPatch("{guid}")]
        public async Task<IActionResult> PatchDocument(Guid guid, DocumentUpdateModel documentUpdate)
        {
            var document = await _documentRepository.GetDocumentByGuid(guid);
            if (document == null || documentUpdate == null)
            {
                return BadRequest();
            }
            _mapper.Map(documentUpdate, document);

            var updatedDocument = await _documentRepository.UpdateDocument(document);
            if (updatedDocument == null)
            {
                return BadRequest();
            }

            return NoContent();
        }

        [HttpDelete("{guid}")]
        public async Task<IActionResult> DeleteDocument(Guid guid)
        {
            var document = await _documentRepository.GetDocumentByGuid(guid);
            if (document == null)
            {
                return NotFound();
            }

            await _documentRepository.DeleteDocument(guid);

            return NoContent();
        }
    }
}
