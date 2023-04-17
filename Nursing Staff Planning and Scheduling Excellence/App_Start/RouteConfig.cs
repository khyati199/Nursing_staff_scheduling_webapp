using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace NursingStaffPlanningandSchedulingExcellence
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "StaffDetails",
                url: "Admin/StaffDetails/{id}",
                defaults: new { controller = "Admin", action = "StaffDetails", id = UrlParameter.Optional, year = UrlParameter.Optional, month = UrlParameter.Optional, day = UrlParameter.Optional },
                new[] { "NursingStaffPlanningandSchedulingExcellence.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Login", action = "Login", id = UrlParameter.Optional },
                new[] { "NursingStaffPlanningandSchedulingExcellence.Controllers" }
            );

            routes.MapRoute(           
                name: "NotFound",             
                url: "{*url}",             
                defaults: new { controller = "Home", action = "Error" }
         );
        }
    }
}
