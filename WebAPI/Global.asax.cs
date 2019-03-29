﻿using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace WebAPI
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            //AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            
            AutofacConfig.InitContainer();
            MapsterConfig.InitMappings();
        }
    }
}
