﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaySphere.Domain.DTOs.Document;
using StaySphere.Domain.Exeptions;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Domain.Responses;
using StaySphere.Infrastructure.Persistence;
using Document = StaySphere.Domain.Entities.Document;

namespace StaySphere.Services
{
    public class DocumentService : IDocumentService
    {
        private readonly IMapper _mapper;
        private readonly StaySphereDbContext _context;

        public DocumentService(IMapper mapper, StaySphereDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<GetDocumentResponse> GetDocumentsAsync(DocumentResourceParameters documentResourceParameters)
        {
            var query = _context.Documents.AsQueryable();

            if (!string.IsNullOrEmpty(documentResourceParameters.OrderBy))
            {
                query = documentResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "serialnumber" => query.OrderBy(x => x.SerialNumber),
                    "serialnumberdesc" => query.OrderByDescending(x => x.SerialNumber),
                    "firstname" => query.OrderBy(x => x.FirstName),
                    "firstnamedesc" => query.OrderByDescending(x => x.FirstName),
                    "lastname" => query.OrderBy(x => x.LastName),
                    "lastnamedesc" => query.OrderByDescending(x => x.LastName),
                    "birthdate" => query.OrderBy(x => x.BirthDate),
                    "birthdatedesc" => query.OrderByDescending(x => x.BirthDate),
                    "gender" => query.OrderBy(x => x.Gender),
                    "genderdesc" => query.OrderByDescending(x => x.Gender),
                    _ => query.OrderBy(x => x.SerialNumber)
                };
            }

            var documents = await query.ToPaginatedListAsync(documentResourceParameters.PageSize, documentResourceParameters.PageNumber);
            var documentDtos = _mapper.Map<List<DocumentDto>>(documents);

            var paginatedDocuments = new PaginatedList<DocumentDto>(documentDtos, documents.TotalCount, documents.CurrentPage, documents.PageSize);

            var result = new GetDocumentResponse()
            {
                Data = paginatedDocuments.ToList(),
                HasNextPage = paginatedDocuments.HasNext,
                HasPreviousPage = paginatedDocuments.HasPrevious,
                PageNumber = paginatedDocuments.CurrentPage,
                PageSize = paginatedDocuments.PageSize,
                TotalPages = paginatedDocuments.TotalPages
            };

            return result;
        }

        public async Task<DocumentDto?> GetDocumentByIdAsync(int id)
        {
            var documents = await _context.Documents.FirstOrDefaultAsync(x => x.Id == id);

            if (documents is null)
            {
                throw new EntityNotFoundException($"Document with {id} not found");
            }

            var documentDto = _mapper.Map<DocumentDto>(documents);
            return documentDto;
        }
        public async Task<DocumentDto> CreateDocumentAsync(DocumentForCreateDto documentForCreateDto)
        {
            var documentEntity = _mapper.Map<Document>(documentForCreateDto);

            _context.Add(documentEntity);
            await _context.SaveChangesAsync();

            var documentDto = _mapper.Map<DocumentDto>(documentEntity);
            return documentDto;
        }
        public async Task UpdateDocumentAsync(DocumentForUpdateDto documentForUpdateDto)
        {
            var documentEntity = _mapper.Map<Document>(documentForUpdateDto);

            _context.Documents.Update(documentEntity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteDocumentAsync(int id)
        {
            var document = await _context.Documents.FirstOrDefaultAsync(x => x.Id == id);

            if (document is not null)
                _context.Documents.Remove(document);

            await _context.SaveChangesAsync();
        }
    }
}
