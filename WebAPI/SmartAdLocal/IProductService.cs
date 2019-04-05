using System.Collections.Generic;

namespace WebAPI.SmartAdLocal
{
    public interface IProductService
    {
        IList<Product> GetAll();
    }
}