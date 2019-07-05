using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SampleKendoGrid.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SampleKendoGrid.Controllers
{
    public class SampleController : Controller
    {
        // GET: Sample
        public kendoEntities kt;
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Details([DataSourceRequest]DataSourceRequest request)
        {
            return Json(GetDetails().ToDataSourceResult(request),JsonRequestBehavior.AllowGet);
        }
        private static IEnumerable<ModelClass> GetDetails()
        {
            var kt = new kendoEntities();
            return kt.Details.Select(c => new ModelClass
            {
                Id = c.Id,
                Name = c.Name,
                City = c.City

            });
        }
       
    }
}