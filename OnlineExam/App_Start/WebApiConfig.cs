using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace OnlineExam
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Web API configuration and services
            GlobalConfiguration.Configuration.Formatters.JsonFormatter.SerializerSettings.ReferenceLoopHandling=
                Newtonsoft.Json.ReferenceLoopHandling.Serialize;
            // Web API routes
            config.MapHttpAttributeRoutes();
            config.EnableCors(new EnableCorsAttribute("*", headers: "*", methods: "*"));

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}
