using Shortnr.Web.Filters.ShortnrApiErrorFilters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Shortnr.Web
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            config.Filters.Add(new ShortnrApiErrorFilter());

            // Web API routes
            config.MapHttpAttributeRoutes();

           /* config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}",
                defaults: new { id = RouteParameter.Optional }
            );*/
        }
    }
}
