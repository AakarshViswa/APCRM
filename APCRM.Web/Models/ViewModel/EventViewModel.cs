namespace APCRM.Web.Models.ViewModel
{
    public class EventViewModel
    {
        public IEnumerable<Event> Allevents { get; set; }
        public Event events { get; set; }

        public IEnumerable<CustomerDetails> customerDetails { get; set; }

        public IEnumerable<EventType> eventTypes { get; set; }

        public string evstartDate { get; set; }
        public string evstartTime { get; set; }
        public string evendtDate { get; set; }
        public string evendTime { get; set; }
    }
}
