using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tenaris.Tamsa.HRM.Fat2.DataAccess.Models;
using Tenaris.Tamsa.HRM.Fat2.DataAccess;
using Tenaris.Tamsa.HRM.Fat2.WebTools.Models;

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
           Tool_vm vTool = (Tool_vm)Session["Tool"];
           vTool.Properties.Add(entity);
           Session["Tool"] = vTool;
           return Json(new { result = true, idType = vTool.idType });
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

        public ActionResult GetProperties(int idType, bool fromDb)
        {
            List<Tool_Property> PropertyList = null;
            if (Session["Tool"] != null && !fromDb)
            {   
                Tool_vm vModel = (Tool_vm)Session["Tool"];
                PropertyList = vModel.Properties;
            }
            if(PropertyList == null)
            {
                PropertyList = db.GetPropertiesByTypeId(idType);
                Tool_vm vModel = new Tool_vm();
                vModel.idType = idType;
                vModel.Properties = PropertyList;
                Session["Tool"] = vModel;
             }            
            return View(PropertyList);            
        }

        //public JsonResult GetProperties(int idTypeTool)
        //{     
        //    var PropertyList = db.GetPropertiesByTypeId(idTypeTool);
        //    return Json(PropertyList , JsonRequestBehavior.AllowGet);
        //}
    }
}
