using System.Web;
using System.Web.Mvc;

namespace Application_Development_Project_2_Restuarant_
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
