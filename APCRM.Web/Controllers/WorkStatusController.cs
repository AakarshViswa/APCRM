using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APCRM.Web.Controllers
{
    public class WorkStatusController : Controller
    {
        private readonly IDataAccess _da;
        private readonly UserManager<AppUser> _usrMgr;
        public WorkStatusController(IDataAccess da, UserManager<AppUser> usrMgr)
        {
            _da = da;
            _usrMgr = usrMgr;
        }
        public async Task<IActionResult> Index()
        {
            WorkStatusViewModel model = new WorkStatusViewModel();
            model.workPhases = await _da.workPhase.GetAllAsync();
            model.WorkPhase = new WorkPhase();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWorkPhase(WorkStatusViewModel model)
        {           
            if (model != null && model.WorkPhase != null)
            {
                if (!string.IsNullOrEmpty(model.WorkPhase.WorkPhaseName))
                {
                    WorkPhase workphase = new WorkPhase
                    {
                        WorkPhaseName = model.WorkPhase.WorkPhaseName,
                        WorkPhaseCode = model.WorkPhase.WorkPhaseCode
                    };

                    _da.workPhase.AddAsync(workphase);
                    _da.Save();
                    TempData["Success"] = "Work Phase has been Added";
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteWorkPhase(int Id)
        {
            if (Id > 0)
            {
                WorkPhase workPhase = await _da.workPhase.GetFirstOrDefaultAsync(e => e.Id == Id);
                if (workPhase != null)
                {
                    _da.workPhase.Remove(workPhase);
                    _da.Save();
                    TempData["Success"] = "Deliverable - " + workPhase.WorkPhaseName + " has been Deleted";
                }
            }
            return RedirectToAction("Index");
        }
    }
}
