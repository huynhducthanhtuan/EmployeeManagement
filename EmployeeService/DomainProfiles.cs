using AutoMapper;
using EmployeeService.DTO;
using EmployeeService.Entities;

namespace EmployeeService.Profiles
{
    public class DomainProfiles : Profile
    {
        public DomainProfiles()
        {
            CreateMap<Employee, EmployeeDTO>()
                .ForMember(dest => dest.DepartmentName, opt => opt.MapFrom(src => src.Department.DepartmentName))
                .ForMember(dest => dest.PositionName, opt => opt.MapFrom(src => src.Position.PositionName));
            CreateMap<EmployeeDTO, Employee>()
                // Only map each field if it != null
                .ForMember(dest => dest.FullName, opt => opt.Condition(src => src.FullName != null))
                .ForMember(dest => dest.DateOfBirth, opt => opt.Condition(src => src.DateOfBirth != null))
                .ForMember(dest => dest.Gender, opt => opt.Condition(src => src.Gender != null))
                .ForMember(dest => dest.Hometown, opt => opt.Condition(src => src.Hometown != null))
                .ForMember(dest => dest.AvatarImage, opt => opt.Condition(src => src.AvatarImage != null));
            CreateMap<AddEmployeeDTO, Employee>()
                // Only map each field if it != null
                .ForMember(dest => dest.FullName, opt => opt.Condition(src => src.FullName != null))
                .ForMember(dest => dest.DateOfBirth, opt => opt.Condition(src => src.DateOfBirth != null))
                .ForMember(dest => dest.Gender, opt => opt.Condition(src => src.Gender != null))
                .ForMember(dest => dest.Hometown, opt => opt.Condition(src => src.Hometown != null))
                .ForMember(dest => dest.AvatarImage, opt => opt.Condition(src => src.AvatarImage != null))
                .ForMember(dest => dest.DepartmentId, opt => opt.Condition(src => src.DepartmentId != null))
                .ForMember(dest => dest.PositionId, opt => opt.Condition(src => src.PositionId != null));
            CreateMap<UpdateEmployeeDTO, Employee>()
                // Only map each field if it != null
                .ForMember(dest => dest.FullName, opt => opt.Condition(src => src.FullName != null))
                .ForMember(dest => dest.DateOfBirth, opt => opt.Condition(src => src.DateOfBirth != null))
                .ForMember(dest => dest.Gender, opt => opt.Condition(src => src.Gender != null))
                .ForMember(dest => dest.Hometown, opt => opt.Condition(src => src.Hometown != null))
                .ForMember(dest => dest.AvatarImage, opt => opt.Condition(src => src.AvatarImage != null));
        }
    }
}
