namespace APCRM.Web.DataAccess.Interface
{
    public interface IDataAccess
    {
        ISettingRepo settings { get; }
        IAppUserRepo appUser { get; }
        IEventTypeRepo eventType { get; }
        IEnquiryStatusRepo enquiryStatus { get; }
        void Save();
    }
}
