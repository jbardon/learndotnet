using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using SmartAdLibrary.Model;
using SmartAdLibrary.Models;

namespace SmartAdLibrary.DataAccess
{
    public class ProductPopuler
    {
        public List<Product> Populate(DbDataReader reader)
        {
            var result = new List<Product>();
            
            while (reader.Read())
            {
                result.Add(PopulateOne(reader));
            }

            return result;
        }

        private Product PopulateOne(IDataRecord reader)
        {
            return new Product
            {
                UniqueId = (int) reader[0],
                FullName = (string) reader[1],
                Manufacturer = (string) reader[2],
                Price = (double) reader[3]                
            };
        }
    }
}