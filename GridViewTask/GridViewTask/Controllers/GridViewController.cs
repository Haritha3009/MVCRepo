using GridViewTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace GridViewTask.Controllers
{
    public class GridViewController : Controller
    {
        List<StudentForm> sf = new List<StudentForm>();
        // GET: GridView
      
        [HttpGet]
        public ActionResult StudentForm()
        {
            List<SelectListItem> cities = new List<SelectListItem>() {
        new SelectListItem {
            Text = "Pune",
        },
        new SelectListItem {
            Text = "Hyderabad",
        },
        new SelectListItem {
            Text = "Chennai",
        },
        new SelectListItem {
            Text = "Mumbai",
        } };
            ViewData["Cities"] = cities.ToList();
            StudentForm studentForm = new StudentForm();

            return View();
        }
        [HttpPost]
        public ActionResult StudentForm(StudentForm s)
        {
            StudentForm studentForm = new StudentForm();

            studentForm.StudentId = s.StudentId;
            studentForm.Name = s.Name;
            studentForm.Gender = s.Gender;
            studentForm.City = s.City;
            studentForm.ScholarshipApplicable = s.ScholarshipApplicable;
            sf.Add(studentForm);

            return View("Grid", sf);
        }
    }


}
