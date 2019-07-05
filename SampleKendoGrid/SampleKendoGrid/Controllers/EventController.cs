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
    public class EventController : Controller
    {
        public ActionResult Edit()
        {
            return View();
        }
        public ActionResult Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetAll().ToDataSourceResult(request), JsonRequestBehavior.AllowGet);
        }
        private static IEnumerable<ModelClass> GetAll()
        {
            var kt = new kendoEntities();
            return kt.Details.Select(c => new ModelClass
            {
                Id = c.Id,
                Name = c.Name,
                City = c.City

            });
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public void Editing_Create([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<Detail> dt)
        {
            var results = new List<ModelClass>();

            if (dt != null && ModelState.IsValid)
            {
                foreach (var t in dt)
                {
                    Detail d = new Detail();
                    d.Id = t.Id;
                    d.Name = t.Name;
                    d.City = t.City;
                    var k = new kendoEntities();
                    k.Details.Add(d);
                    k.SaveChanges();
                }
            }
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public void Editing_Update([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ModelClass> details)
        {

            foreach (var p in details)
            {
                Detail d = new Detail();
                d.Id = p.Id;
                d.Name = p.Name;
                d.City = p.City;
                var k = new kendoEntities();
                k.Entry(d).State = System.Data.Entity.EntityState.Modified;
                k.SaveChanges();
            }
        }
        [AcceptVerbs(HttpVerbs.Post)]
        public void Editing_Destroy([DataSourceRequest] DataSourceRequest request, [Bind(Prefix = "models")]IEnumerable<ModelClass> dt)
        {
            foreach (var kt in dt)
            {
                var entity = new Detail();
                var k = new kendoEntities();
                Detail d = k.Details.Find(kt.Id);
                k.Details.Remove(d);
                k.SaveChanges();
            }
        }
    }
}