using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;
using Microsoft.AspNetCore.Identity;

namespace APCRM.Web.DataAccess
{
    public class RoleRepo : Repo<IdentityRole>, IRoleRepo
    {
        private readonly ApplicationDbContext _db;
        public RoleRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(IdentityRole role)
        {
           _db.Update(role);
        }
    }
}
