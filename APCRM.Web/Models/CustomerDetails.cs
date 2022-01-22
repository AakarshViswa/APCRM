using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APCRM.Web.Models
{
    public class CustomerDetails
    {
        [NotMapped]
        public static string CustomerPrefix = "APC";             
        [Key]
        public int Id { get; set; }

        [Required]
        public string? CustomerID { get; set; }
        [Required]
        public string? CustomerName { get; set; }
        [Required]
        public string? CouplesName { get; set; }
        [Required]
        public string? Reference { get; set; }
        [Required]
        public string? PhoneNumber { get; set; }
        [Required]
        public string?  EmailAddress { get; set; }
    }
}
