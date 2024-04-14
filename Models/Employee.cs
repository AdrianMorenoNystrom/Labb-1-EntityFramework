using System.ComponentModel.DataAnnotations;

namespace Labb_1.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Employee måste ha ett namn!")]
        [StringLength(maximumLength: 60, ErrorMessage = "Namn får inte överskrida 60 bokstäver!")]
        public string ?EmployeeName { get; set; }
    }
}
