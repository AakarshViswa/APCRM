using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APCRM.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IDataAccess _da;
        private readonly UserManager<AppUser> _userManager;

        public UserController(IDataAccess da, UserManager<AppUser> userManager)
        {
            _da = da;
            _userManager = userManager; 
        }
        public async Task<IActionResult> Index()
        {
            UserViewModel model = new UserViewModel();
            IEnumerable<AppUser> userlist = await _da.appUser.GetAllAsync();            
            model.UsersList = userlist;
            return View(model);
        }
    }
}
