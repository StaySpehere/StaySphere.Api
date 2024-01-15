using StaySphere.Domain.Common;

namespace StaySphere.Domain.Entities
{
    public class Document : EntityBase
    {
        public int SerialNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDate { get; set; }
        public string Gender { get; set; }
        public virtual ICollection<Guest> Guests { get; set; }
    }
}