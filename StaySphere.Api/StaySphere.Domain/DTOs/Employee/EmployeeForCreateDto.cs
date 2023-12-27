using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySphere.Domain.DTOs.Employee
{
    public record EmployeeForCreateDto(
        string Name, 
        int PositionId,
        decimal Salary);
    
}
