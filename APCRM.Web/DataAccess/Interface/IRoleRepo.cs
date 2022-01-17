using APCRM.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace APCRM.Web.DataAccess.Interface
{
    public interface IRoleRepo : IRepo<AppRole>
    {
        void Update(AppRole role);
    }
}
