using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using APCRM.Web.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace APCRM.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }


        [HttpGet]
        public async Task<IActionResult> Register()
        {
            if(!await _roleManager.RoleExistsAsync("Tech Evangelist"))
            {
                await _roleManager.CreateAsync(new IdentityRole("Tech Evangelist"));
                await _roleManager.CreateAsync(new IdentityRole("Owner / proprietor"));
            }

            //List<SelectListItem> listitems = _roleManager.Roles.Select(x => new { x.Id,x.Name }).ToList();
            List<SelectListItem> listitems = new List<SelectListItem>();
            var rolelist = _roleManager.Roles.Select(x => new { x.Id, x.Name }).ToList();
            foreach(var role in rolelist)
            {
                SelectListItem item = new SelectListItem();
                item.Text = role.Name;
                item.Value = role.Name;
                listitems.Add(item);
            }
            RegisterViewModel registerViewModel = new RegisterViewModel();
            registerViewModel.RoleList = listitems;
            return View(registerViewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new AppUser
                {
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Photo = APCRMConstants.DefaultPhoto,
                    UserName = model.Email
                };
                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    if(model.RoleSelected!=null && model.RoleSelected.Length>0)
                    {
                        await _userManager.AddToRoleAsync(user, model.RoleSelected);
                        
                    }
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    TempData["Failure"] = result?.Errors?.FirstOrDefault()?.Description;
                }
            }
            return View(model);
        }


        [HttpGet]
        public async Task<IActionResult> Login(string returnurl = null)
        {
            ViewData["ReturnURL"] = returnurl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model,string? returnurl =null)
        {
            ViewData["ReturnURL"] = returnurl;
            
            if (ModelState.IsValid)
            {                
                var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    if (returnurl == null)
                        return RedirectToAction("Index", "Home");
                    else
                        return LocalRedirect(returnurl);
                 }
                else
                {
                    TempData["Failure"] = "Invalid Login Attempt";
                }
            }
            return View(model);
        }

        public async Task<IActionResult> Logout()
        {            
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

    }
}
