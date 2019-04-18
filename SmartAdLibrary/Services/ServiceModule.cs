using Autofac;
using Autofac.Features.AttributeFilters;
using SmartAdLibrary.BusinessChecks;
using SmartAdLibrary.DataAccess;
using SmartAdLibrary.Services.Impl;

namespace SmartAdLibrary.Services
{
    // Export services for other projects including this project with ProjectReference
    public class ServiceModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            
            builder.RegisterModule<BusinessChecksModule>();
            builder.RegisterModule<DataAccessModule>();
            
            // Old way: .WithAttributeFilter()
            // Enable injection for constructors with parameters having attributes (ew: BusinessCheck with KeyFilter)
            builder.RegisterType<ProductService>() 
                .As<IProductService>().WithAttributeFiltering()
                .SingleInstance();  
        }
    }
}