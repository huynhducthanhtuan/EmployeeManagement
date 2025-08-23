using EmployeeService.Enums;

namespace EmployeeService.Entities
{
    public class Employee : BaseEntity
    {
        public string FullName { get; set; }
        public GenderEnum Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Hometown { get; set; }
        public string AvatarImage { get; set; }
    }
}
