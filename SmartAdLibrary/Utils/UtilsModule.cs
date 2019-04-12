using Autofac;

namespace SmartAdLibrary.Utils
{
    public class UtilsModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);
            
            builder.RegisterType<DbManager>().As<IDbManager>().SingleInstance();
        }       
    }
}