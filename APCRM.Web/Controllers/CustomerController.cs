using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APCRM.Web.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IDataAccess _da;
        private readonly UserManager<AppUser> _usrMgr;
        public CustomerController(IDataAccess da, UserManager<AppUser> usrMgr)
        {
            _da = da;
            _usrMgr = usrMgr;
        }
        public async Task<IActionResult> Index()
        {
            CustomerViewModel model = new CustomerViewModel();
            model.customerDetails = await _da.customer.GetAllAsync();        
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            CustomerViewModel model = new CustomerViewModel();
            model.customerDetails = await _da.customer.GetAllAsync();            
            model.Customer = new CustomerDetails();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CustomerViewModel model)
        {
            AppUser user = await _usrMgr.GetUserAsync(User);
            if (model != null && model.Customer != null)
            {
                if (!string.IsNullOrEmpty(model.Customer.CustomerName))
                {
                    CustomerDetails customer = new CustomerDetails
                    { 
                        CustomerName = model.Customer.CustomerName,
                        CouplesName = model.Customer.CouplesName,
                        EmailAddress = model.Customer.EmailAddress,
                        PrimaryPhoneNumber = model.Customer.PrimaryPhoneNumber,
                        SecondaryPhoneNumber = model.Customer.SecondaryPhoneNumber,
                        Reference = model.Customer.Reference,
                        CreatedBy = user,
                        UpdatedBy=user
                    };

                    _da.customer.AddAsync(customer);
                    _da.Save();

                  
                    TempData["Success"] = "Customer has been Added";
                }
               
            }
            //CustomerDetails customer1 = await _da.customer.GetFirstOrDefaultAsync(c => c.CustomerName == model.Customer.CustomerName);
            //if (customer1 != null)
            //{
            //    customer1.CustomerID = CustomerDetails.CustomerPrefix + customer1.Id.ToString();
            //    _da.customer.Update(customer1);
            //    _da.Save();
            //}
            return RedirectToAction("Index", "Customer");
        }
    }
}
