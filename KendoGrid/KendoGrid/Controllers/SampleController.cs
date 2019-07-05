using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KendoGrid.Controllers
{
    public class SampleController : Controller
    {
        public kendoEntities ke;
        // GET: Sample
       
       
        public ActionResult Display_Details([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetDetails().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        public ActionResult Hom()
        {
            return View(ke.Details.ToList());
        }
        private static IEnumerable<Models.ModelClass> GetDetails()
        {
           // var northwind = new SampleEntities();
         var ke  = new kendoEntities();
            return ke.Details.Select(k => new Models.ModelClass
            {
                Id=k.Id,
                Name = k.Name,
                City= k.City
               
            });
        }
        public ActionResult Index([DataSourceRequest] DataSourceRequest request)
        {
            return View();
        }
        
    }
}