namespace APCRM.Web.Models.ViewModel
{
    public class EnquiryViewModel
    {
        public Enquiry enquiry { get; set; }
        public string EventStartDate { get; set; }
        public string EvenStartTime { get; set; }
        public IEnumerable<EnquiryStatus> enquiryStatus { get; set; }
        public IEnumerable<Package> packages { get; set; }
        public IEnumerable<EventType> eventtypes { get; set; }
        public IEnumerable<Enquiry> enquirylist { get; set; }
        public UpdateEnquiryStatusModel updateEnquiryStatusModel { get; set; }

    }

    public class UpdateEnquiryStatusModel
    {
        public int Id { get; set; }
        public int EnquiryStatusId { get; set; }
    }
}
