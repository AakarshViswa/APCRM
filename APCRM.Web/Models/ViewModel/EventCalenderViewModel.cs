namespace APCRM.Web.Models.ViewModel
{
    public class EventCalenderViewModel
    {
       public IEnumerable<Eventjson> eventjsons { get; set; }
    }

    public class Eventjson
    {
        public string id { get; set; }
        public string title { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }
    }
}
