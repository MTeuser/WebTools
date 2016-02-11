using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
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

        public ActionResult Details(int idTool = 0)
        {
            Tool_vm ToolVmList = new Tool_vm();
            ToolVmList = GetToolsProperties().Where(t => t.idTool == idTool).OrderByDescending(t => t.InsDateTime).FirstOrDefault();
            //foreach (Tool_vm tool in ToolVmList)
            //{
            //    User user = db.GetUsers().Where(u => u.idUser == Convert.ToInt32(tool.idUser)).FirstOrDefault();
            //    if (user != null)
            //    {
            //        tool.idUser = user.FirstName + " " + user.LastName;
            //    }
            //}
           
                ViewBag.idCatalog = ToolVmList.IdCatalog;
           
            return View("partialDetails",ToolVmList);            
        }

        //
        // GET: /Tool/Create

        public ActionResult Create(int idToolType)
        { 
            List<Tool_vm> ToolVmList = new List<Tool_vm>();
            ToolVmList = GetToolsProperties().OrderByDescending(t => t.InsDateTime).ToList();
            foreach(Tool_vm tool in ToolVmList)
            {
                User user = db.GetUsers().Where(u => u.idUser == Convert.ToInt32(tool.idUser)).FirstOrDefault();
                if (user != null)
                {
                    tool.idUser = user.FirstName + " " + user.LastName;
                }
            }
            ViewBag.idCatalog = 0;
            if (ToolVmList.Count > 0)
            {
                ViewBag.idCatalog = ToolVmList.FirstOrDefault().IdCatalog;
            }          
            return View(ToolVmList);
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
        public ActionResult Edit(int idTool)
        {
            Tool_vm tool_tool = GetToolsProperties().Where(t => t.idTool == idTool).FirstOrDefault();                        
            return View("partialEdit",tool_tool);
        }

        //
        // POST: /Tool/Edit/5

        [HttpPost]
        public ActionResult SaveEdit(FormCollection formCollection)
        {
            int idUser = 1;
            if (Session["idUser"] != null)
            {
                idUser = (int)Session["idUser"];
            }
            int idTool = Convert.ToInt32(formCollection["idTool"]);

            if (idTool > 0)
            {
                int index = 0;
                foreach (var key in formCollection.AllKeys)
                {
                    //index fc.keys -1, Jquery add value.
                    if (index > 1 && index < formCollection.Keys.Count - 1)
                    {
                        var value = formCollection[key];
                        Tool_ToolDetail Td = db.Update(new Tool_ToolDetail
                        {
                            idTool = idTool,
                            idProperty = Convert.ToInt32(key),
                            Value = value
                        });
                    }
                    index++;
                }
            }
            return Json(new { Success = 1 }, "application/json", JsonRequestBehavior.AllowGet);
        }

        //
        // GET: /Tool/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Tool_Tool tool_tool = db.GetTools(new Tool_Tool { idTool = id }).Single();           
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
            
            return View("Create");
        }        

        public ActionResult GetProperties(int idCatalog)
        {
            var PropertyList = db.GetPropertiesByCatalogId(idCatalog);
            return View(PropertyList);            
        }

        public ActionResult GetTools()
        {
           return Json(GetToolsProperties(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult New(int idCatalog)
        {
            List<Tool_Property> PropertyList = db.GetToolProperties(new Tool_Property { IdCatalog = idCatalog });
            //int[] aNum = {8,9,10,11,12,13,14,15};
            PropertyList = PropertyList.Where(p => p.ViewUI > 7).ToList();

            ViewBag.idCatalog = idCatalog;
            return View("partialNewTool", PropertyList);
        }

       
        public ActionResult AddNew(FormCollection fc)
        {
            int idUser = 1;
            if (Session["idUser"] != null)
            {
                idUser = (int)Session["idUser"];
            }
            Tool_Tool Tool = db.Create(new Tool_Tool { idUser = idUser, 
                                                        IdCatalog = Convert.ToInt32(fc["IdCatalog"]) 
                                                      });
            
            if (Tool.idTool > 0)
            {
                int index = 0;
                foreach (var key in fc.AllKeys)
                {
                    //index fc.keys -1, Jquery add value.
                    if (index > 1 && index < fc.Keys.Count - 1) 
                    {
                        var value = fc[key];
                        Tool_ToolDetail Td = db.Create(new Tool_ToolDetail { 
                                                        idTool = Tool.idTool, 
                                                        idProperty = Convert.ToInt32(key),
                                                        Value = value
                                                    });
                    }
                    index++;
                }
            }
            return Json(new { Success = 1 }, "application/json", JsonRequestBehavior.AllowGet);
        }

        private List<Tool_vm> GetToolsProperties()
        {
             List<Tool_Tool> Tools = db.GetTools();
            List<Tool_vm> vTools = new List<Tool_vm>();
            List<Property_vm> vPropertyList = new List<Property_vm>();
            Tool_vm vmTool = new Tool_vm();
            int idCurrentTool = 0;            
            foreach(Tool_Tool Tool in Tools)
            {
                if (idCurrentTool == 0)
                {
                    idCurrentTool = Tool.idTool;
                    vmTool.idTool = Tool.idTool;
                    vmTool.idUser = Tool.idUser.ToString();
                    vmTool.Active = Tool.Active;
                    vmTool.IdCatalog = Tool.IdCatalog;
                    vmTool.InsDateTime = Tool.InsDateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    vmTool.UpdDateTime = Tool.UpdDateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                }                
                    
               if (idCurrentTool != Tool.idTool)
               {               
                    vmTool.Properties = vPropertyList;
                    vTools.Add(vmTool);
                    vPropertyList = new List<Property_vm>();
                    vmTool = new Tool_vm();

                    vmTool.idTool = Tool.idTool;
                    vmTool.idUser = Tool.idUser.ToString();
                    vmTool.Active = Tool.Active;
                    vmTool.IdCatalog = Tool.IdCatalog;
                    vmTool.InsDateTime = Tool.InsDateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    vmTool.UpdDateTime = Tool.UpdDateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                }
               Property_vm Property = new Property_vm();
               Property.idProperty = Convert.ToInt32(Tool.idProperty);
               Property.IdCatalog = Convert.ToInt32(Tool.IdCatalog);
               Property.Value = Tool.Value ?? "";
               Property.Name = Tool.Name;
               Property.ViewUI = Tool.ViewUI;
               Property.LabelUI = Tool.LabelUI;
               vPropertyList.Add(Property);                
               
                idCurrentTool = Tool.idTool;
            }
            vmTool.Properties = vPropertyList;
            vTools.Add(vmTool);

            return vTools;
        }

        public ActionResult Search(string Tag, string Status, string Stdkgtonslan, string Calibre)
        {
            List<Tool_vm> ToolList = GetToolsProperties();
            List<Tool_vm> vToolList = new List<Tool_vm>();
            vToolList = ToolList;
            if(!string.IsNullOrEmpty(Tag))
            {
                vToolList = vToolList.Where(t => t.Tag.Equals(Tag)).ToList();
            }
            if (!string.IsNullOrEmpty(Status))
            {

                vToolList = vToolList.Where(t => t.Properties.Where(p => p.Name.Equals("Estado") && p.Value.Contains(Status)).ToList().Count > 0)                                                            
                                    .ToList();
                                   
            }
            if (!string.IsNullOrEmpty(Stdkgtonslan))
            {
                vToolList = vToolList.Where(t => t.Properties.Where(p => p.Name.Equals("Stdkgtonslan")).ToList().Count > 1)
                                    .ToList()
                                    .Where(o => o.Properties.Where(p => p.Value.Equals(Stdkgtonslan)).ToList().Count > 1).ToList();
            }
            if (!string.IsNullOrEmpty(Calibre))
            {
                vToolList = vToolList.Where(t => t.Properties.Where(p => p.Name.Equals("Calibre")).ToList().Count > 1)
                                    .ToList()
                                    .Where(o => o.Properties.Where(p => p.Value.Equals(Calibre)).ToList().Count > 1).ToList();
            }
            

            vToolList = vToolList.OrderByDescending(t => t.InsDateTime).ToList();
            ViewBag.idCatalog = 0;
            if (vToolList.Count > 0)
            {
                ViewBag.idCatalog = vToolList.FirstOrDefault().IdCatalog;
            }

            return View("Create", vToolList);
        }
    }
}