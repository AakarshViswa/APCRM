using APCRM.Web.Data;
using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace APCRM.Web.Controllers
{
    [Authorize]
    public class SettingsController : Controller
    {
        private readonly IDataAccess _da;

        public SettingsController(IDataAccess da)
        {
            _da = da;
        }

        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Settings";
            IEnumerable<AppSettings> model = await _da.settings.GetAllAsync();            
            return View(model);
        }
    }
}
