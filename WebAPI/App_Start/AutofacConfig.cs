using System.Linq;
using System.Reflection;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;
using WebAPI.Utils;

namespace WebAPI
{
    public class AutofacConfig
    {
        public static void InitContainer()
        {
            var builder = new ContainerBuilder();
            RegisterInjectables(builder);
            ConfigBuilder(builder);
        }
        
        private static void ConfigBuilder(ContainerBuilder builder)
        {
            var container = builder.Build();
            var config = GlobalConfiguration.Configuration;
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
        
        private static void RegisterInjectables(ContainerBuilder builder)
        {
            var projectAssembly = Assembly.GetExecutingAssembly(); 
            const string projectNamespace = "WebAPI"; 
            
            builder.RegisterApiControllers(projectAssembly);

            // Automatically register classes with Injectable attribute in Autofac
            builder.RegisterAssemblyTypes(projectAssembly)
                .InNamespace(projectNamespace)
                .Where(type => type.GetCustomAttributes<Injectable>().Any())                
                .AsImplementedInterfaces();
            
            // Manual way to register modules
            //builder.RegisterModule<ServicesModule>();
        }
    }
}