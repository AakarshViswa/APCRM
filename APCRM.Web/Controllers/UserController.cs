using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using APCRM.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace APCRM.Web.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IDataAccess _da;
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public UserController(IDataAccess da, UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _da = da;
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public async Task<IActionResult> Index()
        {
            UserViewModel model = new UserViewModel();
            IEnumerable<AppUser> userlist = await _da.appUser.GetAllAsync();
            foreach (var user in userlist)
            {
                IList<string> role = await _userManager.GetRolesAsync(user);
                user.RoleName = role.FirstOrDefault();
            }
            model.UsersList = userlist;

            List<SelectListItem> listitems = new List<SelectListItem>();
            var rolelist = _roleManager.Roles.Select(x => new { x.Id, x.Name }).ToList();
            foreach (var role in rolelist)
            {
                SelectListItem item = new SelectListItem();
                item.Text = role.Name;
                item.Value = role.Name;
                listitems.Add(item);
            }
            model.newuser = new NewUser();
            model.newuser.RoleList = listitems;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UserViewModel model)
        {
            if (model != null && model.newuser != null)
            {
                var user = new AppUser
                {
                    FirstName = model.newuser.FirstName,
                    LastName = model.newuser.LastName,
                    Email = model.newuser.Email,
                    Photo = APCRMConstants.DefaultPhoto,
                    UserName = model.newuser.Email.ToLower().Trim()
                };

                IdentityResult result = await _userManager.CreateAsync(user, APCRMConstants.DefaultUserPassword);
                if (result.Succeeded)
                {
                    if (model.newuser.RoleSelected != null && model.newuser.RoleSelected.Length > 0)
                    {
                        await _userManager.AddToRoleAsync(user, model.newuser.RoleSelected);
                    }
                    TempData["Success"] = "User Created Successfully!";
                }
                else
                {
                    IdentityError? error = result.Errors.FirstOrDefault();
                    TempData["Failure"] = error?.Description;
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> LockUnlockUser(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                AppUser user = await _userManager.FindByIdAsync(Id);
                if (user != null)
                {
                    if (user.LockoutEnabled)
                    {
                        await _userManager.SetLockoutEnabledAsync(user, !user.LockoutEnabled);
                        await _userManager.SetLockoutEndDateAsync(user, null);
                        TempData["Success"] = user.FullName+" has been Unlocked";
                    }
                    else
                    {
                        await _userManager.SetLockoutEnabledAsync(user, !user.LockoutEnabled);
                        await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
                        TempData["Success"] = user.FullName + " has been Locked";
                    }
                }
            }
            return RedirectToAction("Index");
        }
    }
}
