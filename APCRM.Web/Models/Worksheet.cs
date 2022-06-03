using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APCRM.Web.Models
{
    public class Worksheet
    {
        [Key]
        public int Id { get; set; }            
        [Required]
        public int EventId { get; set; }       
        public int PackageId { get; set; }    
        [ForeignKey("EventId")]
        public virtual Event eventinfo { get; set; }
        [ForeignKey("PackageId")]
        public virtual Package packageinfo { get; set; }
        
        public string CreatedBy { get; set; }          
        public string UpdatedBy { get; set; } 
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }   
}
