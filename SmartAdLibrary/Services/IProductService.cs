using System.Collections.Generic;
using SmartAdLibrary.Model;

namespace SmartAdLibrary.Services
{
    public interface IProductService
    {
        IList<Product> GetAll();
    }
}