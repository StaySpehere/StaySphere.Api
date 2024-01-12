﻿using StaySphere.Domain.DTOs.Position;
using StaySphere.Domain.Pagination;
using StaySphere.Domain.ResourceParameters;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IPositionService
    {
        Task<PaginatedList<PositionDto>> GetPositions(PositionResourceParameters positionResourceParameters);
        Task<PositionDto?> GetPositionById(int id);
        Task<PositionDto> CreatePosition(PositionForCreateDto positionForCreateDto);
        Task UpdatePosition(PositionForUpdateDto positionForUpdateDto);
        Task DeletePosition(int id);
    }
}
