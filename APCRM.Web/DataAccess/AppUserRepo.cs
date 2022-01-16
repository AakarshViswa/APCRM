using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;

namespace APCRM.Web.DataAccess
{
    public class AppUserRepo : Repo<AppUser>, IAppUserRepo
    {
        private readonly ApplicationDbContext _db;
        public AppUserRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AppUser user)
        {
            _db.Update(user);
        }
    }
}
