using APCRM.Web.Models;

namespace APCRM.Web.DataAccess.Interface
{
    public interface IAppUserRepo : IRepo<AppUser>
    {
        void Update(AppUser user);
    }
}
