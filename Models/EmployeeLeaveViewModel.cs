namespace Labb_1.Models
{
    public class EmployeeLeaveViewModel
    {
        public IEnumerable<Employee>? Employees { get; set; }
        public IEnumerable<EmployeeWithLeave>? LeaveHistory { get; set; }
        public string? SelectedEmployee { get; set; }
    }
}
