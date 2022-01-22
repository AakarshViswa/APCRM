using APCRM.Web.Models;

namespace APCRM.Web.DataAccess.Interface
{
    public interface IEnquiryStatusRepo : IRepo<EnquiryStatus>
    {
        void Update(EnquiryStatus user);
    }
}
