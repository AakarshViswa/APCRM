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

        [ForeignKey("EventTypeId")]
        public virtual EventType EventType { get; set; }
        [Required]
        public DateTime EventStartDate { get; set; }
        [Required]
        public DateTime EventEndDate { get; set; }
        [Required]
        public int CustomerId { get; set; }
        [ForeignKey("CustomerId")]
        public virtual CustomerDetails CustomerDetails { get; set; }       
        public string EventVenue { get; set; }       
        public string EventVenueAddress { get; set; }
        public string BrideMakeupLocation { get; set; }
        public string GroomMakeupLocation { get; set; }   
        public string Remarks { get; set; }
    }
}
