using StaySphere.Domain.DTOs.Position;

namespace StaySphere.Domain.Enterfaces.Services
{
    public interface IPositionService
    {
        Task<PositionDto> GetPositions();
        Task<PositionDto?> GetPositionById(int id);
        Task<PositionDto> CreatePosition(PositionForCreateDto positionForCreateDto);
        Task UpdatePosition(PositionForUpdateDto positionForUpdateDto);
        Task DeletePosition(int id);
    }
}
