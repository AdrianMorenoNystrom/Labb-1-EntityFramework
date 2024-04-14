using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Labb_1.Models
{
    public class LeaveList
    {
        [Key]
        [DatabaseGenerated(databaseGeneratedOption: DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [ForeignKey("Employee")]
        public int? FkEmployeeId { get; set; }
        public Employee? Employee { get; set; }
        [Required]
        [ForeignKey("Leave")]
        public int? FkLeaveId { get; set; }
        public Leave? Leave { get; set; }
    }
}
