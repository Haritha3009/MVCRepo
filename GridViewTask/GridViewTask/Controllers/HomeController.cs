using GridViewTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GridViewTask.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
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
       [HttpGet]
        public ActionResult Valid()
        {
            return View();
           
        }
        [HttpPost]
        public ActionResult Valid(Class1 cl)
        {
            if (ModelState.IsValid)
            {
              
                return View("Valid");
            }
           
                return View("Valid");
            
        }
    }
}