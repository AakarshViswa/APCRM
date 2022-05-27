namespace APCRM.Web.Models.ViewModel
{
    public class EventViewModel
    {
        public IEnumerable<Event> Allevents { get; set; }
        public Event events { get; set; }

        public IEnumerable<CustomerDetails> customerDetails { get; set; }
    }
}
