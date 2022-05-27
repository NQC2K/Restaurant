﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Restaurant
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "DetailsFood",
                url: "details/{id}",
                new { controller = "Home", action = "FoodDetails", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "FoodCategory",
                url: "category/{cateid}",
                new { controller = "Home", action = "FoodCate", cateid = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Cart",
                url: "cart",
                new { controller = "Cart", action = "Index", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Payment",
                url: "payment",
                new { controller = "Cart", action = "Payment", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
