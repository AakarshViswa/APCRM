using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APCRM.Web.Controllers
{
    [Authorize]
    public class EventTypeController : Controller
    {
        private readonly IDataAccess _da;
        private readonly UserManager<AppUser> _usrMgr;
        public EventTypeController(IDataAccess da, UserManager<AppUser> usrMgr)
        {
            _da = da;
            _usrMgr = usrMgr;
        }

        public async Task<IActionResult> Index()
        {
            EventTypeViewModel model = new EventTypeViewModel();
            model.eventtypes = await _da.eventType.GetAllAsync();
            model.eventtype = new EventType();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(EventTypeViewModel model)
        {
            AppUser user = await _usrMgr.GetUserAsync(User);
            if (model != null && model.eventtype != null)
            {
                if (!string.IsNullOrEmpty(model.eventtype.EventName))
                {
                    EventType eventtype = new EventType
                    {
                        EventName = model.eventtype.EventName,
                        Createdby = user.Id,
                        User = user,
                        CreatedOn = DateTime.Now
                    };
                    _da.eventType.AddAsync(eventtype);
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

        public async Task<IActionResult> DeleteEventType(int Id)
        {
            if (Id > 0)
            {
                EventType eventType = await _da.eventType.GetFirstOrDefaultAsync(eventType => eventType.Id == Id);
                if (eventType != null)
                {
                    _da.eventType.Remove(eventType);
                    _da.Save();
                    TempData["Success"] = "Event Type - " + eventType.EventName + " has been Deleted";
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditEventType(int Id)
        {
            EventTypeViewModel model = new EventTypeViewModel();
            if (Id > 0)
            {
                model.eventtype = await _da.eventType.GetFirstOrDefaultAsync(eventType => eventType.Id == Id);
            }           
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditEventType(EventTypeViewModel model)
        {
            if (model!=null && model.eventtype != null)
            {
                _da.eventType.Update(model.eventtype);
                _da.Save();
                TempData["Success"] = "Event Type - " + model.eventtype.EventName + " has been Updated";
            }
            return View(model);
        }
    }
}
