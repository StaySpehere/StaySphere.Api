using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StaySphere.Domain.DTOs.Document;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Api.Controllers
{
    [Route("api/documents")]
    [ApiController]
    [Authorize]
    public class DocumentsController : ControllerBase
    {
        public IDocumentService _documentService;
        public DocumentsController(IDocumentService documentService)
        {
            _documentService = documentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<DocumentDto>> GetDocumentsAsync(
            [FromQuery] DocumentResourceParameters documentResourceParameters)
        {
            var documents = _documentService.GetDocuments(documentResourceParameters);

            return Ok(documents);
        }

        [HttpGet("{id}", Name = "GetDocumentById")]
        public ActionResult<DocumentDto> Get(int id)
        {
            var document = _documentService.GetDocumentById(id);

            return Ok(document);
        }

        [HttpPost]
        public ActionResult Post([FromBody] DocumentForCreateDto document)
        {
            _documentService.CreateDocument(document);

            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] DocumentForUpdateDto document)
        {
            if (id != document.Id)
            {
                return BadRequest($"Route id: {id} does not match with parameter id: {document.Id}.");
            }
            _documentService.UpdateDocument(document);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            _documentService.DeleteDocument(id);

            return NoContent();
        }
    }
}
