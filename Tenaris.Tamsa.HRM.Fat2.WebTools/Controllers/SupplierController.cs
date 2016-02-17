using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tenaris.Tamsa.HRM.Fat2.DataAccess.Models;
using Tenaris.Tamsa.HRM.Fat2.DataAccess;

namespace Tenaris.Tamsa.HRM.Fat2.WebTools.Controllers
{
    public class SupplierController : Controller
    {
        private DataAccess.DataAccess db = new DataAccess.DataAccess();
        //
        // GET: /Supplier/

        public ActionResult Index()
        {
            List<Tool_Supplier> Suppliers = db.GetSuppliers();
            return View(Suppliers);
        }

        //
        // GET: /Supplier/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /Supplier/Create

        public ActionResult New(int idProperty)
        {
            Tool_Supplier Supplier = new Tool_Supplier();
            ViewBag.idProperty = idProperty;
            return View("partialNew", Supplier);
        }

        //
        // POST: /Supplier/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                foreach (var key in collection.AllKeys)
                {
                    var svalue = collection[key];
                    if (svalue.Trim().Length == 0)
                    {                        
                        return Json(new { Success = 0, Message = "Debe introducir todos los valores.", element = key }, JsonRequestBehavior.AllowGet);
                    }
                }
                Tool_Supplier Supplier = db.Create(new Tool_Supplier { Code = collection["Code"], Name = collection["Name"] });
                return Json(new { Success = true, Supplier = Supplier },JsonRequestBehavior.AllowGet);
            }
            catch(Exception e)
            {
                return Json(new { Success = false, Message = "Error. No se creado el proveedor" }, JsonRequestBehavior.AllowGet);
            }
        }

        //
        // GET: /Supplier/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Supplier/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Supplier/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /Supplier/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }


    }
}
