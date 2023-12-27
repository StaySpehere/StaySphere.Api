namespace StaySphere.Domain.DTOs.Review
{
    public record ReviewForUpdateDto(
        int Id,
        int BookingId,
        string Comment);

}
