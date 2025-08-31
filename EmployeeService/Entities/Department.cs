namespace EmployeeService.Entities;

public partial class Department : BaseEntity
{
    public string DepartmentId { get; set; } = null!;
    public string DepartmentName { get; set; } = null!;
    public string? Description { get; set; }
    public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
    public virtual ICollection<Project> Projects { get; set; } = new List<Project>();
}
