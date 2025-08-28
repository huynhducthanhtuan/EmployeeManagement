using EmployeeService.Enums;

namespace EmployeeService.DTO
{
    public class EmployeeDTO
    {
        public string? FullName { get; set; } = String.Empty;
        public GenderEnum? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Hometown { get; set; } = String.Empty;
        public string? AvatarImage { get; set; } = String.Empty;
    }
}
