using APCRM.Web.DataAccess.Interface;
using APCRM.Web.Models;
using APCRM.Web.Models.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace APCRM.Web.Controllers
{
    [Authorize]
    public class CustomerController : Controller
    {
        private readonly IDataAccess _da;
        private readonly UserManager<AppUser> _usrMgr;
        private readonly IDataProvider _provider;
        public CustomerController(IDataAccess da, UserManager<AppUser> usrMgr,IDataProvider provider)
        {
            _da = da;
            _usrMgr = usrMgr;            
            _provider = provider;
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
                    _provider.UpdateCustomer(customer);
                    TempData["Success"] = "Customer has been Added";
                }               
            }
            
            return RedirectToAction("Index", "Customer");
        }

        public async Task<ActionResult> Delete(int Id)
        {
            if (Id > 0)
            {
                CustomerDetails customer = await _da.customer.GetFirstOrDefaultAsync(e => e.Id == Id);
                if (customer != null)
                {
                    _da.customer.Remove(customer);
                    _da.Save();
                    TempData["Success"] = "Customer / Lead - " + customer.CustomerName + " has been Deleted";
                }
            }
            return RedirectToAction("Index", "Customer");
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            CustomerViewModel model = new CustomerViewModel();
            model.customerDetails = await _da.customer.GetAllAsync();
            model.Customer = model.customerDetails.FirstOrDefault(x=>x.Id == id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CustomerViewModel model)
        {
            AppUser user = await _usrMgr.GetUserAsync(User);
            if (model != null && model.Customer != null)
            {
                if (!string.IsNullOrEmpty(model.Customer.CustomerName))
                {
                    CustomerDetails customer = new CustomerDetails
                    {
                        Id= model.Customer.Id,
                        CustomerID = model.Customer.CustomerID,
                        CustomerName = model.Customer.CustomerName,
                        CouplesName = model.Customer.CouplesName,
                        EmailAddress = model.Customer.EmailAddress,
                        PrimaryPhoneNumber = model.Customer.PrimaryPhoneNumber,
                        SecondaryPhoneNumber = model.Customer.SecondaryPhoneNumber,
                        Reference = model.Customer.Reference,
                        CreatedBy = user,
                        UpdatedBy = user
                    };

                    _da.customer.Update(customer);
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
