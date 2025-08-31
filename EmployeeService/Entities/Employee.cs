namespace EmployeeService.Entities;

public partial class Employee : BaseEntity
{
    public string EmployeeId { get; set; } = null!;
    public string FullName { get; set; } = null!;
    public string Gender { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string Hometown { get; set; } = null!;
    public string? AvatarImage { get; set; }
    public string DepartmentId { get; set; } = null!;
    public string PositionId { get; set; } = null!;
    public virtual Department Department { get; set; } = null!;
    public virtual Position Position { get; set; } = null!;
    public virtual ICollection<EmployeeProject> EmployeeProjects { get; set; } = new List<EmployeeProject>();
}
