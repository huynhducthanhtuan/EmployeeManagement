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
                // Only map each field if it != null
                .ForMember(dest => dest.FullName, opt => opt.Condition(src => src.FullName != null))
                .ForMember(dest => dest.DateOfBirth, opt => opt.Condition(src => src.DateOfBirth != null))
                .ForMember(dest => dest.Gender, opt => opt.Condition(src => src.Gender != null))
                .ForMember(dest => dest.Hometown, opt => opt.Condition(src => src.Hometown != null))
                .ForMember(dest => dest.AvatarImage, opt => opt.Condition(src => src.AvatarImage != null));
        }
    }
}
