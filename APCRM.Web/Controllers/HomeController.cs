using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using APCRM.Web.ViewModel.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;

namespace APCRM.Web.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IDataAccess _da;
        private readonly UserManager<AppUser> _usrMgr;
        private readonly IDataProvider _provider;
        public HomeController(ILogger<HomeController> logger, IDataAccess da, UserManager<AppUser> usrMgr, IDataProvider provider)
        {
            _logger = logger;
            _da = da;
            _usrMgr = usrMgr;
            _provider = provider;
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {
            _logger.LogInformation("Hello Log Message");
            DashboardViewModel model = new DashboardViewModel();
            IList<Enquiry> enquiry = (IList<Enquiry>)await _da.enquiry.GetAllEnquiryAsync();
            IList<CustomerDetails> customerDetails = (IList<CustomerDetails>)await _da.customer.GetAllAsync();
            IList<Event> AllEvents = (IList<Event>)await _da.Event.GetAllAsync();
            IList<Worksheet> worksheets = (IList<Worksheet>)await _da.worksheet.GetAllWorkSheets();
            model.worksheets = worksheets.OrderBy(x => x.eventinfo.EventStartDate).ToList();
            model.EnquiryCount = enquiry.Count;
            model.EnquiryTodayCount = enquiry.Where(x => x.CreatedAt.Date == DateTime.Now.Date).Count();
            model.CustomerCountYTD = customerDetails.Count;
            model.CustomerTodayCount = customerDetails.Where(x => x.CreatedAt.Date == DateTime.Now.Date).Count();
            model.UpcommingEvents = AllEvents.Where(x => x.EventStartDate >= DateTime.Now).Take(15).OrderBy(y => y.EventStartDate).ToList();
            return View(model);
        }

        public IActionResult AccessDenied()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}