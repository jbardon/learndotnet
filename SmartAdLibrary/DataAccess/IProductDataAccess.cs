using System.Collections.Generic;
using SmartAdLibrary.Model;
using SmartAdLibrary.Models;

namespace SmartAdLibrary.DataAccess
{
    public interface IProductDataAccess
    {
        IList<Product> Load();
    }
}