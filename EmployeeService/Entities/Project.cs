namespace EmployeeService.Entities;

public partial class Project : BaseEntity
{
    public string ProjectId { get; set; } = null!;
    public string ProjectName { get; set; } = null!;
    public DateOnly StartDate { get; set; }
    public DateOnly? EndDate { get; set; }
    public string DepartmentId { get; set; } = null!;
    public virtual Department Department { get; set; } = null!;
    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
}
