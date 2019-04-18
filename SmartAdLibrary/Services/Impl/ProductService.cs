using System.Collections.Generic;
using Autofac.Features.AttributeFilters;
using SmartAdLibrary.BusinessChecks.Product;
using SmartAdLibrary.DataAccess;
using SmartAdLibrary.Models;
using SmartAdLibrary.Utils;

namespace SmartAdLibrary.Services.Impl
{
    public class ProductService : IProductService
    {
        private readonly IBusinessCheck<ProductBusinessCheckContext> _businessChecks;
        private readonly IProductDataAccess _dataAccess;

        public ProductService(
            // Old way: WithKey attribute
            [KeyFilter("ProductBusinessChecks")] IBusinessCheck<ProductBusinessCheckContext> businessChecks,
            IProductDataAccess dataAccess)
        {
            _businessChecks = businessChecks;
            _dataAccess = dataAccess;
        }

        public int Create(Product product)
        {
            throw new System.NotImplementedException();
        }

        public IList<Product> Load()
        {
            return _dataAccess.Load();
        }

        public void Update(Product product)
        {
            var context = new ProductBusinessCheckContext()
            {
                NewProduct = product
            };
            _businessChecks.Execute(context);
        }

        public void Delete(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}