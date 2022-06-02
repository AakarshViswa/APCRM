using APCRM.Web.ViewModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace APCRM.Web.Controllers
{
    public class ErrorController : Controller
    {
        [Route("/Error/{code:int}")]
        public IActionResult Index(int Code)
        {
            ErrorViewModel model = new ErrorViewModel();
            model.Code = Code;
            return View(model);
        }
    }
}
