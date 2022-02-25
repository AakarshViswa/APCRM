using APCRM.Web.Models;

namespace APCRM.Web.DataAccess.Interface
{
    public interface ICustomerRepo : IRepo<CustomerDetails>
    {
        void Update(CustomerDetails customer);
    }
}
