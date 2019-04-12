using SmartAdLibrary.Utils;

namespace SmartAdLibrary.BusinessChecks.Product.Items
{
    public class ProductMandatoryFieldsBusinessCheck : IBusinessCheck<ProductBusinessCheckContext>
    {
        public void Execute(ProductBusinessCheckContext context)
        {
            if (context.NewProduct.FullName == "")
            {
                throw new BusinessException("Product.FullName is a mandatory field");
            }
        }
    }
}