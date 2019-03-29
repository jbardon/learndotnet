using Autofac;

namespace WebAPI.Services
{
    /*
    // Manual way to register types in modules
    // See AutofacConfig which scans service classes
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            builder.RegisterType<ProductService>().As<IProductService>().SingleInstance();
        }
    }
    */
}