using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APCRM.Web.Controllers
{
    public class EnquiryStatusController : Controller
    {     
        private readonly IDataAccess _da;
        private readonly UserManager<AppUser> _usrMgr;
        public EnquiryStatusController(IDataAccess da, UserManager<AppUser> usrMgr)
        {
            _da = da;
            _usrMgr = usrMgr;
        }
        public async Task<IActionResult> Index()
        {
            EnquiryStatusViewModel model = new EnquiryStatusViewModel();
            model.enquiryStatuses = await _da.enquiryStatus.GetAllEnquiryAsync();
            model.enquiryStatuses = model.enquiryStatuses.OrderBy(x => x.OrderBy);
            model.enquiryStatus = new EnquiryStatus();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(EnquiryStatusViewModel model)
        {           
            AppUser user = await _usrMgr.GetUserAsync(User);
            if (model != null && model.enquiryStatus != null)
            {
                if (!string.IsNullOrEmpty(model.enquiryStatus.Name))
                {
                    EnquiryStatus enquiryStatus = new EnquiryStatus
                    {
                        Name = model.enquiryStatus.Name,
                        CreatedBy = user,
                        UpdatedBy = user
                    };
                    _da.enquiryStatus.AddAsync(enquiryStatus);
                    _da.Save();
                    TempData["Success"] = "Enquiry Status has been Added";
                }
                else
                {
                    TempData["Failure"] = "Enquiry Status Cannot be Empty";
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteEnquiryStatus(int Id)
        {
            if (Id > 0)
            {
                EnquiryStatus enquiryStatus = await _da.enquiryStatus.GetFirstOrDefaultAsync(e => e.Id == Id);
                if (enquiryStatus != null)
                {
                    _da.enquiryStatus.Remove(enquiryStatus);
                    _da.Save();
                    TempData["Success"] = "Event Type - " + enquiryStatus.Name + " has been Deleted";
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditEnquiryStatus(int Id)
        {
            EnquiryStatusViewModel model = new EnquiryStatusViewModel();
            if (Id > 0)
            {
                model.enquiryStatus = await _da.enquiryStatus.GetFirstOrDefaultAsync(e => e.Id == Id);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEnquiryStatus(EnquiryStatusViewModel model)
        {
            AppUser user = await _usrMgr.GetUserAsync(User);
            if (model != null && model.enquiryStatus != null)
            {
                model.enquiryStatus.UpdatedBy = user;
                _da.enquiryStatus.Update(model.enquiryStatus);
                _da.Save();
                TempData["Success"] = "Event Type - " + model.enquiryStatus.Name + " has been Updated";
            }
            return RedirectToAction("Index");
        }

    }
}
