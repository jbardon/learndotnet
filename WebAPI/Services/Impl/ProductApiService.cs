using System.Collections.Generic;
using System.Linq;
using Mapster;
using SmartAdLibrary.Models;
using WebAPI.Models.CriteriaDto;
using WebAPI.Models.Dto;
using WebAPI.Utils;
using SmartAdServices = SmartAdLibrary.Services;

namespace WebAPI.Services.Impl
{
    [Injectable]
    public class ProductApiService : IProductApiService
    {
        private readonly SmartAdServices.IProductService _smartAdService;

        public ProductApiService(SmartAdServices.IProductService smartAdService)
        {
            _smartAdService = smartAdService;
        }

        public ProductDto FindOne(int id)
        {
            var products = _smartAdService.Load();
            var product = products.First(p => p.UniqueId == id);
            
            return product.Adapt<ProductDto>();
        }

        public IList<ProductDto> FindAll()
        {
            var products = _smartAdService.Load();
            return products.Adapt<IList<ProductDto>>();
        }

        public IList<ProductDto> Search(ProductSearchCriteria criteria)
        {
            var products = _smartAdService.Load();
            IEnumerable<Product> filteredProducts = products;
            
            if (criteria.Make != null)
            {
                filteredProducts = filteredProducts
                    .Where(p => criteria.Make.Any(make => p.Manufacturer.ToUpper().Contains(make.ToUpper())));
            }

            if (criteria.Name != null)
            {
                filteredProducts = filteredProducts
                    .Where(p => criteria.Name.Any(name => p.FullName.ToUpper().Contains(name.ToUpper())));
            }
            
            if (criteria.MinPrice != null)
            {
                filteredProducts = filteredProducts
                    .Where(p => p.Price >= criteria.MinPrice);
            }
            
            if (criteria.MaxPrice != null)
            {
                filteredProducts = filteredProducts
                    .Where(p => p.Price <= criteria.MaxPrice);
            }

            return filteredProducts.ToList().Adapt<IList<ProductDto>>();
        }

        public int Create(ProductDto product)
        {
            return _smartAdService.Create(product.Adapt<Product>());
        }

        public void Delete(int id)
        {
            _smartAdService.Delete(id);
        }

        public void Update(ProductDto product)
        {
            _smartAdService.Update(product.Adapt<Product>());
        }
    }
}