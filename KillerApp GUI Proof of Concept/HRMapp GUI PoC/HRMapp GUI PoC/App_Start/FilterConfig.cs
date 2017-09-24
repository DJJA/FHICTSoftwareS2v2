using System.Web;
using System.Web.Mvc;

namespace HRMapp_GUI_PoC
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
