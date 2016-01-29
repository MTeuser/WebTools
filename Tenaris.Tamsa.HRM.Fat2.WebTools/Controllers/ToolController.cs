using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tenaris.Tamsa.HRM.Fat2.DataAccess;
using Tenaris.Tamsa.HRM.Fat2.DataAccess.Models;

namespace Tenaris.Tamsa.HRM.Fat2.WebTools.Controllers
{
    public class ToolController : Controller
    {
        private DataAccess.DataAccess db = new DataAccess.DataAccess();

        //
        // GET: /Tool/

        public ActionResult Index()
        {
            //var tool_tool = db.Tool_Tool.Include("Tool_Supplier").Include("Tool_Type").Include("User");
            var tool_tool = db.GetTools(null);

            //var Details = db.Tool_ToolDetail.Include("Tool_Property");

            return View(tool_tool);
        }

        //
        // GET: /Tool/Details/5

        public ActionResult Details(int id = 0)
        {
            Tool_Tool tool_tool = db.GetTools(new Tool_Tool { idTool = id }).FirstOrDefault();
            if (tool_tool == null)
            {
                return HttpNotFound();
            }
            return View(tool_tool);
        }

        //
        // GET: /Tool/Create

        public ActionResult Create()
        {
            int idType = 0;

            var TypeList = db.GetToolTypes();
            var SupplierList = db.GetSuppliersByToolType(idType);
            var UsersList = db.GetUsers();
            ViewBag.idSuplier = new SelectList(SupplierList, "idSupplier", "Code");
            ViewBag.idType = new SelectList(TypeList, "idType", "Name");
            ViewBag.idUser = new SelectList(UsersList, "idUser", "Identification");
            ViewBag.Diameters = new SelectList(db.GetDiameters(idType));
            return View();
        }

        //
        // POST: /Tool/Create

        [HttpPost]
        public ActionResult Create(Tool_Tool tool_tool)
        {
            if (ModelState.IsValid)
            {
                db.Create(tool_tool);
                return RedirectToAction("Index", "Home");
            }

            ViewBag.idSuplier = new SelectList(db.GetSuppliers(), "idSupplier", "Code", tool_tool.idSuplier);
            ViewBag.idType = new SelectList(db.GetToolTypes(), "idType", "Code", tool_tool.idType);
            ViewBag.idUser = new SelectList(db.GetUsers(), "idUser", "Identification", tool_tool.idUser);
            //return View("Home\Index.cshtml");
            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Tool/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Tool_Tool tool_tool = db.GetTools(new Tool_Tool { idTool = id }).Single();
            if (tool_tool == null)
            {
                return HttpNotFound();
            }
            ViewBag.idSuplier = new SelectList(db.GetSuppliers(), "idSupplier", "Code", tool_tool.idSuplier);
            ViewBag.idType = new SelectList(db.GetToolTypes(), "idType", "Code", tool_tool.idType);
            ViewBag.idUser = new SelectList(db.GetUsers(), "idUser", "Identification", tool_tool.idUser);
            return View(tool_tool);
        }

        //
        // POST: /Tool/Edit/5

        [HttpPost]
        public ActionResult Edit(Tool_Tool tool_tool)
        {
            if (ModelState.IsValid)
            {

                db.Edit(tool_tool);               
                return RedirectToAction("Index");
            }
            ViewBag.idSuplier = new SelectList(db.GetSuppliers(), "idSupplier", "Code", tool_tool.idSuplier);
            ViewBag.idType = new SelectList(db.GetToolTypes(), "idType", "Code", tool_tool.idType);
            ViewBag.idUser = new SelectList(db.GetUsers(), "idUser", "Identification", tool_tool.idUser);
            return View(tool_tool);
        }

        //
        // GET: /Tool/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tool_Tool tool_tool = db.GetTools(new Tool_Tool { idTool = id }).Single();
            if (tool_tool == null)
            {
                return HttpNotFound();
            }
            return View(tool_tool);
        }

        //
        // POST: /Tool/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Tool_Tool tool_tool = db.GetTools(new Tool_Tool { idTool = id }).Single();            
            return RedirectToAction("Index");
        }

        public ActionResult Find()
        {
            return View(new List<Tool_Tool>());
        }

        public ActionResult ToolTypes()
        {
            return View();
        }

        public ActionResult Properties()
        {
            return View();
        }

        public ActionResult AddTool(int ToolType)
        {
            return View("tipCreate");
        }

        

        public ActionResult GetProperties(int idType)
        {
            var PropertyList = db.GetPropertiesByTypeId(idType);
            return View(PropertyList);
            //return Content("Resultado from Controller");
        }

       

       
    }
}