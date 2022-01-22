using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;

namespace APCRM.Web.DataAccess
{
    public class EnquiryStatusRepo : Repo<EnquiryStatus>, IEnquiryStatusRepo
    {
        private readonly ApplicationDbContext _db;
        public EnquiryStatusRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(EnquiryStatus user)
        {
            _db.Update(user);
        }

    }
}
