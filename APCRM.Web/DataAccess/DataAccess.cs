using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;

namespace APCRM.Web.DataAccess
{
    public class DataAccess : IDataAccess
    {
        private readonly ApplicationDbContext _db;

        public DataAccess(ApplicationDbContext db)
        {
            _db = db;
            settings = new SettingsRepo(_db);
            appUser = new AppUserRepo(_db);
        }
        public ISettingRepo settings { get; private set;}

        public IAppUserRepo appUser { get; private set; }

        public void Save()
        {
            _db.SaveChangesAsync();
        }
    }
}
