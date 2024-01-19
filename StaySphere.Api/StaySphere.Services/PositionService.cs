using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StaySphere.Domain.DTOs.Position;
using StaySphere.Domain.Entities;
using StaySphere.Domain.Exeptions;
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

        public PositionService(IMapper mapper, StaySphereDbContext context)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<PaginatedList<PositionDto>> GetPositionsAsync(PositionResourceParameters positionResourceParameters)
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

        public async Task<PositionDto?> GetPositionByIdAsync(int id)
        {
            var positions = await _context.Positions.FirstOrDefaultAsync(x => x.Id == id);

            if (positions is null)
            {
                throw new EntityNotFoundException($"Position with id {id} not found!");
            }

            var positionDtos = _mapper.Map<PositionDto>(positions);
            return positionDtos;
        }

        public async Task<PositionDto> CreatePositionAsync(PositionForCreateDto positionForCreateDto)
        {
            var positionEntity = _mapper.Map<Position>(positionForCreateDto);

            _context.Add(positionEntity);
            await _context.SaveChangesAsync();

            var positionDto = _mapper.Map<PositionDto>(positionEntity);
            return positionDto;
        }

        public async Task UpdatePositionAsync(PositionForUpdateDto positionForUpdateDto)
        {
            var positionEntity = _mapper.Map<Position>(positionForUpdateDto);

            _context.Add(positionEntity);
            await _context.SaveChangesAsync();
        }

        public async Task DeletePositionAsync(int id)
        {
            var position = await _context.Positions.FirstOrDefaultAsync(x => x.Id == id);

            if (position is not null)
                _context.Remove(position);

            await _context.SaveChangesAsync();
        }
    }
}
