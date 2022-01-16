using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APCRM.Web.Controllers
{
    [Authorize]
    public class RoleController : Controller
    {
        private readonly IDataAccess _da;
        private RoleManager<IdentityRole> _roleManager;
               
        public RoleController(IDataAccess da, RoleManager<IdentityRole> roleManager)
        {
            _da = da;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            RoleViewModel model = new RoleViewModel();
            model.roleslist = await _roleManager.Roles.ToListAsync();
            return View(model);
        }
    }
}
