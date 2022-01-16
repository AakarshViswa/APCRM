using System.ComponentModel.DataAnnotations;

namespace APCRM.Web.Models
{
    public class AppSettings
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Icon { get; set; }
        [Required]
        public string ControllerName { get; set; }
        [Required]
        public string ViewName { get; set; }
    }
}
