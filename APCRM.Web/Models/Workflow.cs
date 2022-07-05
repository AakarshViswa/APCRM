using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APCRM.Web.Models
{
    public class Workflow
    {
    }

    public class WorkPhase
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string WorkPhaseName { get; set; }
        [Required]
        public string WorkPhaseCode { get; set; }
    }

    public class WorkStatus
    {
        [Key]
        public int WorkStatusId { get; set; }
        [Required]
        public string StatusName { get; set; }
        [Required]
        public int WorkPhaseId { get; set; }

        [ForeignKey("WorkPhaseId")]
        public virtual WorkPhase WorkPhase { get; set; }
        [Required]
        public string ColorCode { get; set; }

    }
}
