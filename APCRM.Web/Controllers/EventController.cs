using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APCRM.Web.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private readonly IDataAccess _da;
        private readonly UserManager<AppUser> _usrMgr;
        public EventController(IDataAccess da, UserManager<AppUser> usrMgr)
        {
            _da = da;
            _usrMgr = usrMgr;
        }
        public async Task<IActionResult> Index()
        {
            EventViewModel model = new EventViewModel();
            model.events = new Event();
            model.Allevents =await _da.Event.GetAllAsync();
            model.customerDetails = await _da.customer.GetAllAsync();
            model.eventTypes = await _da.eventType.GetAllAsync();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(EventViewModel model)
        {
            AppUser user = await _usrMgr.GetUserAsync(User);
            if (model != null && model.events != null)
            {
                if (!string.IsNullOrEmpty(model.events.EventTitle))
                {
                    Event events = new Event
                    {
                        EventTitle = model.events.EventTitle,
                        EventTypeId = model.events.EventTypeId,
                        CustomerId = model.events.CustomerId,
                        EventStartDate = DateTime.Parse(model.evstartDate + " " + model.evstartTime),
                        EventEndDate = DateTime.Parse(model.evendtDate + " " + model.evendTime),
                        CreatedAt = DateTime.Now,
                        CreatedBy = user,
                        UpdatedAt  =DateTime.Now,
                        UpdatedBy = user
                    };
                   
                    _da.Event.AddAsync(events);
                    _da.Save();
                    TempData["Success"] = "Event Type has been Added";
                }
                else
                {
                    TempData["Failure"] = "Event Name Cannot be Empty";
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteEvent(int Id)
        {
            if (Id > 0)
            {
                Event events = await _da.Event.GetFirstOrDefaultAsync(e => e.Id == Id);
                if (events != null)
                {
                    _da.Event.Remove(events);
                    _da.Save();
                    TempData["Success"] = "Event Type - " + events.EventTitle + " has been Deleted";
                }
            }
            return RedirectToAction("Index");
        }
    }
}
