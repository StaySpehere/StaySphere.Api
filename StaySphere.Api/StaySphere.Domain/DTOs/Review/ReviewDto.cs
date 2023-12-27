namespace StaySphere.Domain.DTOs.Review
{
    public class ReviewDto
    {
        public int Id { get; set; }
        public int BookingId { get; set; }
        public string Comment { get; set; }
        public float Grade { get; set; }
    }
}
