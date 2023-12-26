using StaySphere.Domain.Common;

namespace StaySphere.Domain.Entities
{
    public class Document : EntityBase
    {
        public int SerialNumber { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BrithDate { get; set; }
        public string Gender { get; set; }
    }
}
