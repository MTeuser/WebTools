using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tenaris.Tamsa.HRM.Fat2.DataAccess
{
    internal class StoredProcedures
    {
        public const string GetUsers = "[Security].[GetUsers]";
        public const string GetTools = "[Tool].[GetTools]";

        public static string GetSuppliers { get; set; }
    }
}
