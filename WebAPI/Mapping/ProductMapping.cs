using Mapster;
using SmartAdLibrary.Models;
using WebAPI.Models.Dto;
using WebAPI.Utils;

namespace WebAPI.Mapping
{
    public class ProductMapping : IMapper
    {
        public void RegisterMapping()
        {
            TypeAdapterConfig<ProductDto, Product>
                .NewConfig()
                .Map("UniqueId", "Id")
                .Map("FullName", "Name");

            /*
            TypeAdapterConfig<ProductDto, Product>
                .NewConfig()
                .MapWith(dto => ConvertTo(dto));
            */
            
            TypeAdapterConfig<Product, ProductDto>
                .NewConfig()
                .Map(d => d.Id, s => s.UniqueId)
                .Map(d => d.Name, s => s.FullName);
        }

        /*
        private static Product ConvertTo(ProductDto dto)
        {
            var domain = new Product();
                    
            dto.Id = domain.UniqueId;
            dto.Name = domain.FullName;
            dto.Price = domain.Price;
                    
            return domain;
        }
        */
    }
}