using AutoMapper;
using StaySphere.Domain.DTOs.Employee;
using StaySphere.Domain.Entities;

namespace StaySphere.Domain.Mappings
{
    public class EmployeeMappings : Profile
    {
        public EmployeeMappings()
        {
            CreateMap<Employee, EmployeeDto>()
                .ForCtorParam(nameof(EmployeeDto.FullName),
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
            CreateMap<EmployeeDto, Employee>();
            CreateMap<EmployeeForCreateDto, Employee>();
            CreateMap<EmployeeForUpdateDto, Employee>();
        }
    }
}
