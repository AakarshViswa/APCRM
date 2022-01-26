using System.ComponentModel.DataAnnotations;

namespace APCRM.Web.Models
{
    public class Product : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string ProductName { get; set; }
        [Required]
        public int ProductPrice { get; set; }
    }
}
