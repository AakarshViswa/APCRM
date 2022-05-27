using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APCRM.Web.Models
{
    public class Event : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EventTitle { get; set; }
        [Required]
        public int EventTypeId { get; set; }
        [Required]
        public DateTime EventStartDate { get; set; }
        [Required]
        public DateTime EventEndDate { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual CustomerDetails CustomerDetails { get; set; }
    }
}
