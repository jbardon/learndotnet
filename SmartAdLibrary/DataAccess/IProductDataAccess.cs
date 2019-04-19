using System.Collections.Generic;
using SmartAdLibrary.Models;

namespace SmartAdLibrary.DataAccess
{
    public interface IProductDataAccess
    {
        IList<Product> Load();

        void Update(Product product);

        int Create(Product product);

        void Delete(int id);
    }
}