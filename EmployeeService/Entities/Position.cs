namespace EmployeeService.Entities;

public partial class Position : BaseEntity
{
    public string PositionId { get; set; } = null!;
    public string PositionName { get; set; } = null!;
    public string? Description { get; set; }
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
}
