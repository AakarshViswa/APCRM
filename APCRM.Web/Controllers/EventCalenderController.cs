using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace APCRM.Web.Controllers
{
    [Authorize]
    public class EventCalenderController : Controller
    {
        private readonly IDataAccess _da;
        private readonly UserManager<AppUser> _usrMgr;
        public EventCalenderController(IDataAccess da, UserManager<AppUser> usrMgr)
        {
            _da = da;
            _usrMgr = usrMgr;
        }
        public async Task<IActionResult> Index()
        {            
            EventCalenderViewModel model = new EventCalenderViewModel();
            IEnumerable<Event> events = await _da.Event.GetAllAsync();
            IList<Eventjson> eventjsons = new List<Eventjson>();
            foreach (Event e in events)
            {
                Eventjson eventjson = new Eventjson() { id = e.Id.ToString(),title=e.EventTitle,start=e.EventStartDate,end=e.EventEndDate };
                eventjsons.Add(eventjson);
            }
            model.eventjsons = eventjsons;
            return View(model);
        }

        [HttpGet]
        public async Task<JsonResult> GetEventDetails()
        {
            IEnumerable<Event> events = await _da.Event.GetAllAsync();
            IList<Eventjson> eventjsons = new List<Eventjson>();
            foreach (Event e in events)
            {
                Eventjson eventjson = new Eventjson() { id = e.Id.ToString(), title = e.EventTitle, start = e.EventStartDate, end = e.EventEndDate };
                eventjsons.Add(eventjson);
            }
            return Json(eventjsons);
        }

    }
}
