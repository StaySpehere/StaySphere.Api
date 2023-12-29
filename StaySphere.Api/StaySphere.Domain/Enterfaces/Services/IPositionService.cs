using StaySphere.Domain.DTOs.Position;

namespace StaySphere.Domain.Enterfaces.Services
{
    public interface IPositionService
    {
        PositionDto GetPositions();
        PositionDto? GetPositionById(int id);
        PositionDto CreatePosition(PositionForCreateDto positionForCreateDto);
        void UpdatePosition(PositionForUpdateDto positionForUpdateDto);
        void DeletePosition(int id);
    }
}
