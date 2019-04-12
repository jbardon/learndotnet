using Autofac;
using SmartAdLibrary.BusinessChecks.Product;

namespace SmartAdLibrary.BusinessChecks
{
    public class BusinessChecksModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            
            builder.RegisterModule<ProductBusinessChecksModule>();
        }       
    }
}