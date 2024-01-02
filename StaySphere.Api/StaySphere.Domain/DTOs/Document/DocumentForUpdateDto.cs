namespace StaySphere.Domain.DTOs.Document
{
    public record DocumentForUpdateDto(
        int Id,
        string FirstName,
        int SerialNumber,
        string Gender);
}
