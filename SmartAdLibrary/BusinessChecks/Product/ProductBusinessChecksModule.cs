using Autofac;
using SmartAdLibrary.BusinessChecks.Product.Items;
using SmartAdLibrary.Utils;

namespace SmartAdLibrary.BusinessChecks.Product
{
    public class ProductBusinessChecksModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            base.Load(builder);

            RegisterBusinessChecks(builder);

            builder
                .Register(BuildBusinessChecksOrchestrator)
                // Old way: Named
                .Keyed<IBusinessCheck<ProductBusinessCheckContext>>("ProductBusinessChecks").SingleInstance();
        }

        private static void RegisterBusinessChecks(ContainerBuilder builder)
        {
            builder.RegisterType<ProductMandatoryFieldsBusinessCheck>().AsSelf().SingleInstance();
        }

        private static IBusinessCheck<ProductBusinessCheckContext> BuildBusinessChecksOrchestrator(
            IComponentContext componentContext)
        {
            var mandatoryFieldsBusinessCheck = componentContext.Resolve<ProductMandatoryFieldsBusinessCheck>();

            return new BusinessCheckOrchestrator<ProductBusinessCheckContext>(
                mandatoryFieldsBusinessCheck
            );
        }
    }
}