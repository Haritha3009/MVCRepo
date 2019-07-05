using AuthenticationNAuthorization.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthenticationNAuthorization.Controllers
{
    
    public class HomeController : Controller
    {
        mvcEntities3 db = new mvcEntities3();
       
       
        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(Registration reg )
        {
           if (ModelState.IsValid)
            {
               //mvcEntities db = new mvcEntities();
                db.Registrations.Add(reg);
                db.SaveChanges();

                return View("Login");
            }
            return View("Registration");

        }
        [HttpGet]
        public ActionResult Login()
        {

            return View();
        }
        [HttpPost]
        public ActionResult Login(Registration reg)
        {
           var isValid = db.Logins.Where(x => x.UserName == reg.UserName && x.Pwd == reg.Pwd);
            if (isValid!=null)
            {
                return View("Open");
            }
            return View();
            
        }
        [Authorize]
        public ActionResult Open()
        {

            return View(db.Registrations.ToList());
        }


    }
}