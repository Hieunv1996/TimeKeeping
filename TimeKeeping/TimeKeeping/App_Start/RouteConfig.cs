using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace TimeKeeping
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            // BotDetect requests must not be routed
            routes.IgnoreRoute("{*botdetect}",
                new { botdetect = @"(.*)BotDetectCaptcha\.ashx" });

            //Site
            routes.MapRoute(
                name: "DangNhap",
                url: "dang-nhap",
                defaults: new { controller = "DangNhap", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TimeKeeping.Controllers" }
            );

            //Admin Site
            routes.MapRoute(
                name: "Admin",
                url: "admin",
                defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TimeKeeping.Areas.Admin.Controllers" }
            );

            //Default config 
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "TrangChu", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "TimeKeeping.Controllers" }
            );
        }
    }
}
