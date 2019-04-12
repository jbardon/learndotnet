using Functional.Maybe;

namespace SmartAdLibrary.BusinessChecks.Product
{
    public class ProductBusinessCheckContext
    {
        public Maybe<Models.Product> OldProduct { get; set; } = Maybe<Models.Product>.Nothing;
        
        public Models.Product NewProduct { get; set; }
    }
}