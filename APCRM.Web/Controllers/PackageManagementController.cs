using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APCRM.Web.Controllers
{
    public class PackageManagementController : Controller
    {
        private readonly IDataAccess _da;
        private readonly UserManager<AppUser> _usrMgr;
        public PackageManagementController(IDataAccess da, UserManager<AppUser> usrMgr)
        {
            _da = da;
            _usrMgr = usrMgr;
        }
        public async Task<IActionResult> Index()
        {
            PackageViewModel model = new PackageViewModel();
            model.Packages = await _da.package.GetAllPackageAsync();
            model.package = new Package();
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> AddPackage()
        {
            PackageViewModel model = new PackageViewModel();
            model.Packages = new List<Package>();
            model.package = new Package();
            model.products = await _da.product.GetAllProductAsync();
            model.package.ProductDockets.Add(new ProductDocket());
            model.package.DeliverableDockets.Add(new DeliverableDocket());
            model.deliverables = await _da.deliverable.GetAllDeliverableAsync();
            model.isUpdate = false;
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> EditPackage(int Id)
        {
            PackageViewModel model = new PackageViewModel();
            model.Packages = new List<Package>();
            model.package = await _da.package.GetFirstOrDefaultAsync(x => x.Id == Id);
            model.products = await _da.product.GetAllProductAsync();
            model.deliverables = await _da.deliverable.GetAllDeliverableAsync();
            model.package.ProductDockets = (List<ProductDocket>)await _da.productDocket.GetAllListAsync(x => x.PackageId == model.package.Id);
            model.PLastIndex = (int)((model.package.ProductDockets?.Count - 1) != -1 ? model.package.ProductDockets?.Count - 1 : 0);
            model.package.DeliverableDockets = (List<DeliverableDocket>)await _da.DeliverableDocket.GetAllListAsync(x => x.PackageId == model.package.Id);
            model.DLastIndex = (int)((model.package.DeliverableDockets?.Count - 1) != -1 ? model.package.DeliverableDockets?.Count - 1 : 0);
            if (model.package.DeliverableDockets?.Count <= 0)
            {
                model.package.DeliverableDockets.Add(new DeliverableDocket());
            }
            if (model.package.ProductDockets?.Count <= 0)
            {
                model.package.ProductDockets.Add(new ProductDocket());
            }
            model.isUpdate = true;
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditPackage(PackageViewModel model)
        {
            if (model != null)
            {
                Package oldp = await _da.package.GetFirstOrDefaultAsync(x => x.Id == model.package.Id);
                AppUser createduser = oldp.CreatedBy;
                AppUser user = await _usrMgr.GetUserAsync(User);

                if (model.package != null)
                {
                    if (oldp != null)
                    {
                        
                        model.package.CreatedBy = createduser;
                        model.package.UpdatedBy = user;
                        model.package.UpdatedAt = DateTime.Now;

                        model.package.ProductDockets.ForEach(x => x.UpdatedBy = user);
                        model.package.ProductDockets.ForEach(x => x.CreatedBy = createduser);
                        model.package.ProductDockets.ForEach(x => x.UpdatedAt = DateTime.Now);


                        model.package.DeliverableDockets.ForEach(x => x.UpdatedBy = user);
                        model.package.DeliverableDockets.ForEach(x => x.CreatedBy = createduser);
                        model.package.DeliverableDockets.ForEach(x => x.UpdatedAt = DateTime.Now);

                        _da.package.Update(model.package);
                        _da.Save();
                    }
                }
            }
            else
            {
                TempData["Failure"] = "Some Error While Adding Package Contact administration";
            }
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> DeletePackage(int Id)
        {

            if (Id > 0)
            {
                Package package = await _da.package.GetFirstOrDefaultAsync(e => e.Id == Id);
                if (package != null)
                {
                    _da.package.Remove(package);
                    _da.Save();
                    TempData["Success"] = "Product - " + package.Name + " has been Deleted";
                }
            }
            return RedirectToAction("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddPackage(PackageViewModel model)
        {
            if (model != null)
            {
                AppUser user = await _usrMgr.GetUserAsync(User);
                if (model.package != null)
                {
                    model.package.CreatedBy = model.package.UpdatedBy = user;
                    model.package.ProductDockets.ForEach(x => x.UpdatedBy = user);
                    model.package.ProductDockets.ForEach(x => x.CreatedBy = user);
                    model.package.DeliverableDockets.ForEach(x => x.UpdatedBy = user);
                    model.package.DeliverableDockets.ForEach(x => x.CreatedBy = user);

                    _da.package.AddAsync(model.package);
                    _da.Save();

                }
            }
            else
            {
                TempData["Failure"] = "Some Error While Adding Package Contact administration";
            }
            return RedirectToAction("Index");
        }
    }
}
