using System.Collections.Generic;
using Mapster;
using WebAPI.Models;
using WebAPI.Models.CriteriaDto;
using WebAPI.Models.Dto;
using WebAPI.Utils;

namespace WebAPI.Services
{
    [Injectable]
    public class ProductService : IProductService
    {
        public ProductDto FindOne(int id)
        {
            return SmartAdLibrary.Get().Adapt<ProductDto>();
        }

        public IList<ProductDto> FindAll()
        {
            return new List<ProductDto>
            {
                FindOne(0)
            };
        }

        public IList<ProductDto> Search(ProductSearchCriteria criteria)
        {
            return FindAll();
        }
    }
}