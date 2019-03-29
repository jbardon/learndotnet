using System.Collections.Generic;
using WebAPI.Models.CriteriaDto;
using WebAPI.Models.Dto;

namespace WebAPI.Services
{
    public interface IProductService
    {
        ProductDto FindOne(int id);
        
        IList<ProductDto> FindAll();
        
        IList<ProductDto> Search(ProductSearchCriteria criteria);
    }
}