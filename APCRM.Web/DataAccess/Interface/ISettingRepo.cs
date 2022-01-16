using APCRM.Web.Models;

namespace APCRM.Web.DataAccess.Interface
{
    public interface ISettingRepo : IRepo<AppSettings>
    {
        void Update(AppSettings settings);       
    }
}
