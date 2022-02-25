using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;

namespace APCRM.Web.DataAccess
{
    public class CustomerRepo : Repo<CustomerDetails>, ICustomerRepo
    {
        private readonly ApplicationDbContext _db;
        
        public CustomerRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(CustomerDetails customer)
        {
            _db.Update(customer);
        }
    }
}
