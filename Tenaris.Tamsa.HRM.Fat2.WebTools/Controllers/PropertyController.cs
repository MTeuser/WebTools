using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tenaris.Tamsa.HRM.Fat2.DataAccess.Models;
using Tenaris.Tamsa.HRM.Fat2.DataAccess;

namespace Tenaris.Tamsa.HRM.Fat2.WebTools.Controllers
{
    public class PropertyController : Controller
    {
        //
        // GET: /Property/
        private DataAccess.DataAccess db = new DataAccess.DataAccess();

        public ActionResult Index()
        {
            return View();
        }

        
        public ActionResult Create()
        {
            return View();
        }
        
        [HttpPost]
        public ActionResult Create(Tool_Property entity)
        {
            return View();
        }

        public ActionResult Delete(int id)
        {
            return View();
        }

        public ActionResult Edit(int idProperty)
        {
            return View();
        }

        public ActionResult Edit(Tool_Property entity)
        {
            return View();
        }

        public ActionResult GetProperties(int idType)
        {
            var PropertyList = db.GetPropertiesByTypeId(idType);
            return View(PropertyList);            
        }

        //public JsonResult GetProperties(int idTypeTool)
        //{     
        //    var PropertyList = db.GetPropertiesByTypeId(idTypeTool);
        //    return Json(PropertyList , JsonRequestBehavior.AllowGet);
        //}
    }
}
