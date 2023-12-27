using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySphere.Domain.DTOs.Document
{
    public record DocumentForUpdateDto(
        int Id,
        string FirstName,
        int SerialNumber,
        string Gender);
    
}
