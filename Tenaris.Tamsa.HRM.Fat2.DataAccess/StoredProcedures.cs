using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess
{
    internal class StoredProcedures
    {

        public const string Tool_Get = "[Tool].[Tool_Get]";
        public const string Tool_Del = "[Tool].[Tool_Del]";
        public const string Tool_Ins = "[Tool].[Tool_Ins]";
        public const string Tool_Udp = "[Tool].[Tool_Udp]";

        public const string Users_Get = "[Security].[Users_Get]";
        //public const string Users_Del = "[Security].[Users_Del]";
        //public const string Users_Ins = "[Security].[Users_Ins]";
        //public const string Users_Udp = "[Security].[Users_Udp]";

        public const string Suppliers_Get = "[Tool].[Suppliers_Get]";
        public const string Suppliers_Del = "[Tool].[Suppliers_Del]";
        public const string Suppliers_Ins = "[Tool].[Suppliers_Ins]";
        public const string Suppliers_Udp = "[Tool].[Suppliers_Udp]";
        public const string Suppliers_GetByToolType = "[Tool].[Suppliers_GetByToolType]";

        public const string Property_Get = "[Tool].[Property_Get]";
        //public const string Property_Del = "[Tool].[Property_Del]";
        public const string Property_Ins = "[Tool].[Property_Ins]";
        public const string Property_Udp = "[Tool].[Property_Udp]";
        public const string Property_GetByType = "[Tool].[Property_GetByType]";
        public const string Property_GetDistinctValuesByType = "[Tool].[Property_GetDistinctValuesByType]";
       
        //public const string Property_GetByTypeId = "[Tool].[Property_GetByTypeId]";
         

        public const string Types_Get = "[Tool].[Types_Get]";
        public const string Types_Del = "[Tool].[Types_Del]";
        public const string Types_Ins = "[Tool].[Types_Ins]";
        public const string Types_Udp = "[Tool].[Types_Udp]";

        public const string ToolDetail_Get = "[Tool].[ToolDetail_Get]";
        public const string ToolDetail_Del = "[Tool].[ToolDetail_Del]";
        public const string ToolDetail_Ins = "[Tool].[ToolDetail_Ins]";
        public const string ToolDetail_Udp = "[Tool].[ToolDetail_Udp]";

        public const string Catalog_Ins = "[Tool].[Catalog_Ins]";
        public const string Catalog_Get = "[Tool].[Catalog_Get]";
        public const string Catalog_Upd = "[Tool].[Catalog_Upd]";
        public const string Catalog_Del = "[Tool].[Catalog_Del]";
        
    }
}
