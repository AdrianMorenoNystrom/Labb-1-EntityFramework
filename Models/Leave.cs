using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Labb_1.Models
{
    public enum LeaveType
    {
        [Display(Name = "Illness")]
        Illness,

        [Display(Name = "Vacation")]
        Vacation,

        [Display(Name = "Personal Reasons")]
        PersonalReasons,

        [Display(Name = "Parental Reasons")]
        ParentalReasons,

        [Display(Name = "Other")]
        Other
    }

    public class Leave
    {
        public int LeaveId { get; set; }

        [DisplayName("Start date")]
        [DataType(DataType.Date)]

        public DateTime StartDate { get; set; }

        [DisplayName("End date")]
        [DataType(DataType.Date)]

        public DateTime EndDate { get; set; }

        [DisplayName("Application date")]
        [DataType(DataType.Date)]

        public DateTime ApplicationDate { get; set; } = DateTime.Now;

        [DisplayName("Leave type")]
        [ReadOnly(true)]
        public LeaveType? LeaveType { get; set; }


        public int EmployeeId { get; set; }
        public Employee? Employee { get; set; }
    }
}
