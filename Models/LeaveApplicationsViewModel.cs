namespace Labb_1.Models
{
    public class LeaveApplicationsViewModel
    {
        public List<Employee> Employees { get; set; }
        public string SelectedEmployee { get; set; }
        public List<Leave> LeaveHistory { get; set; }
        public List<DateTime> Months { get; set; } // Add this property
    }

}
