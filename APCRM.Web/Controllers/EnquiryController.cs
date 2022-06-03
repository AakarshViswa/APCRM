using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APCRM.Web.Controllers
{
    public class EnquiryController : Controller
    {
        private readonly IDataAccess _da;
        private readonly UserManager<AppUser> _usrMgr;
        private readonly IDataProvider _provider;
        public EnquiryController(IDataAccess da, UserManager<AppUser> usrMgr, IDataProvider provider)
        {
            _da = da;
            _usrMgr = usrMgr;
            _provider = provider;
        }
        public async Task<IActionResult> Index()
        {
            EnquiryViewModel model = new EnquiryViewModel();
            model.packages = await _da.package.GetAllPackageAsync();
            model.enquiryStatus = await _da.enquiryStatus.GetAllEnquiryAsync();
            model.eventtypes = await _da.eventType.GetAllAsync();
            model.enquiry = new Enquiry();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(EnquiryViewModel model)
        {
            try
            {
                AppUser sysuseruser = await _da.appUser.GetFirstOrDefaultAsync(u => u.FirstName == "SYSADMIN");
                EnquiryStatus es = await _da.enquiryStatus.GetFirstOrDefaultAsync(x => x.Name == "New Lead");
                if (model != null && model.enquiry != null)
                {
                    Enquiry enquiry = new Enquiry
                    {
                        CustomerName = model.enquiry.CustomerName,
                        CouplesName = model.enquiry.CouplesName,
                        Email = model.enquiry.Email,
                        PhoneNumber = model.enquiry.PhoneNumber,
                        EventDate = DateTime.Parse(model.EventStartDate + " " + model.EvenStartTime),
                        SessionType = model.enquiry.SessionType,
                        EventTypeId = model.enquiry.EventTypeId,
                        PackageId = model.enquiry.PackageId,
                        EventVenue = model.enquiry.EventVenue,
                        EventVenueAddress = model.enquiry.EventVenueAddress,
                        BrideMakeupLocation = model.enquiry.BrideMakeupLocation,
                        GroomMakeupLocation = model.enquiry.GroomMakeupLocation,
                        Remarks = model.enquiry.Remarks,
                        EnquiryStatusId = es.Id,
                        CreatedBy = sysuseruser,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        UpdatedBy = sysuseruser
                    };

                    _da.enquiry.AddAsync(enquiry);
                    _da.Save();
                    TempData["Success"] = "Thanks For your Enquiry! Our Team will reach you soon";
                }
                return RedirectToAction("Index", "Enquiry");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        [Authorize]
        public async Task<IActionResult> EnquiryManagement()
        {
            EnquiryViewModel model = new EnquiryViewModel();
            IEnumerable<Enquiry> enquiry = await _da.enquiry.GetAllEnquiryAsync();
            model.enquirylist = enquiry.OrderByDescending(x => x.CreatedAt);
            model.enquiryStatus = await _da.enquiryStatus.GetAllAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateEnquiryType(EnquiryViewModel model)
        {
            AppUser user = await _usrMgr.GetUserAsync(User);
            if (model != null && model.updateEnquiryStatusModel != null)
            {
                Enquiry enquiry = await _da.enquiry.GetFirstOrDefaultAsync(x => x.Id == model.updateEnquiryStatusModel.Id);
                if (enquiry != null)
                {
                    EnquiryStatus newEnquirystatus = await _da.enquiryStatus.GetFirstOrDefaultAsync(x => x.Id == model.updateEnquiryStatusModel.EnquiryStatusId);
                    if (newEnquirystatus != null && newEnquirystatus.Name.Equals("Customer"))
                    {
                        _provider.ConvertEnquiryintoCustomer(enquiry.Id);
                    }
                    else
                    {
                        enquiry.EnquiryStatusId = model.updateEnquiryStatusModel.EnquiryStatusId;
                        enquiry.UpdatedAt = DateTime.Now;
                        enquiry.UpdatedBy = user;

                        _da.enquiry.UpdateExisting(enquiry);
                        _da.Save();
                    }
                    TempData["Success"] = "Enquiry Status Has been Updated Successfully";
                }
            }
            return RedirectToAction("EnquiryManagement", "Enquiry");
        }

        public IActionResult ConvertIntoCustomer(int enquiryId)
        {
            if (enquiryId != 0)
            {
                _provider.ConvertEnquiryintoCustomer(enquiryId);
            }
            return RedirectToAction("EnquiryManagement", "Enquiry");
        }
    }
}
