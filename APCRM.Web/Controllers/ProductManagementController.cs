using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APCRM.Web.Controllers
{
    public class ProductManagementController : Controller
    {
        private readonly IDataAccess _da;
        private readonly UserManager<AppUser> _usrMgr;
        public ProductManagementController(IDataAccess da, UserManager<AppUser> usrMgr)
        {
            _da = da;
            _usrMgr = usrMgr;
        }
        public async Task<IActionResult> Index()
        {
            ProductViewModel model = new ProductViewModel();
            model.products = await _da.product.GetAllProductAsync();
            model.product = new Product();
            return View(model);
        }
                
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(ProductViewModel model)
        {
            AppUser user = await _usrMgr.GetUserAsync(User);
            if (model != null && model.product != null)
            {
                if (!string.IsNullOrEmpty(model.product.ProductName))
                {
                    Product product = new Product
                    {
                        ProductName = model.product.ProductName,
                        ProductPrice = model.product.ProductPrice,
                        CreatedBy = user,
                        UpdatedBy = user
                    };

                    Product p = await _da.product.GetFirstOrDefaultAsync(x => x.ProductName == model.product.ProductName);
                    if (p == null)
                    {
                        _da.product.AddAsync(product);
                        _da.Save();
                        TempData["Success"] = "Product has been Added";
                    }
                    else
                    {
                        TempData["Info"] = "Product - " + p.ProductName.ToLower() + " is Already Added";
                    }
                }
            }
            return RedirectToAction("Index", "ProductManagement");
        }

        public async Task<IActionResult> EditProduct(int Id)
        {
            ProductViewModel model = new ProductViewModel();
            if (Id > 0)
            {
                model.product = await _da.product.GetFirstOrDefaultAsync(e => e.Id == Id);
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProduct(ProductViewModel model)
        {
            AppUser user = await _usrMgr.GetUserAsync(User);
            if (model != null && model.product != null)
            {
                model.product.UpdatedBy = user;
                model.product.UpdatedAt = DateTime.Now;
                _da.product.Update(model.product);
                _da.Save();
                TempData["Success"] = "Product - " + model.product.ProductName + " has been Updated";
            }
            return RedirectToAction("Index", "ProductManagement");
        }

        public async Task<IActionResult> DeleteProduct(int Id)
        {
            if (Id > 0)
            {
                Product product = await _da.product.GetFirstOrDefaultAsync(e => e.Id == Id);
                if (product != null)
                {
                    _da.product.Remove(product);
                    _da.Save();
                    TempData["Success"] = "Product - " + product.ProductName + " has been Deleted";
                }
            }
            return RedirectToAction("Index","ProductManagement"); 
        }
    }
}
