using Microsoft.AspNetCore.Identity;

namespace APCRM.Web.Models.ViewModel
{
    public class RoleViewModel
    {
        public List<IdentityRole> roleslist { get; set; }

        public IdentityRole role { get; set; }
    }
}
