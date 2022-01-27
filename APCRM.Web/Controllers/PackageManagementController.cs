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
        
        public async Task<IActionResult> AddPackage()
        {
            PackageViewModel model = new PackageViewModel();
            model.Packages = new List<Package>();
            model.package = new Package();
            model.products = await _da.product.GetAllProductAsync();
            model.deliverables = await _da.deliverable.GetAllDeliverableAsync();
            return View(model);
        }
    }
}
