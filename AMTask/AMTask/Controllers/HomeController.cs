using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CUSTOMMODELS;
using BAL;
using AutoMapper;
using AMTask.Models;


namespace AMTask.Controllers
    
{
   
    public class HomeController : Controller
    {
        BALClass b = new BALClass();
        public ActionResult Index()
        {
            return View();
        }

       public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(mvcmodelreg mr)
        {
            if (ModelState.IsValid)
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<mvcmodelreg, modelreg>();
                });

                IMapper mapper = config.CreateMapper();

                var dest = mapper.Map<mvcmodelreg, modelreg>(mr);
                var t = b.verifyDbEmail(dest.EMail);
                if (t)
                {
                    ViewBag.message1 = "User already Exists!!";
                }
                else
                {
                    var k = b.addDbData(dest);
                    if (k)
                    {
                        ViewBag.message = "Data recorded";
                    }
                    else
                    {
                        ViewBag.message = "Invalid Data ";
                    }
                }
            }
                return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(mvcregisValid mr)
        {
            //valids all the properties in the modelclass
            if (ModelState.IsValid)
           {
                //creation of mapper:from ui to login model
                var config1 = new MapperConfiguration(cfg =>
                {
                    cfg.CreateMap<mvcregisValid, modelreg>();
                });

                IMapper mapper1 = config1.CreateMapper();

                var dest = mapper1.Map<mvcregisValid, modelreg>(mr);
                var t = b.verifyDbUser(dest);
                if (t)
                {
                    return RedirectToAction("Home");
                }
                //else {
                //    return View();
                //}
                

            }
           return View("Registration");
        }
        public ActionResult Home()
        {

            return View();
        }
        //public ActionResult Home()
        //{
        //    return View();
        //}
    }
}