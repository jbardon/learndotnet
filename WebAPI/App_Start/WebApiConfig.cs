using System.Web.Http;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute( // Different from MapRoute for MVC
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            /**
                config.Routes.MapHttpRoute(
                    name: "DefaultApi",
                    routeTemplate: "api/{controller}/{id}",
                    defaults: new { id = RouteParameter.Optional }
                );
                
                config.MapHttpAttributeRoutes();
                
                config.Routes.MapHttpRoute(
                    name: "SimpleGetRoute",
                    routeTemplate: "{controller}",
                    defaults: new { action = "Get" },
                    constraints: new { httpMethod = new HttpMethodConstraint("GET") }
                );
    
                config.Routes.MapHttpRoute(
                    name: "IntIdGetRoute",
                    routeTemplate: "{controller}/{id}",
                    defaults: new { action = "Get" },
                    constraints: new { httpMethod = new HttpMethodConstraint("GET"), id = @"[0-9]+" }
                );
             */
        }
    }
}
