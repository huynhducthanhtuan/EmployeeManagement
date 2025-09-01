namespace EmployeeService.DTO
{
    public class EmployeeProjectDTO
    {
        public string? EmployeeId { get; set; }
        public string? ProjectId { get; set; }
        public string? PositionId { get; set; }
        public DateOnly? AssignedDate { get; set; }
    }
}
