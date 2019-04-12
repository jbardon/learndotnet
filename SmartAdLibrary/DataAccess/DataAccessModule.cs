using Autofac;
using SmartAdLibrary.DataAccess.impl;
using SmartAdLibrary.Utils;

namespace SmartAdLibrary.DataAccess
{
    public class DataAccessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            
            builder.RegisterModule<UtilsModule>();
            
            builder.RegisterType<ProductDataAccess>().As<IProductDataAccess>().SingleInstance();
        }       
    }
}