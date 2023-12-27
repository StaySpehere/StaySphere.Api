using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySphere.Domain.DTOs.Position
{
   public record PositionForUpdateDto(
       int Id,
       string Name,
       decimal Salary);
    
}
