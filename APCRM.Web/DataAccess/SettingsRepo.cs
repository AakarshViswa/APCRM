using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;

namespace APCRM.Web.DataAccess
{
    public class SettingsRepo : Repo<AppSettings>, ISettingRepo
    {
        private readonly ApplicationDbContext _db;

        public SettingsRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;   
        }
        public void Update(AppSettings settings)
        {
            _db.Settings.Update(settings);
        }
    }
}
