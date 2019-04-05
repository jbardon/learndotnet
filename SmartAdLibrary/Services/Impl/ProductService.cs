using System.Collections.Generic;
using SmartAdLibrary.Model;

namespace SmartAdLibrary.Services.Impl
{
    public class ProductService : IProductService
    {
        public IList<Product> GetAll()
        {
            return new List<Product>
            {
                new Product()
                {
                    UniqueId = 1,
                    Manufacturer = "Mir",
                    FullName = "Lessive liquide Mir Raviveur de Blancheur",
                    Price = 4.93,
                    Quantity = new Quantity()
                    {
                        Unity = MeasurementUnit.Liter,
                        Value = 1.5
                    }
                },
                new Product()
                {
                    UniqueId = 2,
                    Manufacturer = "Aquafresh",
                    FullName = "Dentifrice Aquafresh Night repair",
                    Price = 1.97,
                    Quantity = new Quantity()
                    {
                        Unity = MeasurementUnit.Liter,
                        Value = 0.150
                    }
                },
                new Product()
                {
                    UniqueId = 2,
                    Manufacturer = "Plantation",
                    FullName = "Café en capsule Plantation Cappuccino - x8",
                    Price = 2.84,
                    Quantity = new Quantity()
                    {
                        Unity = MeasurementUnit.Gram,
                        Value = 166.4
                    }
                },
                new Product()
                {
                    UniqueId = 2,
                    Manufacturer = "Nos régions ont du talent",
                    FullName = "Fromage Brillat Savarin 38%mg Nos Régions ont du Talent",
                    Price = 2.70,
                    Quantity = new Quantity()
                    {
                        Unity = MeasurementUnit.Gram,
                        Value = 200
                    }
                },
                new Product()
                {
                    UniqueId = 2,
                    Manufacturer = "Nestea",
                    FullName = "Thé glacé Nestea Thé vert,citron, vert,menthe",
                    Price = 1.50,
                    Quantity = new Quantity()
                    {
                        Unity = MeasurementUnit.Liter,
                        Value = 1
                    }
                }
            };
        }
    }
}