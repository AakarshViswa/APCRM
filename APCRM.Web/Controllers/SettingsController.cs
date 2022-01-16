using Microsoft.AspNetCore.Mvc;

namespace APCRM.Web.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
