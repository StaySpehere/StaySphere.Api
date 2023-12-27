using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
