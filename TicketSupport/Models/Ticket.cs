using Microsoft.Build.Evaluation;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TicketSupport.Models
{
    public class Ticket
    {

        [Key]
        public int TicketId { get; set; }

        [Required]
        [DisplayName("Project Name")]
        public string ProjectName { get; set; }

        [DisplayName("Department Name")]
        [Required]
        public string DeptName { get; set; }
        
        [Required]
        [DisplayName("Requested By")]
        public string EmployeeName { get; set; }
        
        [Required]
        [DisplayName("Description of Problem")]
        public string Description { get; set; }

        public DateTime CreatedDateTime { get; set; } = DateTime.Now;
    }
}
