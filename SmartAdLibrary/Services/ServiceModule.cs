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
            
            // Bug here =>
            /*
             * Échec de la tentative d'accès de la méthode transparente de sécurité
             * 'Autofac.Extras.Attributed.AutofacAttributeExtensions.WithAttributeFilter(Autofac.Builder.IRegistrationBuilder`3<!!0,!!1,!!2>)'
             * au type critique de sécurité 'Autofac.Builder.IRegistrationBuilder`3<TLimit,TReflectionActivatorData,TRegistrationStyle>'.
             *
             * L'assembly 'Autofac.Extras.Attributed, Version=3.3.0.0, Culture=neutral, PublicKeyToken=17863af14b0044da' est marqué
             * avec AllowPartiallyTrustedCallersAttribute, et utilise le modèle de transparence de sécurité de niveau 2.
             * Si la transparence de niveau 2 est utilisée, toutes les méthodes des assemblys AllowPartiallyTrustedCallers deviennent transparentes de sécurité par défaut,
             * ce qui peut la cause de cette exception.
             */
            //builder.RegisterType<ProductService>().WithAttributeFilter() // For BusinessCheck inject
            //   .As<IProductService>().SingleInstance();            
            
            
            // https://autofaccn.readthedocs.io/en/latest/advanced/keyed-services.html#named-services
            builder.RegisterType<ProductService>() 
                .As<IProductService>().WithAttributeFiltering() // For BusinessCheck inject
                .SingleInstance();  
        }
    }
}