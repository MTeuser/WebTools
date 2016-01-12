using System.Web;
using System.Web.Mvc;

namespace Tenaris.Tamsa.HRM.Fat2.WebTools
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}