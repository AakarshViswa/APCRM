using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APCRM.Web.Models
{
    public class Enquiry:BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string CustomerName { get; set; }
        [Required]
        public string CouplesName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public int PackageId { get; set; }
        [ForeignKey("PackageId")]
        public virtual Package Package { get; set; }
        [Required]
        public DateTime EventDate { get; set; }
        [Required]
        public string SessionType { get; set; }
        [Required]
        public int EventTypeId { get; set; }
        [ForeignKey("EventTypeId")]
        public virtual EventType EventType { get; set; }
        [Required]
        public int EnquiryStatusId { get; set; }
        [ForeignKey("EnquiryStatusId")]
        public virtual EnquiryStatus EnquiryStatus { get; set; }
        [Required]
        public string EventVenue { get; set; }
        [Required]
        public string EventVenueAddress { get; set; }       
        public string BrideMakeupLocation { get; set; }       
        public string GroomMakeupLocation { get; set; }
        public string Remarks { get; set; }

    }
}
