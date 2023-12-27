using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StaySphere.Domain.DTOs.Employee
{
    public record EmployeeForUpdateDto(
        int Id,
        string FirstName,
        int PositionId,
        decimal Salary);
   
}
