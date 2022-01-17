using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APCRM.Web.Models
{
    public class EventType
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string EventName { get; set; }

        [Required]
        public DateTime CreatedOn { get; set; } = DateTime.Now;

        [Required]
        public string Createdby { get; set; }
        [ForeignKey("Createdby")]
        public virtual AppUser User { get; set; }

    }
}
