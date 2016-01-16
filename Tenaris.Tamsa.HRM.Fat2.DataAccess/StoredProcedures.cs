using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess
{
    internal class StoredProcedures
    {
        
        public const string GetTools = "[Tool].[Tool_Get]";
        public const string GetTools = "[Tool].[Tool_Del]";
        public const string GetTools = "[Tool].[Tool_Ins]";
        public const string GetTools = "[Tool].[Tool_Udp]";

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
        public const string Property_Del = "[Tool].[Property_Del]";
        public const string Property_Ins = "[Tool].[Property_Ins]";
        public const string Property_Udp = "[Tool].[Property_Udp]";
        public const string Property_GetDiameters = "[Tool].[Properties_GetDiameters]";

        public const string Types_Get = "[Tool].[Types_Get]";
        public const string Types_Del = "[Tool].[Types_Del]";
        public const string Types_Ins = "[Tool].[Types_Ins]";
        public const string Types_Udp = "[Tool].[Types_Udp]";

        public const string Types_Udp = "[Tool].[ToolDetail_Get]";
        public const string Types_Udp = "[Tool].[ToolDetail_Del]";
        public const string Types_Udp = "[Tool].[ToolDetail_Ins]";
        public const string Types_Udp = "[Tool].[ToolDetail_Udp]";


    }
}
