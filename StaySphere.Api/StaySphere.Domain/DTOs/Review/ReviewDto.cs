namespace StaySphere.Domain.DTOs.Review
{
    public record ReviewDto(
        int Id,
        int BookingId,
        string Comment,
        float Grade);
}
