using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using APCRM.Web.Utility;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APCRM.Web.Controllers
{
    [Authorize]
    public class ProfileController : Controller
    {
        private readonly UserManager<AppUser> _usrMgr;
        private readonly SignInManager<AppUser> _signInMgr;


        public ProfileController(UserManager<AppUser> usrMgr, SignInManager<AppUser> signinMgr)
        {
            _usrMgr = usrMgr;
            _signInMgr = signinMgr;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ProfileViewModel model = await GetUserProfileDataAsync();
            return View(model);
        }

        private async Task<ProfileViewModel> GetUserProfileDataAsync()
        {
            ProfileViewModel model = new ProfileViewModel();
            AppUser user = await _usrMgr.GetUserAsync(User);
            if (user != null)
            {
                model.User = user;
                IList<string> role = await _usrMgr.GetRolesAsync(user);
                model.User.RoleName = (role != null ? role.FirstOrDefault().ToString() : String.Empty);
            }
            return model;
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ProfileViewModel model)
        {
            AppUser olduser = await _usrMgr.GetUserAsync(User);
            if (model != null)
            {
                AppUser newUser = await _usrMgr.FindByIdAsync(olduser.Id);
                newUser.FirstName = model.User.FirstName;
                newUser.LastName = model.User.LastName;
                newUser.Email = model.User.Email;
                newUser.UserName = model.User.Email; // since email is the username
                newUser.PhoneNumber = model.User.PhoneNumber;
                newUser.Photo = newUser.Photo;
                IdentityResult result = await _usrMgr.UpdateAsync(newUser);
                if (result.Succeeded)
                {
                    TempData["Success"] = "User Profile Updated Successfully";
                }
                else
                {
                    TempData["Failure"] = "Some Issue with Profile Update kindly reach out to DB Admin";
                }
            }
            ProfileViewModel modeltort = await GetUserProfileDataAsync();
            return View(modeltort);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ProfileViewModel model)
        {
            if (model != null)
            {
                if (!String.IsNullOrEmpty(model.CurrentPassword) && !String.IsNullOrEmpty(model.NewPassword) && !String.IsNullOrEmpty(model.ConfirmPassword))
                {
                    AppUser user = await _usrMgr.GetUserAsync(User);
                    bool verifyCurrentpwd = await _usrMgr.CheckPasswordAsync(user, model.CurrentPassword);
                    if (verifyCurrentpwd)
                    {
                        if (model.ConfirmPassword.Equals(model.NewPassword))
                        {
                            IdentityResult result = await _usrMgr.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);
                            if(result.Succeeded)
                            {
                                TempData["Success"] = "The Password Has been successfully Changed!";
                            }
                            else
                            {
                                TempData["Failure"] = "There is Some Server Error! Kindly Try Again";
                            }
                        }
                        else
                        {
                            TempData["Failure"] = "New Password is not equal to the confirm password! Kindly Try Again";
                        }
                    }
                    else
                    {
                        TempData["Failure"] = "Current Password is Wrong! Please Try Again";
                    }
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UploadImage(IFormFile File)
        {
            string base64image = APCRMConstants.DefaultPhoto;
            if (File!=null && File.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    File.CopyTo(ms);
                    var fileBytes = ms.ToArray();
                    base64image = Convert.ToBase64String(fileBytes);
                }
                AppUser user = await _usrMgr.GetUserAsync(User);
                AppUser newUser = await _usrMgr.FindByIdAsync(user.Id);               
                newUser.Photo = base64image;
                IdentityResult result = await _usrMgr.UpdateAsync(newUser);
                if(result.Succeeded)
                {
                    TempData["Success"] = "Profile Picture updated";
                }
                else
                {
                    TempData["Failure"] = "Some error in the application Kindly try after sometime";
                }
            }
            else
            {
                TempData["Info"] = "Please choose a profile image and click upload";
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetImage(IFormFile File)
        {
            string base64image = APCRMConstants.DefaultPhoto;
            AppUser user = await _usrMgr.GetUserAsync(User);
            AppUser newUser = await _usrMgr.FindByIdAsync(user.Id);
            newUser.Photo = base64image;
            IdentityResult result = await _usrMgr.UpdateAsync(newUser);
            if (result.Succeeded)
            {
                TempData["Success"] = "Profile Picture updated";
            }
            else
            {
                TempData["Failure"] = "Some error in the application Kindly try after sometime";
            }
            return RedirectToAction("Index");
        }
    }
}
