using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APCRM.Web.Controllers
{
    [Authorize]
    public class WorksheetController : Controller
    {
        private readonly IDataAccess _da;
        private readonly UserManager<AppUser> _usrMgr;
        private readonly IDataProvider _provider;

        public WorksheetController(IDataAccess da, UserManager<AppUser> usrMgr, IDataProvider provider)
        {
            _da = da;
            _usrMgr = usrMgr;
            _provider = provider;
        }

        public async Task<IActionResult> Index()
        {
            WorksheetViewModel model = new WorksheetViewModel();
            model.worksheets = await _da.worksheet.GetAllWorkSheets();
            model.worksheet = new Worksheet();
            return View(model);
        }
        public async Task<IActionResult> ViewWorksheet(int Id)
        {
            WorksheetViewModel model = new WorksheetViewModel();
            model.worksheets = await _da.worksheet.GetAllWorkSheets();
            model.worksheet = await _da.worksheet.GetWorksheet(Id);
            return View(model);
        }
    }
}
