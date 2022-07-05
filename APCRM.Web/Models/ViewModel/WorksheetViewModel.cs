namespace APCRM.Web.Models.ViewModel
{
    public class WorksheetViewModel
    {
        public IEnumerable<Worksheet> worksheets { get; set; }
        public Worksheet worksheet { get; set; }

        public IEnumerable<WorksheetProduct> worksheetProducts { get; set; }
        public IEnumerable<WorksheetDeliverable> worksheetDeliverables { get; set; }

        public WorksheetPaymentStatus worksheetPaymentStatus { get; set; }

        public IEnumerable<WorkStatus> workStatuses { get; set; }
    }
}
