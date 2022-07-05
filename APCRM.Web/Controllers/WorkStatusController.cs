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

            model.workStatuses = await _da.workStatus.GetAllAsync(); 
            model.workStatus = new WorkStatus();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddWorkPhase(WorkStatusViewModel model)
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditWorkPhase(WorkStatusViewModel model)
        {
            if (model != null && model.EditWorkPhase != null)
            {
                WorkPhase wp = new WorkPhase
                {
                    Id = model.EditWorkPhase.Id,
                    WorkPhaseName = model.EditWorkPhase.WorkPhaseName,
                    WorkPhaseCode = model.EditWorkPhase.WorkPhaseCode
                };
                _da.workPhase.Update(wp);
                _da.Save();
                TempData["Success"] = "Work Phase - " + model.EditWorkPhase.WorkPhaseName + " has been Updated";
            }
            return RedirectToAction("Index", "WorkStatus");
        }

        public async Task<IActionResult> EditWorkPhase(int Id)
        {
            WorkStatusViewModel model = new WorkStatusViewModel();
            model.workPhases = await _da.workPhase.GetAllAsync();
            model.WorkPhase = new WorkPhase();
            model.workStatuses = await _da.workStatus.GetAllAsync();            
            model.EditWorkPhase = model.workPhases.FirstOrDefault(x => x.Id == Id);
            model.workStatus = new WorkStatus();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddWorkStatus(WorkStatusViewModel model)
        {
            if (model != null && model.workStatus != null)
            {
                if (!string.IsNullOrEmpty(model.workStatus.StatusName))
                {
                    WorkStatus workstatus = new WorkStatus
                    {
                        StatusName = model.workStatus.StatusName,
                        WorkPhaseId = model.workStatus.WorkPhaseId,
                        ColorCode = model.workStatus.ColorCode
                    };

                    _da.workStatus.AddAsync(workstatus);
                    _da.Save();
                    TempData["Success"] = "Work Status has been Added";
                }
            }
            return RedirectToAction("Index","WorkStatus", "#work-status");
        }

        public async Task<IActionResult> DeleteWorkStatus(int Id)
        {
            if (Id > 0)
            {
                WorkStatus workstatus = await _da.workStatus.GetFirstOrDefaultAsync(e => e.WorkStatusId == Id);
                if (workstatus != null)
                {
                    _da.workStatus.Remove(workstatus);
                    _da.Save();
                    TempData["Success"] = "Work Status - " + workstatus.StatusName + " has been Deleted";
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditWorkStatus(WorkStatusViewModel model)
        {            
            if (model != null && model.EditWorkStatus != null)
            {
                WorkStatus ws = new WorkStatus
                {
                    WorkStatusId= model.EditWorkStatus.WorkStatusId,
                    StatusName = model.EditWorkStatus.StatusName,
                    ColorCode = model.EditWorkStatus.ColorCode,
                    WorkPhaseId = model.EditWorkStatus.WorkPhaseId
                };
                _da.workStatus.Update(ws);
                _da.Save();
                TempData["Success"] = "Work Status - " + model.EditWorkStatus.StatusName + " has been Updated";
            }
            return RedirectToAction("Index", "WorkStatus");
        }

        public async Task<IActionResult> EditWorkStatus(int Id)
        {
            WorkStatusViewModel model = new WorkStatusViewModel();
            model.workPhases = await _da.workPhase.GetAllAsync();
            model.WorkPhase = new WorkPhase();
            model.workStatuses = await _da.workStatus.GetAllAsync();
            model.EditWorkStatus = model.workStatuses.FirstOrDefault(x => x.WorkStatusId == Id);
            model.workStatus = new WorkStatus();
            return View(model);
        }
    }
}
