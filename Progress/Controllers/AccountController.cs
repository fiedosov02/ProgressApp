using Ninject;
using Progress.Domain.Data;
using Progress.Domain.Interface;
using Progress.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Progress.Controllers
{
    public class AccountController : Controller
    {
        ICustomerLogRepository _log;
        public AccountController()
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<ICustomerLogRepository>().To<CustomerLogRepository>();
            _log = ninjectKernel.Get<ICustomerLogRepository>();
        }
        // GET: Account
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(CustomerLog customerLog)
        {
            if (ModelState.IsValid)
            {
                Customer customer = null;
                customer = _log.GetCustomerForLogin(customerLog, customer);
                if (customer != null)
                {
                    FormsAuthentication.SetAuthCookie(customerLog.Login, true);
                    return RedirectToAction("MyAcc", "Account");
                }
                else
                {
                    ModelState.AddModelError("", "Error login and password");
                }
            }
            return View(customerLog);
        }
        public JsonResult CheckEmail(string username)
        {
            var result = Membership.FindUsersByName(username).Count == 0;
            return Json(result, JsonRequestBehavior.AllowGet);
        }
       
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(CustomerRegister customerRegister)
        {
            if(ModelState.IsValid)
            {
                Customer customer = null;
                //customer = db.Customers.FirstOrDefault(a => a.Email == customerRegister.Login); // searck customer with same login
               customer= _log.GetCustomer(customerRegister, customer);
                if (customer == null)
                {
                    customer = _log.Register(customerRegister, customer);
                    if (customer != null)
                    {
                        FormsAuthentication.SetAuthCookie(customerRegister.Login, true);
                        return RedirectToAction("Index", "Home");
                    }
                }
               

            }
            else
            {
                ModelState.AddModelError("", "Error login");
            }
            return View(customerRegister);
        }
        public ActionResult MyAcc()
        {
            return View();
        }
    }
}