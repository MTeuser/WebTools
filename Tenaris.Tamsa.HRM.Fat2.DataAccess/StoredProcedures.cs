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

        public const string GetUsers = "[Security].[Users_Get]";
        public const string GetUsers = "[Security].[Users_Del]";
        public const string GetUsers = "[Security].[Users_Ins]";
        public const string GetUsers = "[Security].[Users_Udp]";



        public const string GetSuppliers = "[Tool].[Suppliers_Get]";
        public const string GetSuppliersByToolType = "[Tool].[Suppliers_GetByToolType]";
        public const string GetDiameters = "[Tool].[Properties_GetDiameters]";
        public const string GetToolProperties = "[Tool].[Properties_Get]";
        public const string GetToolTypes = "[Tool].[Types_Get]";

    }
}
