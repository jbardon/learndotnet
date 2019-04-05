using Autofac;
using SmartAdLibrary.Services.Impl;
using Module = Autofac.Module;

namespace SmartAdLibrary.Services
{
    // Export services for other projects including this project with ProjectReference
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
        }
    }
}