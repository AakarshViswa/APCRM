using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APCRM.Web.Controllers
{
    public class DeliverableManagementController : Controller
    {
        private readonly IDataAccess _da;
        private readonly UserManager<AppUser> _usrMgr;
        public DeliverableManagementController(IDataAccess da, UserManager<AppUser> usrMgr)
        {
            _da = da;
            _usrMgr = usrMgr;
        }
        public async Task<IActionResult> Index()
        {
            DeliverableViewModel model = new DeliverableViewModel();
            model.deliverables = await _da.deliverable.GetAllDeliverableAsync();
            model.deliverable = new Deliverable();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(DeliverableViewModel model)
        {
            AppUser user = await _usrMgr.GetUserAsync(User);
            if (model != null && model.deliverable != null)
            {
                if (!string.IsNullOrEmpty(model.deliverable.DeliverableName))
                {
                    Deliverable deliverable = new Deliverable
                    {
                        DeliverableName = model.deliverable.DeliverableName,
                        DeliverablePrice = model.deliverable.DeliverablePrice,
                        CreatedBy = user,
                        UpdatedBy = user
                    };

                    Deliverable d = await _da.deliverable.GetFirstOrDefaultAsync(x => x.DeliverableName == model.deliverable.DeliverableName);
                    if (d == null)
                    {
                        _da.deliverable.AddAsync(deliverable);
                        _da.Save();
                        TempData["Success"] = "Deliverable has been Added";
                    }
                    else
                    {
                        TempData["Info"] = "Deliverable - " + d.DeliverableName.ToLower() + " is Already Added";
                    }
                }
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> EditDeliverable(int Id)
        {
            DeliverableViewModel model = new DeliverableViewModel();
            if (Id > 0)
            {
                model.deliverable = await _da.deliverable.GetFirstOrDefaultAsync(e => e.Id == Id);
            }
            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDeliverable(DeliverableViewModel model)
        {
            AppUser user = await _usrMgr.GetUserAsync(User);
            if (model != null && model.deliverable != null)
            {
                model.deliverable.UpdatedBy = user;
                model.deliverable.UpdatedAt = DateTime.Now;
                _da.deliverable.Update(model.deliverable);
                _da.Save();
                TempData["Success"] = "Deliverable - " + model.deliverable.DeliverableName + " has been Updated";
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeleteProduct(int Id)
        {
            if (Id > 0)
            {
                Deliverable deliverable = await _da.deliverable.GetFirstOrDefaultAsync(e => e.Id == Id);
                if (deliverable != null)
                {
                    _da.deliverable.Remove(deliverable);
                    _da.Save();
                    TempData["Success"] = "Deliverable - " + deliverable.DeliverableName + " has been Deleted";
                }
            }
            return RedirectToAction("Index");
        }
    }
}
