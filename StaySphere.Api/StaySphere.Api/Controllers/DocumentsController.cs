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
        public async Task<ActionResult<IEnumerable<DocumentDto>>> GetDocumentsAsync(
            [FromQuery] DocumentResourceParameters documentResourceParameters)
        {
            var documents = await _documentService.GetDocumentsAsync(documentResourceParameters);

            return Ok(documents);
        }

        [HttpGet("{id}", Name = "GetDocumentById")]
        public async Task<ActionResult<DocumentDto>> Get(int id)
        {
            var document = await _documentService.GetDocumentByIdAsync(id);
            return Ok(document);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] DocumentForCreateDto document)
        {
            await _documentService.CreateDocumentAsync(document);
            return StatusCode(201);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Put(int id, [FromBody] DocumentForUpdateDto document)
        {
            if (id != document.Id)
            {
                return BadRequest($"Route id: {id} does not match with parameter id: {document.Id}.");
            }
            await _documentService.UpdateDocumentAsync(document);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await _documentService.DeleteDocumentAsync(id);

            return NoContent();
        }
    }
}
