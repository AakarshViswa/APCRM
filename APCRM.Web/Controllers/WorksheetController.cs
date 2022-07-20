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
            model.worksheetPaymentLogs = new List<WorksheetPaymentLog>();
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
            model.worksheetPaymentLogs = await _da.worksheetPaymentLog.GetWorksheetPaymentLog(Id);
            model.workStatuses = await _da.workStatus.GetAllListAsync(x => x.WorkPhaseId.Equals(workPhases.Id));
            model.StaffList = await GetTechnicalStaff();
            IEnumerable<PhotoshootSchedule> photoshootSchedules = await _da.photoshootSchedule.GetPhotoshootSchedule(Id);
            model.photoshootSchedules = photoshootSchedules.ToList();
            return View(model);
        }

        private async Task<IEnumerable<AppUser>> GetTechnicalStaff()
        {
            IEnumerable<AppUser> userlist = await _da.appUser.GetAllAsync();
            foreach (var user in userlist)
            {
                IList<string> role = await _usrMgr.GetRolesAsync(user);
                user.RoleName = role.FirstOrDefault();
            }
            userlist = userlist.Where(x => x.FirstName != "SYSADMIN").ToList();
            return userlist.OrderBy(x => x.FirstName);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SavePhotoShootScheduleAsync(WorksheetViewModel model)
        {
            int WorksheetId = model.photoshootSchedules.FirstOrDefault().WorkSheetId;

            IEnumerable<PhotoshootSchedule> photoshootSchedules = await _da.photoshootSchedule.GetPhotoshootSchedule(WorksheetId);
            IList<PhotoshootSchedule> psFromScreen = model.photoshootSchedules;
            foreach (PhotoshootSchedule ps in psFromScreen)
            {
                PhotoshootSchedule ps1 = photoshootSchedules.Where(x => x.Id == ps.Id).First();
                ps1.AssignedTo = ps.AssignedTo;
                if (ps1 != null)
                {
                    _da.photoshootSchedule.UpdateExisting(ps1);                   
                }
            }
            _da.Save();
            TempData["Success"] = "Photoshoot Schedule Updated Successfully!";
            return RedirectToAction("ViewWorksheet", new { Id = WorksheetId });
        }
    }
}
