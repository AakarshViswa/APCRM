using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace APCRM.Web.DataAccess
{
    public class RoleRepo : Repo<AppRole>, IRoleRepo
    {
        private readonly ApplicationDbContext _db;
        public RoleRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public void Update(AppRole role)
        {
           _db.Update(role);
        }
    }
}
