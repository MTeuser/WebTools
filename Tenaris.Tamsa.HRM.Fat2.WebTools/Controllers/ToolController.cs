using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tenaris.Tamsa.HRM.Fat2.DataAccess.AusV1;

namespace Tenaris.Tamsa.HRM.Fat2.WebTools.Controllers
{
    public class ToolController : Controller
    {
        private DataAccess.AusV1.DataAccess db = new DataAccess.AusV1.DataAccess();

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
            Tool_Tool tool_tool = db.GetTools(t => t.idTool == id).FirstOrDefault();
            if (tool_tool == null)
            {
                return HttpNotFound();
            }
            return View(tool_tool);
        }

        //
        // GET: /Tool/Create

        public ActionResult Create(string type)
        {
            int idType = 0;
            if (type.ToUpper().Equals("PUNTAS")) { idType = 1; }
            if (type.ToUpper().Equals("MANDRILES")) { idType = 2; }
            if (type.ToUpper().Equals("CILINDROS")) { idType = 3; }
            if (type.ToUpper().Equals("LINEALES")) { idType = 4; }

            ViewBag.idSuplier = new SelectList(db.GetSuppliers(s => s.Tool_Tool.Where(t => t.idTool == idType).ToList().Count > 0), "idSupplier", "Code");
            //ViewBag.idType = new SelectList(db.GetToolTypes(), "idType", "Code");
            //ViewBag.idUser = new SelectList(db.GetUsers(), "idUser", "Identification");
            ViewBag.Diameters = new SelectList(db.GetDiameters(idType));
            if (idType == 1) //puntas
            {
                return View("TipCreate");
            }
            else
            {
                //Hacer los casos de las demas herramientas
                return View("TipCreate");
            }
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
            Tool_Tool tool_tool = db.GetTools(t => t.idTool == id).Single();
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
            Tool_Tool tool_tool = db.GetTools(t => t.idTool == id).Single();
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
            Tool_Tool tool_tool = db.GetTools(t => t.idTool == id).Single();            
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();           
        }
    }
}