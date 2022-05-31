namespace APCRM.Web.Models.ViewModel
{
    public class WorkStatusViewModel
    {
        public IEnumerable<WorkPhase> workPhases { get; set; }
        public WorkPhase WorkPhase { get; set; }
        public WorkPhase EditWorkPhase { get; set; }

        public IEnumerable<WorkStatus> workStatuses { get; set; }
        public WorkStatus workStatus { get; set; }
        public WorkStatus EditWorkStatus { get; set; }
    }
}
