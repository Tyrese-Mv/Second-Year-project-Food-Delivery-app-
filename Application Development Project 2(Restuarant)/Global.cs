using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Application_Development_Project_2_Restuarant_
{
    public class Global
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }
    }
}