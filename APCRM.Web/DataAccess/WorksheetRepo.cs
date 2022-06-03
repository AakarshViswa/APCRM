using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;

namespace APCRM.Web.DataAccess
{
    public class WorksheetRepo : Repo<Worksheet>, IWorksheetRepo
    {
        private readonly ApplicationDbContext _db;
        public WorksheetRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
