using StaySphere.Domain.DTOs.Room;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
