using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Entaria
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

     //     routes.MapRoute("findffid", "findrfid/{Number}", new { Controller = "FindRfid", action = "GetRfidNo", Number = "" });
           
       //    routes.MapRoute("findffid", "findrfid/{Number}", new { Controller = "cwsController", action = "GetRfidNo", Number = "" });
    //       routes.MapRoute("ApigetCCB2", "getCCB/{client}/{card}", new { Controller = "cws", action = "getCCB", client = "", card = "" });
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}