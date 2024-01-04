using AutoMapper;
using StaySphere.Domain.DTOs.Employee;
using StaySphere.Domain.Entities;

namespace StaySphere.Domain.Mappings
{
    public class EmployeeMappings : Profile
    {
        public EmployeeMappings()
        {
            CreateMap<Employee,EmployeeDto>()
            .ForMember(x => x.FullName, r => r.MapFrom(x => x.FirstName + "" + x.LastName));
            CreateMap<EmployeeDto, Employee>();
            CreateMap<EmployeeForCreateDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>();
        }
    }
}
