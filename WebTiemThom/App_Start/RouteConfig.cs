using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebTiemThom
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "Product Category",
                url: "product/{metatitle}-{id}",
                defaults: new { controller = "Product", action = "Category", id = UrlParameter.Optional },
                namespaces: new[] { "WebTiemThom.Controllers" }
            );

            routes.MapRoute(
                name: "Add Cart",
                url: "add-cart",
                defaults: new { controller = "Cart", action = "AddItem", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
                name: "Checkout",
                url: "checkout",
                defaults: new { controller = "Cart", action = "Checkout", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
                name: "Payment Success",
                url: "successed",
                defaults: new { controller = "Cart", action = "Success", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
                name: "Payment Failed",
                url: "error",
                defaults: new { controller = "Cart", action = "Error", id = UrlParameter.Optional },
                namespaces: new[] { "OnlineShop.Controllers" }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces: new[] { "WebTiemThom.Controllers" }
            );
        }
    }
}
