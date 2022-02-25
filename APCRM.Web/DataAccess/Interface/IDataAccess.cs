namespace APCRM.Web.DataAccess.Interface
{
    public interface IDataAccess
    {
        ISettingRepo settings { get; }
        IAppUserRepo appUser { get; }
        IEventTypeRepo eventType { get; }
        IEnquiryStatusRepo enquiryStatus { get; }

        IProductRepo product { get; }
        IPackageRepo package { get; }
        IDeliverableRepo deliverable { get; }
        IProductDocketRepo productDocket { get; }
        IDeliverableDocketRepo  DeliverableDocket { get; }
        ICustomerRepo customer { get; } 
        void Save();
    }
}
