using Ninject;
using Progress.Domain.Data;
using Progress.Domain.Interface;
using Progress.Models;
using Progress.Services.Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Progress.Infrastructure.Data;
using System.Web.Mvc;
using Progress.Infrastructure.Bussiness;

namespace Progress.Controllers
{
    public class HomeController : Controller
    {
        //CustomerContext db = new CustomerContext();
        ICustomerRepository _customer;
        IResult _result;
        public HomeController() 
        {
            IKernel ninjectKernel = new StandardKernel();
            ninjectKernel.Bind<ICustomerRepository>().To<CustomerRepository>();
            _customer = ninjectKernel.Get<ICustomerRepository>();
            ninjectKernel.Bind<IResult>().To<GetResult>();
            _result = ninjectKernel.Get<IResult>();
        }
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(Customer customer)
        {
            if(ModelState.IsValid)
            {
                _customer.Create(customer);
                _customer.Save();
                _result.CreateResult(customer);
                _result.FinishOfWork(customer);
                (double alltime, double timeForWork, double workTimeWitPlayTime) a = _result.CreateResult(customer);
                ViewBag.TimeForWork = a;
                ViewBag.ResultTime = _result.FinishOfWork(customer);
                return View("Result");
               
            }
            return View();
        }
        
        public ActionResult Result()
        {
            return View();
        }
       
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}