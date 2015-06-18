using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace MockFileDownloadTool
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "GenerateFile",
                url: "CreateFile/{filename}/{fileContent}/{*contentType}",
                defaults: new { controller = "Home", action = "GenerateFile",
                    filename = UrlParameter.Optional,
                    fileContent = UrlParameter.Optional,
                    contentType = UrlParameter.Optional }
                );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
