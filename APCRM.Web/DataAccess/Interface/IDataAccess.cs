namespace APCRM.Web.DataAccess.Interface
{
    public interface IDataAccess
    {
        ISettingRepo settings { get; }
        IAppUserRepo appUser { get; }
        void Save();
    }
}
