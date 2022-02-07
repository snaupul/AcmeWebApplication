using System.Web.Http;
using System.Web.Http.Cors;

namespace AcmeWebApplication
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "sign-up-new-user",
                routeTemplate: "api/Users/SignUpUser",
                defaults: new
                {
                    Controllers = "Users",
                    action = "SignUpUser"
                }
            );

            config.Routes.MapHttpRoute(
               name: "get-all-users",
               routeTemplate: "api/Users/GetAllUsersData",
               defaults: new
               {
                   Controllers = "Users",
                   action = "GetAllUsersData"
               }
           );

            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("text/html"));
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("application/json"));
            config.EnableCors(new EnableCorsAttribute("*", "*", "*"));
        }
    }
}