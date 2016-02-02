using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tenaris.Tamsa.HRM.Fat2.DataAccess;
using Tenaris.Tamsa.HRM.Fat2.DataAccess.Models;
using Tenaris.Tamsa.HRM.Fat2.WebTools.Models;

namespace Tenaris.Tamsa.HRM.Fat2.WebTools.Controllers
{
    public class ToolController : Controller
    {
        private DataAccess.DataAccess db = new DataAccess.DataAccess();

        //
        // GET: /Tool/

        public ActionResult Index()
        {
            
            var tool_tool = db.GetTools();           

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

            //Se crea el viewModel que contendra el nuevo tipo de herramienta mientras se 
            //agregan propiedades.
           
            
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

            List<Tool_Type> Types = db.GetToolTypes();

            //ViewBag.idSuplier = new SelectList(db.GetSuppliers(), "idSupplier", "Code", tool_tool.idSuplier);
            //ViewBag.idType = new SelectList(db.GetToolTypes(), "idType", "Code", tool_tool.idType);
            //ViewBag.idUser = new SelectList(db.GetUsers(), "idUser", "Identification", tool_tool.idUser);
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
        }

        public ActionResult GetTools()
        {
            List<Tool_Tool> Tools = db.GetTools();
            List<ToolViewModel> vTools = new List<ToolViewModel>();
            foreach(Tool_Tool Tool in Tools)
            {
                ToolViewModel vmTool = new ToolViewModel();
                vmTool.Active = Tool.Active;
                vmTool.idSuplier = Tool.idSuplier;
                vmTool.idTool = Tool.idTool;
                vmTool.idType = Tool.idType;
                vmTool.idUser = Tool.idUser;
                vmTool.InsDateTime = Tool.InsDateTime;
                vmTool.Tag = Tool.Tag;
                vmTool.UpdDateTime = Tool.UpdDateTime;

                vmTool.Properties = db.GetPropertiesByTypeId(Tool.idType ?? 0);

                vTools.Add(vmTool);
            }


            return Json(vTools, JsonRequestBehavior.AllowGet);
        }
    }
}