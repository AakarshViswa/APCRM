using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APCRM.Web.Controllers
{    
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
            model.role = new IdentityRole();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(RoleViewModel model)
        {
            if (model != null && model.role != null)
            {
                if (!await _roleManager.RoleExistsAsync(model.role.Name))
                {
                    IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(model.role.Name));
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Role Added SuccessFully";
                    }
                    else
                    {
                        TempData["Failure"] = "Some Error While Adding Entries. Kindly Try After sometime";
                    }
                }
                else
                {
                    TempData["Failure"] = "Role Already Exists.";
                }
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> EditRole(string Id)
        {
            RoleViewModel model = new RoleViewModel();
            if (!String.IsNullOrEmpty(Id))
            {
                model.role = await _roleManager.FindByIdAsync(Id);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditRole(RoleViewModel model)
        {
            if (model != null && model.role != null)
            {
                if (!await _roleManager.RoleExistsAsync(model.role.Name))
                {
                    IdentityResult result = await _roleManager.UpdateAsync(model.role);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Role Updated SuccessFully";
                    }
                    else
                    {
                        TempData["Failure"] = "Some Error While Editing Entries. Kindly Try After sometime";
                    }
                }
                else
                {
                    TempData["Failure"] = "Cannot Edit the Role, Since there is no change in role name";
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteRole(string Id)
        {
            if (!string.IsNullOrEmpty(Id))
            {
                IdentityRole role = await _roleManager.FindByIdAsync(Id);
                if (role != null)
                {
                    IdentityResult result = await _roleManager.DeleteAsync(role);
                    if (result.Succeeded)
                    {
                        TempData["Success"] = "Role -" + role.Name + " Deleted SuccessFully";
                    }
                    else
                    {
                        TempData["Failure"] = "Some Error While Deleting Entries. Kindly Try After sometime";
                    }
                }
                else
                {
                    TempData["Failure"] = "Cannot Delete the Role, Since there is no such Role";
                }
            }
            return RedirectToAction("Index");
        }
    }
}
