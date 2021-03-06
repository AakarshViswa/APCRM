using System.ComponentModel.DataAnnotations;

namespace APCRM.Web.Models
{
    public class EnquiryStatus : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int OrderBy { get; set; }     
        [Required]
        public string ColorCode { get; set; }
    }
}
