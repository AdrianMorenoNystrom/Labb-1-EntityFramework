using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Labb_1.Models
{
    public class EmployeeWithLeave
    {
        public string? EmployeeName { get; set; }
        public string LeaveType { get; set; }

        [DataType(DataType.Date)]
        public DateTime StartDate { get; set; }

        [DataType(DataType.Date)]
        public DateTime EndDate { get; set; }
    }
}
