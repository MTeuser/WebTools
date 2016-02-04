using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tenaris.Tamsa.HRM.Fat2.DataAccess;
using Tenaris.Tamsa.HRM.Fat2.DataAccess.Models;
using Tenaris.Tamsa.HRM.Fat2.WebTools.Models;

namespace Tenaris.Tamsa.HRM.Fat2.WebTools.Controllers
{
    public class CatalogController : Controller
    {
        //
        // GET: /Catalog/
        private DataAccess.DataAccess db = new DataAccess.DataAccess();

        public ActionResult Index()
        {
            List<Catalog_vm> ListCatalog = new List<Catalog_vm>();
            var Catalog = db.GetToolCatalog();
            var Types = db.GetToolTypes();
            try
            {
                ListCatalog = (from item in Catalog
                               join eType in Types on item.IdType equals eType.idType
                               select new Catalog_vm
                               {
                                   IdCatalog = item.IdCatalog,
                                   Active = item.Active,
                                   Code = eType.Code,
                                   IdType = eType.idType,
                                   Description = eType.Description,
                                   InsDateTime = item.InsDateTime,
                                   Name = eType.Name,
                                   UpdDateTime = item.UpdDateTime
                               }).ToList();
            }
            catch (Exception e)
            {
                //ignore.
            }


            return View(ListCatalog);            
        }

        public ActionResult Details(int IdCatalog)
        {
            var Catalog = db.GetToolCatalog(new Tool_Catalog { IdCatalog = IdCatalog }).FirstOrDefault();
            var ListProperties = db.GetToolProperties(new Tool_Property { IdCatalog = IdCatalog });
            var Type = db.GetToolTypes(new Tool_Type { idType = Catalog.IdType });

            ViewBag.Properties = ListProperties;
            ViewBag.Type = Type;
            return View();
        }

        public ActionResult Search(int Type = 0, string Code="", string Name="", string Description="")
        {
            List<Catalog_vm> ListCatalog = new List<Catalog_vm>();
            var Catalog = db.GetToolCatalog();
            var Types = db.GetToolTypes();
            try
            {
                ListCatalog = (from item in Catalog
                               join eType in Types on item.IdType equals eType.idType                               
                               select new Catalog_vm
                               {
                                   IdCatalog = item.IdCatalog,
                                   Active = item.Active,
                                   Code = eType.Code,
                                   IdType = eType.idType,
                                   Description = eType.Description,
                                   InsDateTime = item.InsDateTime,
                                   Name = eType.Name,
                                   UpdDateTime = item.UpdDateTime
                               }).ToList();              
                if (Type > 0)
                {
                    ListCatalog = ListCatalog.Where(l => l.IdType == Type).ToList();
                }
                if (Code.Length > 0)
                {
                    ListCatalog = ListCatalog.Where(l => l.Code.ToUpper().Equals(Code.ToUpper())).ToList();
                }
                if (Name.Length > 0)
                {
                    ListCatalog = ListCatalog.Where(l => l.Name.ToUpper().Equals(Name.ToUpper())).ToList();
                }
                if (Description.Length > 0)
                {
                    ListCatalog = ListCatalog.Where(l => l.Description.ToUpper().Contains(Description.ToUpper())).ToList();
                }
            }
            catch (Exception e)
            {
                //ignore.
            }
            return View("Index",ListCatalog);  
        }

        public ActionResult New()
        {
            ViewBag.Types = new SelectList(db.GetToolTypes(), "idType", "Name");
            ViewBag.Properties = new SelectList(db.GetToolProperties(), "idProperty", "Name");
            return View();
        }

    }
}
