using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Http;

namespace WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services

            // Web API routes
            
            // Attribute routing (method 1)
            // https://docs.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/attribute-routing-in-web-api-2
            
            config.MapHttpAttributeRoutes();

            // Convention based routing (method 2)
            // https://docs.microsoft.com/en-us/aspnet/web-api/overview/web-api-routing-and-actions/routing-in-aspnet-web-api
            config.Routes.MapHttpRoute( // Different from MapRoute for MVC
                "ByController",
                "api/{controller}/{id}", // Id to not clash with "api/{controller}/{action}" 
                new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute( // Different from MapRoute for MVC
                "ByControllerAndName",
                "api/{controller}/{action}"
            );

            /* Hacks for JSON only serialization
                - Only keep JSON formatter to force serialize response in JSON
                    config.Formatters.Clear();
                    config.Formatters.Add(new JsonMediaTypeFormatter());

                - Response with JSON when the Accept header is html (from browser)
                    config.Formatters.JsonFormatter.SupportedMediaTypes
                    .Add(new MediaTypeHeaderValue("text/html"));
            */

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
