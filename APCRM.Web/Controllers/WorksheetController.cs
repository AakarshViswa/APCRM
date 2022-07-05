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
            model.worksheetProducts = new List<WorksheetProduct>();
            model.worksheetDeliverables = new List<WorksheetDeliverable>();
            model.worksheetPaymentStatus = new WorksheetPaymentStatus();
            return View(model);
        }
        public async Task<IActionResult> ViewWorksheet(int Id)
        {
            WorksheetViewModel model = new WorksheetViewModel();
            WorkPhase workPhases = await _da.workPhase.GetFirstOrDefaultAsync(x => x.WorkPhaseCode.Equals("PS"));
            model.worksheets = await _da.worksheet.GetAllWorkSheets();
            model.worksheet = await _da.worksheet.GetWorksheet(Id);
            model.worksheetProducts = await _da.worksheetProduct.GetWorksheetProduct(Id);
            model.worksheetDeliverables = await _da.worksheetDeliverable.GetWorksheetDeliverable(Id);
            model.worksheetPaymentStatus = await _da.worksheetPaymentStatus.GetWorksheetPaymentStatus(Id);            
            model.workStatuses = await _da.workStatus.GetAllListAsync(x=>x.WorkPhaseId.Equals(workPhases.Id));
            return View(model);
        }
    }
}
