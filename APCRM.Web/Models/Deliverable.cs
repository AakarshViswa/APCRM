using System.ComponentModel.DataAnnotations;

namespace APCRM.Web.Models
{
    public class Deliverable : BaseModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string DeliverableName { get; set; }
        [Required]
        public int DeliverablePrice { get; set; }
    }
}
