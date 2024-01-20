using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using StaySphere.Domain.DTOs.Document;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
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
            var metaData = await GetPagenationMetaDataAsync(documents);

            Response.Headers.Append("X-Pagination", JsonConvert.SerializeObject(metaData));

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
            await  _documentService.CreateDocumentAsync(document);
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
        private async Task<PagenationMetaData> GetPagenationMetaDataAsync(PaginatedList<DocumentDto> documentDtOs)
        {
            return new PagenationMetaData
            {
                Totalcount = documentDtOs.TotalCount,
                PageSize = documentDtOs.PageSize,
                CurrentPage = documentDtOs.CurrentPage,
                TotalPages = documentDtOs.TotalPages,
            };
        }
        class PagenationMetaData
        {
            public int Totalcount { get; set; }
            public int PageSize { get; set; }
            public int CurrentPage { get; set; }
            public int TotalPages { get; set; }
        }
    }
}
