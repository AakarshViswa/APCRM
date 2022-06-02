using APCRM.Web.Models;

namespace APCRM.Web.DataAccess.Interface
{
    public interface IEnquiryStatusRepo : IRepo<EnquiryStatus>
    {
        void Update(EnquiryStatus user);
        Task<IEnumerable<EnquiryStatus>> GetAllEnquiryAsync();
    }

    public interface IEnquiryRepo : IRepo<Enquiry>
    {
        void Update(Enquiry enquiry);
        Task<IEnumerable<Enquiry>> GetAllEnquiryAsync();
    }
}
