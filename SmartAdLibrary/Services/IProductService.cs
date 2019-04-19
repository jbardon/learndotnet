using System.Collections.Generic;
using SmartAdLibrary.Models;

namespace SmartAdLibrary.Services
{
    public interface IProductService
    {
        int Create(Product product);
        
        IList<Product> Load();

        void Update(Product product);
        
        void Delete(int id);
    }
}