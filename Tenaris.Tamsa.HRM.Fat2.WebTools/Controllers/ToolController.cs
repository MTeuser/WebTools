﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Globalization;
using System.IO;
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
            
            List<Tool_Type> tool_tool = db.GetToolTypes();           

            return View(tool_tool);
        }

        //
        // GET: /Tool/Details/5

        public ActionResult Details(int idTool = 0, int numCols = 2)
        {
            List<Tool_Tool> Tools = db.GetTools(new Tool_Tool { idTool = idTool }).ToList();
            Tool_vm ToolVmList = new Tool_vm();
            ToolVmList = GetToolsProperties(Tools).FirstOrDefault();
                ViewBag.idCatalog = ToolVmList.IdType;

                ViewBag.numCols = numCols;
                int dWitdh = 0;
                if (ToolVmList.Properties.Count > numCols)
                {
                    dWitdh = 380 * numCols;
                }
                else
                {
                    dWitdh = 380 * ToolVmList.Properties.Count;
                }

                dWitdh += 50;

                int dHeight = 0;
                dHeight = (70 * (ToolVmList.Properties.Count / numCols)) + (numCols * 40);


                return Json(new { DialogWidth = dWitdh, DialogHeight = dHeight, dContent = RenderRazorViewToString("partialDetails", ToolVmList) }, JsonRequestBehavior.AllowGet);
       
           
            //return View("partialDetails",ToolVmList);            
        }

        //
        // GET: /Tool/Create

        public ActionResult Create(int idToolType)
        { 
            List<Tool_vm> ToolVmList = new List<Tool_vm>();
            List<Tool_Tool> Tools = db.GetTools(new Tool_Tool {  IdType = idToolType });
            ToolVmList = GetToolsProperties(Tools.Where(t => (BitConverter.GetBytes(t.ViewUI)[0] & (1 << 1 - 1)) != 0).OrderByDescending(t => t.InsDateTime).ToList());

            foreach(Tool_vm tool in ToolVmList)
            {
                User user = db.GetUsers().Where(u => u.idUser == Convert.ToInt32(tool.idUser)).FirstOrDefault();
                if (user != null)
                {
                    tool.idUser = user.FirstName + " " + user.LastName;
                }
            }

            ViewBag.TypeName = db.GetToolTypes(new Tool_Type {  idType =  idToolType }).FirstOrDefault().Name;
            ViewBag.idType = idToolType;
                     
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
        public ActionResult Edit(int idTool, int numCols = 2)
        {
            List<Tool_Tool> Tools = db.GetTools(new Tool_Tool { idTool = idTool });
            Tool_vm tool_tool = GetToolsProperties(Tools).FirstOrDefault();

            tool_tool.Properties.RemoveAll(noViewIUInEdit);

            SelectList sSuppliers = null;
            SelectList sStatus = null;
            SelectList sDiameters = null;

            var Supplier = tool_tool.Properties.Where(p => p.Name.ToUpper().Contains("PROVEE")).FirstOrDefault();
            string sProperty = "";
            
            if (Supplier != null)
            {
                List<Tool_Supplier> SupplierList = db.GetSuppliers();                
                sSuppliers = new SelectList(SupplierList, "Code", "Code", Supplier.Value);
                //var selected = sSuppliers.Where(s => s.Value == Supplier.Value).FirstOrDefault();
                //selected.Selected = true;
                sProperty = Supplier.idProperty.ToString();
            }


            var Status = tool_tool.Properties.Where(p => p.Name.ToUpper().Contains("estado".ToUpper())).FirstOrDefault();
            if (Status != null)
            {
                List<SelectListItem> StatusList = new List<SelectListItem> ();
               
                StatusList.Add(new SelectListItem { Text="Usada",Value="Usada" });               
                StatusList.Add(new SelectListItem { Text="Nueva",Value="Nueva" });                
                StatusList.Add(new SelectListItem { Text = "Chatarra", Value = "Chatarra" });
                sStatus = new SelectList(StatusList, "Text", "Text",Status.Value);
            }

            var Diameter = tool_tool.Properties.Where(p => p.Name.ToUpper().Contains("metro".ToUpper())).FirstOrDefault();
            int Diam_idProperty = 3;
            if (Diameter != null)
            {
                Diam_idProperty = Diameter.idProperty;
                List<SelectListItem> DiametroList = new List<SelectListItem>();
                foreach (string d in db.GetDiameters(tool_tool.IdType, Diam_idProperty))
                {
                    DiametroList.Add(new SelectListItem { Text = d, Value = d });
                }
                sDiameters = new SelectList(DiametroList, "Text", "Value", Diameter.Value);
            }
            else
            {
                 List<SelectListItem> DiametroList = new List<SelectListItem>();
                 sDiameters = new SelectList(DiametroList, "Text", "Value");
            }
            
            ViewBag.idProperty = sProperty;
            ViewBag.Suppliers = sSuppliers;
            ViewBag.StatusList = sStatus;
            ViewBag.DiametroList = sDiameters;


            ViewBag.numCols = numCols;
            int dWitdh = 0;
            if (tool_tool.Properties.Count > numCols)
            {
                dWitdh = 380 * numCols;
            }
            else
            {
                dWitdh = 380 * tool_tool.Properties.Count;
            }

            dWitdh += 50;

            int dHeight = 0;
            dHeight = (70 * (tool_tool.Properties.Count / numCols)) + (numCols * 40);


            return Json(new
            {
                DialogWidth = dWitdh,
                DialogHeight = dHeight,
                dContent = RenderRazorViewToString("partialEdit", tool_tool)
            },
                              JsonRequestBehavior.AllowGet);     
           
           // return View("partialEdit",tool_tool);
        }

        // Search predicate returns true if a string ends in "saurus".
        private static bool noViewIUInEdit(Property_vm p)
        {
            return (BitConverter.GetBytes(p.ViewUI)[0] & (1 << 2 - 1)) == 0;
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
            string mkey = "17"; //Matricula must checking as as key of Tool
            if (formCollection[mkey].Trim().Length == 0)
            {
               
                return Json(new { Success = 0, Message = "Falta introducir algunos valores requeridos.", element = mkey }, JsonRequestBehavior.AllowGet);
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

        public ActionResult Delete(int idTool)
        {
            bool result = db.Delete(new Tool_Tool { idTool = idTool });
            return Json(new { Success = 1 }, JsonRequestBehavior.AllowGet);
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

        public ActionResult GetProperties(int idType)
        {
            var PropertyList = db.GetPropertiesByTypeId(idType);
            return View(PropertyList);            
        }

        public ActionResult GetTools()
        {
            List<Tool_Tool> Tools = db.GetTools();
            return Json(GetToolsProperties(Tools), JsonRequestBehavior.AllowGet);
        }

        public ActionResult New(int idType, int numCols = 2)
        {
            List<Tool_Property> PropertyList = db.GetPropertiesByTypeId(idType);
            //int[] aNum = {8,9,10,11,12,13,14,15};
            PropertyList = PropertyList.Where(p => (BitConverter.GetBytes(p.ViewUI)[0] & (1 << 4 - 1)) != 0).ToList();

            SelectList sSuppliers = null;
            SelectList sStatus = null;
            SelectList sDiameters = null;

            var Supplier = PropertyList.Where(p => p.Name.ToUpper().Contains("PROVEE")).FirstOrDefault();
            string sProperty = "";
            if (Supplier != null)
            {
                List<Tool_Supplier> SupplierList = db.GetSuppliers();
                sSuppliers = new SelectList(SupplierList, "Code", "Code", 1);
                sProperty = Supplier.idProperty.ToString();
            }


            var Status = PropertyList.Where(p => p.Name.ToUpper().Contains("estado".ToUpper())).FirstOrDefault();
            if (Status != null)
            {
                List<SelectListItem> StatusList = new List<SelectListItem>();

                StatusList.Add(new SelectListItem { Text = "Usada", Value = "Usada" });
                StatusList.Add(new SelectListItem { Text = "Nueva", Value = "Nueva" });
                StatusList.Add(new SelectListItem { Text = "Chatarra", Value = "Chatarra" });
                sStatus = new SelectList(StatusList, "Text", "Text");
            }


            var Diameter = PropertyList.Where(p => p.Name.ToUpper().Contains("metro".ToUpper())).FirstOrDefault();
            int Diam_idProperty = 3;
            if (Diameter != null)
            {
                Diam_idProperty = Diameter.idProperty;
                List<SelectListItem> DiametroList = new List<SelectListItem>();
                foreach (string d in db.GetDiameters(idType, Diam_idProperty))
                {
                    DiametroList.Add(new SelectListItem { Text = d, Value = d });
                }
                sDiameters = new SelectList(DiametroList, "Text", "Value");
            }
            else
            {
                List<SelectListItem> DiametroList = new List<SelectListItem>();
                sDiameters = new SelectList(DiametroList, "Text", "Value");
            }


            ViewBag.idProperty = sProperty;
            ViewBag.Suppliers = sSuppliers;
            ViewBag.StatusList = sStatus;
            ViewBag.DiametroList = sDiameters;
          
            ViewBag.idType = idType;

            ViewBag.numCols = numCols;
            int dWitdh = 0;
            if (PropertyList.Count > numCols)
            {
                dWitdh = 380 * numCols;
            }
            else
            {
                dWitdh = 380 * PropertyList.Count;
            }

            dWitdh+=50;
            
            decimal dHeight = 0;
            decimal pCount = PropertyList.Count;
            decimal nCol = numCols;
            decimal div = pCount / nCol;
            dHeight = (70 * ( Math.Ceiling(div))) + (numCols * 45);


            //return View("partialNewTool", PropertyList);
            return Json(new { PropertyCount = PropertyList.Count, DialogWidth = dWitdh, DialogHeight = dHeight, dContent = RenderRazorViewToString("partialNewTool",PropertyList) }, JsonRequestBehavior.AllowGet);
        }

       
        public ActionResult AddNew(FormCollection fc)
        {
            int idUser = 1;
            
            if (Session["idUser"] != null)
            {
                idUser = (int)Session["idUser"];
            }

            //validar todos los campos con valores.
            foreach (var key in fc.AllKeys)
            {
                
                    var svalue = fc[key];                  
                    if(svalue.Trim().Length == 0)
                    {
                        return Json(new { Success = 0, Message = "Falta introducir algunos valores requeridos.", element = key }, JsonRequestBehavior.AllowGet);
                    }
                
            }

            //Validar que la matricula no este registrada
            
            Tool_ToolDetail ToolDetail = db.GetToolDetail(new Tool_ToolDetail { Value = fc["17"]}).ToList().FirstOrDefault();
            if (ToolDetail != null)
            {
                List<Tool_Tool> sTool = db.GetTools(new Tool_Tool { idTool = ToolDetail.idTool });
                Tool_vm Toolvm = GetToolsProperties(sTool).FirstOrDefault();

                return UpdateStatus(Toolvm);               
            }

            Tool_Tool Tool = db.Create(new Tool_Tool { idUser = idUser, 
                                                        IdType = Convert.ToInt32(fc["IdType"]) 
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

        private List<Tool_vm> GetToolsProperties(List<Tool_Tool> Tools)
        {            
             List<int> idToolsList = Tools.Select(o => o.idTool).ToList().Distinct().ToList();
            List<Tool_vm> vTools = new List<Tool_vm>();
           
            
           
            foreach (int idTool in idToolsList)
            {
                int idCurrentTool = 0;
                List<Tool_Tool> ToolList = Tools.Where(t => t.idTool ==  idTool).ToList();
                Tool_vm vmTool = new Tool_vm();
                List<Property_vm> vPropertyList = new List<Property_vm>();

                foreach (Tool_Tool Tool in ToolList)
            {
                
                if (idCurrentTool == 0)
                {
                    idCurrentTool = Tool.idTool;
                    vmTool.idTool = Tool.idTool;
                    vmTool.idUser = Tool.idUser.ToString();
                    vmTool.Active = Tool.Active;
                    vmTool.IdType = Tool.IdType;
                    vmTool.InsDateTime = Tool.InsDateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                    vmTool.UpdDateTime = Tool.UpdDateTime.ToString("yyyy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture);
                }                
                   
             
               Property_vm Property = new Property_vm();
               Property.idProperty = Convert.ToInt32(Tool.idProperty);
               Property.IdType = Tool.IdType;
               Property.Value = Tool.Value ?? "";
               Property.Name = Tool.Name;
               Property.ViewUI = Tool.ViewUI;
               Property.TypeName = Tool.TypeName;
               vPropertyList.Add(Property);

               if (Property.Name.ToUpper().Contains("FECHA DE ALTA"))
               {
                   Property.Value = vmTool.InsDateTime;
               }
                idCurrentTool = Tool.idTool;
            }
            vmTool.Properties = vPropertyList;
            vTools.Add(vmTool);
            }

            return vTools;
        }

        public ActionResult Search(string Tag, string Status, string Stdkgtonslan, string Calibre, int idToolType)
        {
            List<Tool_Tool> Tools = db.GetTools(new Tool_Tool { IdType = idToolType });
            List<Tool_vm> ToolList = GetToolsProperties(Tools.Where(t => (BitConverter.GetBytes(t.ViewUI)[0] & (1 << 1 - 1)) != 0).OrderByDescending(t => t.InsDateTime).ToList());
            List<Tool_vm> vToolList = new List<Tool_vm>();
            vToolList = ToolList;
            if(!string.IsNullOrEmpty(Tag))
            {
                vToolList = vToolList.Where(t => t.Properties.Where(p => p.Name.Equals("Matricula") && p.Value.ToUpper().Contains(Tag.Trim().ToUpper())).ToList().Count > 0)
                                    .ToList();
            }
            if (!string.IsNullOrEmpty(Status))
            {
                vToolList = vToolList.Where(t => t.Properties.Where(p => p.Name.Equals("Estado") && p.Value.ToUpper().Contains(Status.Trim().ToUpper())).ToList().Count > 0)                                                            
                                    .ToList();                                   
            }
            if (!string.IsNullOrEmpty(Stdkgtonslan))
            {
                vToolList = vToolList.Where(t => t.Properties.Where(p => p.Name.Equals("Stdkgtonslan") && p.Value.ToUpper().Contains(Stdkgtonslan.Trim().ToUpper())).ToList().Count > 0)
                                    .ToList();                                    
            }
            if (!string.IsNullOrEmpty(Calibre))
            {
                vToolList = vToolList.Where(t => t.Properties.Where(p => p.Name.Equals("Calibre") && p.Value.ToUpper().Contains(Calibre.Trim().ToUpper())).ToList().Count > 0)
                                    .ToList();                                    
            }

            vToolList = vToolList.OrderByDescending(t => t.InsDateTime).ToList();
            ViewBag.idCatalog = 0;

            ViewBag.TypeName = db.GetToolTypes(new Tool_Type { idType = idToolType }).FirstOrDefault().Name;
            ViewBag.idType = idToolType;
          
            return View("Create", vToolList);
        }

        public string RenderRazorViewToString(string viewName, object model)
        {
            ViewData.Model = model;
            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(ControllerContext,
                                                                         viewName);
                var viewContext = new ViewContext(ControllerContext, viewResult.View,
                                             ViewData, TempData, sw);
                viewResult.View.Render(viewContext, sw);
                viewResult.ViewEngine.ReleaseView(ControllerContext, viewResult.View);
                return sw.GetStringBuilder().ToString();
            }
        }

        public ActionResult SetValue()
        {
            return PartialView("partialSetValue");
        }


        public ActionResult UpdateStatus(Tool_vm Toolvm)
        {
            var PropertyStatus = Toolvm.Properties.Where(p => p.Name.ToUpper().Contains("estado".ToUpper())).FirstOrDefault();
            var PropertyMatricula = Toolvm.Properties.Where(p => p.Name.ToUpper().Contains("matricula".ToUpper())).FirstOrDefault();
            
            SelectList sStatus = null;
            if (PropertyStatus != null)
            {
                List<SelectListItem> StatusList = new List<SelectListItem>();

                StatusList.Add(new SelectListItem { Text = "Usada", Value = "Usada" });
                StatusList.Add(new SelectListItem { Text = "Nueva", Value = "Nueva" });
                StatusList.Add(new SelectListItem { Text = "Chatarra", Value = "Chatarra" });
                sStatus = new SelectList(StatusList, "Text", "Text", PropertyStatus.Value);
            }
            ViewBag.Matricula = PropertyMatricula.Value;
            ViewBag.CurrentStatus = PropertyStatus.Value;
            ViewBag.ProStsId = PropertyStatus.idProperty;
            ViewBag.StatusList = sStatus;

            return Json(new { Success = 2, dContent = RenderRazorViewToString("partialTagExists", Toolvm) }, "application/json", JsonRequestBehavior.AllowGet);
        }

        public ActionResult UpdStatus(FormCollection fc)
        {
            if (fc["Status"].Length > 0)
            {
                Tool_ToolDetail td = db.Update(new Tool_ToolDetail
                {
                    idProperty = Convert.ToInt32(fc["idProperty"]),
                    idTool = Convert.ToInt32(fc["idTool"]),
                    Value = fc["Status"]
                });
            }
            else
            {
                return Json(new { Success = 0, Message = "Falta introducir valores requeridos", key = "Status" }, JsonRequestBehavior.AllowGet);
            }
            
            return Json(new { Success = 1 }, JsonRequestBehavior.AllowGet);
        }
    }
}