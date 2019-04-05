using System.Web;
using System.Web.Http;

namespace WebAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            
            AutofacConfig.InitContainer();
            MapsterConfig.InitMappings();
        }
    }
}
