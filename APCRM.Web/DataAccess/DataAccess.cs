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
            eventType = new EventTypeRepo(_db);
            enquiryStatus = new EnquiryStatusRepo(_db);
            product = new ProductRepo(_db);
            deliverable = new DeliverableRepo(_db);
            package = new PackageRepo(_db);
            productDocket = new ProductDocketRepo(_db);
            DeliverableDocket = new DeliverableDocketRepo(_db);
        }
        public ISettingRepo settings { get; private set;}

        public IAppUserRepo appUser { get; private set; }

        public IEventTypeRepo eventType { get; private set; }

        public IEnquiryStatusRepo enquiryStatus { get; private set; }

        public IProductRepo product { get; private set; }

        public IPackageRepo package { get; private set; }

        public IDeliverableRepo deliverable { get; private set; }

        public IProductDocketRepo productDocket { get; private set; }

        public IDeliverableDocketRepo DeliverableDocket { get; private set; }

        public void Save()
        {
            _db.SaveChangesAsync();
        }
    }
}
