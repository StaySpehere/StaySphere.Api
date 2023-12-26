namespace StaySphere.Domain.DTOs.Category
{
    public class CategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int NumberOfRooms { get; set; }
        public ICollection<RoomDto> Rooms { get; set; }
    }
}
