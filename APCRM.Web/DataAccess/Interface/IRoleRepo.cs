using Microsoft.AspNetCore.Identity;

namespace APCRM.Web.DataAccess.Interface
{
    public interface IRoleRepo : IRepo<IdentityRole>
    {
        void Update(IdentityRole role);
    }
}
