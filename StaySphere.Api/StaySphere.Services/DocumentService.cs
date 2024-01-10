﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StaySphere.Domain.DTOs.Document;
using StaySphere.Domain.Exeptions;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Infrastructure.Persistence;
using Document = StaySphere.Domain.Entities.Document;

namespace StaySphere.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IMapper _mapper;
        private readonly StaySphereDbContext _context;
        private readonly ILogger<DocumentService> _logger;

        public DocumentService(IMapper mapper, StaySphereDbContext context, ILogger<DocumentService> logger)
        {
            _mapper = mapper;
            _context = context;
            _logger = logger;
        }

        public async Task<PaginatedList<DocumentDto>> GetDocuments(DocumentResourceParameters documentResourceParameters)
        {
            var query = _context.Documents.AsQueryable();

            if (!string.IsNullOrEmpty(documentResourceParameters.OrderBy))
            {
                query = documentResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "SerialNumber" => query.OrderBy(x => x.SerialNumber),
                    "SerialNumberdesc" => query.OrderByDescending(x => x.SerialNumber),
                    "FirstName" => query.OrderBy(x => x.FirstName),
                    "FirstNamedesc" => query.OrderByDescending(x => x.FirstName),
                    "LastName" => query.OrderBy(x => x.LastName),
                    "LastNamedesc" => query.OrderByDescending(x => x.LastName),
                    "BirthDate" => query.OrderBy(x => x.BrithDate),
                    "BirthDatedesc" => query.OrderByDescending(x => x.BrithDate),
                    "Gender" => query.OrderBy(x => x.Gender),
                    "Genderdesc" => query.OrderByDescending(x => x.Gender),
                    _ => query.OrderBy(x => x.SerialNumber)
                };
            }

            var documents = await query.ToPaginatedListAsync(documentResourceParameters.PageSize, documentResourceParameters.PageNumber);
            var documentDtos = _mapper.Map<List<DocumentDto>>(documents);

            return new PaginatedList<DocumentDto>(documentDtos, documents.TotalCount, documents.CurrentPage, documents.PageSize);
        }

        public async Task<DocumentDto?> GetDocumentById(int id)
        {
            var documents = await _context.Documents.FirstOrDefaultAsync(x => x.Id == id);

            if (documents is null)
            {
                throw new EntityNotFoundException($"Document with {id} not found");
            }

            var documentDto = _mapper.Map<DocumentDto>(documents);
            return documentDto;
        }
        public async Task<DocumentDto> CreateDocument(DocumentForCreateDto documentForCreateDto)
        {
            var documentEntity = _mapper.Map<Document>(documentForCreateDto);

            _context.Add(documentEntity);
            await _context.SaveChangesAsync();

            var documentDto = _mapper.Map<DocumentDto>(documentEntity);
            return documentDto;
        }
        public async Task UpdateDocument(DocumentForUpdateDto documentForUpdateDto)
        {
            var documentEntity = _mapper.Map<Document>(documentForUpdateDto);

            _context.Documents.Update(documentEntity);
            await _context.SaveChangesAsync();
        }
    }
}
