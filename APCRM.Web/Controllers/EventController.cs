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
            return View(model);
        }
    }
}
