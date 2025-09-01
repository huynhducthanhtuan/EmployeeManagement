namespace EmployeeService.DTO
{
    public class ProjectDTO
    {
        public string? ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public DateOnly? StartDate { get; set; }
        public DateOnly? EndDate { get; set; }
        public string? DepartmentId { get; set; }
    }
}
