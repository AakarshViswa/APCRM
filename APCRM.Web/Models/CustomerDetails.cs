using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APCRM.Web.Models
{
    public class CustomerDetails : BaseModel
    {
        [NotMapped]
        public static string CustomerPrefix = "APC";             
        [Key]
        public int Id { get; set; }               
        public string? CustomerID { get; set; }
        [Required]
        public string? CustomerName { get; set; }
        [Required]
        public string? CouplesName { get; set; }
        [Required]
        public string? Reference { get; set; }
        [Required]
        public string? PrimaryPhoneNumber { get; set; }
        [Required]
        public string? SecondaryPhoneNumber { get; set; }
        [Required]
        public string?  EmailAddress { get; set; }
        [Required]
        public string EventVenue { get; set; }
        [Required]
        public string EventVenueAddress { get; set; }
        public string BrideMakeupLocation { get; set; }
        public string GroomMakeupLocation { get; set; }
        public string Remarks { get; set; }
    }
}
