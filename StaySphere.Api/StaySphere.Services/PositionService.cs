﻿using AutoMapper;
using Microsoft.Extensions.Logging;
using StaySphere.Domain.DTOs.Guest;
using StaySphere.Domain.DTOs.Position;
using StaySphere.Domain.Interfaces.Services;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Infrastructure.Persistence;

namespace StaySphere.Services
{
    public class PositionService : IPositionService
    {
        public readonly IMapper _mapper;
        public readonly StaySphereDbContext _context;
        public readonly ILogger<PositionService> _logger;

        public PositionService(IMapper mapper, StaySphereDbContext context, ILogger<PositionService> logger)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        public async Task<PaginatedList<PositionDto>> GetPositions(PositionResourceParameters positionResourceParameters)
        {
            var query = _context.Positions.AsQueryable();
            if (positionResourceParameters.Salary is not null)
            {
                query = query.Where(x => x.Salary == positionResourceParameters.Salary);
            }

            if (positionResourceParameters.SalaryLessThan is not null)
            {
                query = query.Where(x => x.Salary < positionResourceParameters.SalaryLessThan);
            }

            if (positionResourceParameters.SalaryGreaterThan is not null)
            {
                query = query.Where(x => x.Salary > positionResourceParameters.SalaryGreaterThan);
            }

            if (!string.IsNullOrEmpty(positionResourceParameters.OrderBy))
            {
                query = positionResourceParameters.OrderBy.ToLowerInvariant() switch
                {
                    "Name" => query.OrderBy(x => x.Name),
                    "Namedesc" => query.OrderByDescending(x => x.Name),
                    "Salary" => query.OrderBy(x => x.Salary),
                    "Salarydesc" => query.OrderByDescending(x => x.Salary),
                    _ => query.OrderBy(x => x.Name)
                };
            }

            var positions = await query.ToPaginatedListAsync(positionResourceParameters.PageSize, positionResourceParameters.PageNumber);
            var positionsDtos = _mapper.Map<List<PositionDto>>(positions);

            return new PaginatedList<PositionDto>(positionsDtos, positions.TotalCount, positions.CurrentPage, positions.PageSize);
        }
    }
}
