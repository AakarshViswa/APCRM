namespace APCRM.Web.Models.ViewModel
{
    public class DashboardViewModel
    {
        public int EnquiryCount { get; set; }
        public int EnquiryTodayCount { get; set; }
        public int CustomerCountYTD { get; set; }
        public int CustomerTodayCount { get; set; }
        public IEnumerable<Event> UpcommingEvents { get; set; }
        public IEnumerable<Worksheet> worksheets { get; set; }
     }
}
