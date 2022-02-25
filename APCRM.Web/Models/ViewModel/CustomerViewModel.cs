namespace APCRM.Web.Models.ViewModel
{
    public class CustomerViewModel
    {
        public IEnumerable<CustomerDetails> customerDetails { get; set; }  
        public CustomerDetails Customer { get; set; }
    }
}
