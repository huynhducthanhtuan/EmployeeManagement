namespace EmployeeService.DTO
{
    public class AddEmployeeDTO
    {
        public string? FullName { get; set; }
        public string? Gender { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Hometown { get; set; }
        public string? AvatarImage { get; set; }
        public string? DepartmentId { get; set; }
        public string? PositionId { get; set; }
    }
}
