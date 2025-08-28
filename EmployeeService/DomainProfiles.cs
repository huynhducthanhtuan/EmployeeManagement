using AutoMapper;
using EmployeeService.DTO;
using EmployeeService.Entities;

namespace EmployeeService.Profiles
{
    public class DomainProfiles : Profile
    {
        public DomainProfiles()
        {
            CreateMap<Employee, EmployeeDTO>();
            CreateMap<EmployeeDTO, Employee>()
                .ForAllMembers(opt => opt.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}
