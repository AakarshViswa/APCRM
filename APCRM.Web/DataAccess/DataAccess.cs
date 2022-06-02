using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;

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
            customer = new CustomerRepo(_db);
            Event = new EventRepo(_db);
            workPhase = new WorkPhaseRepo(_db);
            workStatus = new WorkStatusRepo(_db);
            enquiry = new EnquiryRepo(_db);
        }
        public ISettingRepo settings { get; private set; }
        public IAppUserRepo appUser { get; private set; }
        public IEventTypeRepo eventType { get; private set; }
        public IEnquiryStatusRepo enquiryStatus { get; private set; }
        public IProductRepo product { get; private set; }
        public IPackageRepo package { get; private set; }
        public IDeliverableRepo deliverable { get; private set; }
        public IProductDocketRepo productDocket { get; private set; }
        public IDeliverableDocketRepo DeliverableDocket { get; private set; }
        public ICustomerRepo customer { get; private set; }
        public IEventRepo Event { get; private set; }
        public IWorkPhaseRepo workPhase { get; private set; }
        public IWorkStatusRepo workStatus { get; private set; }
        public IEnquiryRepo enquiry { get; private set; }
        public void Save()
        {
            _db.SaveChangesAsync();
        }
    }

    public class EventRepo : Repo<Event>, IEventRepo
    {
        private readonly ApplicationDbContext _db;
        public EventRepo(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
