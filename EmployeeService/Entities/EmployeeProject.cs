namespace EmployeeService.Entities;

public partial class EmployeeProject : BaseEntity
{
    public string EmployeeId { get; set; } = null!;
    public string ProjectId { get; set; } = null!;
    public string PositionId { get; set; } = null!;
    public DateOnly AssignedDate { get; set; }
    public virtual Employee Employee { get; set; } = null!;
    public virtual Position Position { get; set; } = null!;
    public virtual Project Project { get; set; } = null!;
}
