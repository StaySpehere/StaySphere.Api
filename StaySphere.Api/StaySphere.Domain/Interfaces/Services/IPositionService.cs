using StaySphere.Domain.DTOs.Position;
using StaySphere.Domain.ResourceParameters;
using StaySphere.Domain.Responses;

namespace StaySphere.Domain.Interfaces.Services
{
    public interface IPositionService
    {
        Task<GetPositionResponse> GetPositionsAsync(PositionResourceParameters positionResourceParameters);
        Task<PositionDto?> GetPositionByIdAsync(int id);
        Task<PositionDto> CreatePositionAsync(PositionForCreateDto positionForCreateDto);
        Task UpdatePositionAsync(PositionForUpdateDto positionForUpdateDto);
        Task DeletePositionAsync(int id);
    }
}
