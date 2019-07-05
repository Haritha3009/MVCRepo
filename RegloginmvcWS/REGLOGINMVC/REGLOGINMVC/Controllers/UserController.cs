using BAL;
using CustomModel;
using REGLOGINMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace REGLOGINMVC.Controllers
{
    public class UserController : Controller
    {
        BusinessLogic bl = new BusinessLogic();
        public ActionResult Registration()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registration(ViewModel viewModel)
        {
            CommonClass cc = new CommonClass();
            cc.EMail = viewModel.user.EMail;
            cc.FName = viewModel.userPersonal.FName;
            cc.LName = viewModel.userPersonal.LName;
            cc.Password = viewModel.user.Password;
            cc.Phone = viewModel.userPersonal.Phone;
            cc.Gender = viewModel.userPersonal.Gender;
            cc.DOB = viewModel.userPersonal.DOB;
            cc.Address = viewModel.userPersonal.Address;
            var t = bl.verifyEmail(cc.EMail);
           // var t = bl.verifyDbEmail(cc.EMail);
            if (t)
            {
                ViewBag.message1 = "User already Exists!!";
            }
            else
            {
                var k = bl.AddData(cc);
                if (k)
                {
                    ViewBag.message = "Data recorded";
                }
                else
                {
                    ViewBag.message = "Invalid Data ";
                }
            }
            return View();
            
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(ViewModel vm)
        {
            CommonClass cc = new CommonClass();
            cc.EMail = vm.user.EMail;
            cc.Password = vm.user.Password;
            var k = bl.verifyUser(cc);
            if (k) {
               TempData["user"]=vm.user.EMail;
                return RedirectToAction("Home");
            }
            else
            {
                return View();
            }
        }
        public ActionResult Home()
        {
            ViewBag.user = TempData["user"];
            ViewBag.userlog = TempData["userlog"];
            List<CommonClass1> lst = bl.userDetails().ToList();
            List<CustomView> list = new List<CustomView>();
            int age = 0;
            foreach (var item in lst)
            {
                DateTime old = Convert.ToDateTime(item.DOB);
                if (DateTime.Now > old)
                {
                    age = DateTime.Now.AddYears(-old.Year).Year;
                }
                CustomView vm = new CustomView();
                vm.UserPersonalId = item.UserPersonalId;
                vm.FName = item.FName;
                vm.EMail = item.EMail;
                vm.LName = item.LName;
                vm.Phone = item.Phone;
               
                vm.Gender = item.Gender;
                vm.Age = age;
               
                list.Add(vm);
            }
            return View(list);
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            //TempData["userlog"] = TempData["user"];
            IEnumerable<CommonClass1> em = bl.edit(id);
            CustomView k = new CustomView();
            int age = 0;
            foreach (var item in em)
            {
                DateTime old = Convert.ToDateTime(item.DOB);
                if (DateTime.Now > old)
                {
                    age = DateTime.Now.AddYears(-old.Year).Year;
                }
                CustomView p = new CustomView();
                p.UserPersonalId = item.UserPersonalId;
                p.FName = item.FName;
                p.LName = item.LName;
                p.Phone = item.Phone;
                p.EMail = item.EMail;
                TempData["userlog"] = item.EMail;
               p.Gender = item.Gender;
                p.Age = age;
               k = p;
                return View(p);
            }
            return View(k);
        }
        [HttpPost]
       
        public ActionResult Edit(CustomView cv)
        {
            int mnth = Convert.ToInt32(DateTime.Now.Month);
            int day = Convert.ToInt32(DateTime.Now.Day);
            int year = Convert.ToInt32(DateTime.Now.Year - cv.Age);
            DateTime bday = new DateTime(year, mnth, day);
            DateTime dob;
            dob = bday;
            CommonClass1 cc = new CommonClass1();
            cc.UserPersonalId = cv.UserPersonalId;
            cc.EMail = cv.EMail;
            cc.FName = cv.FName;
            cc.LName = cv.LName;
            cc.Phone = cv.Phone;
            cc.DOB = dob;
            cc.Gender = cv.Gender;

            var isThere = bl.editUser(cc);
            if (isThere)
            {
                return RedirectToAction("Home");
            }
            return View();
        }

    }
}
