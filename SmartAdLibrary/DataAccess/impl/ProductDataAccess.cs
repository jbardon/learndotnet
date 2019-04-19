using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using SmartAdLibrary.Models;
using SmartAdLibrary.Utils;

namespace SmartAdLibrary.DataAccess.impl
{
    public class ProductDataAccess : IProductDataAccess
    {
        private readonly IDbManager _dbManager;

        public ProductDataAccess(IDbManager dbManager)
        {
            _dbManager = dbManager;
        }

        public IList<Product> Load()
        {
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Id", 2)
            };
            
            try
            {
                var query = FileLoader.LoadFile("SmartAdLibrary.Sql.Product_Load.sql");                
                //var query = "[dal].[Product_Load]";
                return _dbManager.ExecuteReader<List<Product>>(
                    query,
                    parameters,
                    (reader, result) =>
                    {
                        var populer = new ProductPopuler();
                        return populer.Populate(reader);
                    });
            }
            catch (SqlException ex)
            {
                throw ex;
                // throw DealsDataAccessHelper.EnhanceSqlException(ex, user);
            }
        }

        public int Create(Product product)
        {
            var parameters = new List<SqlParameter>()
            {
                new SqlParameter("@Name", product.FullName),
                new SqlParameter("@Manufacturer", product.Manufacturer),
                new SqlParameter("@Price", product.Price),
                new SqlParameter("@QuantityValue", (object) product.Quantity?.Value ?? DBNull.Value),
                new SqlParameter("@QuantityUnit", (object) product.Quantity?.Unity.ToString() ?? DBNull.Value)
            };

            try
            {
                var query = FileLoader.LoadFile("SmartAdLibrary.Sql.Product_Create.sql");                
                //var query = "[dal].[Product_Load]";
                return _dbManager.ExecuteScalar<int>(
                    query,
                    parameters);
            }
            catch (SqlException ex)
            {
                throw ex;
            }
        }
        
        public void Update(Product product)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }
    }
}