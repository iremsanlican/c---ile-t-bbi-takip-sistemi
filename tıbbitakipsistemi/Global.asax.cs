using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TIBBITAKIPSISTEMI;
using tıbbitakipsistemi;

namespace tıbbitakipsistemi
{
    public class MvcApplication : System.Web.HttpApplication
    {
     
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            // Other initialization code here
        }
    }
}
