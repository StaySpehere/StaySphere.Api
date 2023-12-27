using StaySphere.Domain.DTOs.Guest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySphere.Domain.DTOs.Document
{
    public class DocumentDto
    {
        public int Id { get; set; }
        public int SerialNumber { get; set; }
        public string FullName { get; set; }
        public DateTime BrithDate { get; set; }
        public string Gender { get; set; }
        public ICollection<GuestDto> Guests { get; set; }
    }
}
