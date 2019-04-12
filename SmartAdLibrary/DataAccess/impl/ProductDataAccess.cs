using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using SmartAdLibrary.Model;
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
                //var query = FileLoader.LoadFile("SmartAdLibrary.Sql.Product_Load.sql");
                return _dbManager.ExecuteReader<List<Product>>(
                    "[dal].[Product_Load]",
                    parameters,
                    (reader, result) =>
                    {
                        var populer = new ProductPopuler(); 
                        return populer.Populate(reader);
                    });
            }
            catch (SqlException ex)
            {
               // throw DealsDataAccessHelper.EnhanceSqlException(ex, user);
            }
            
            return new List<Product>();
        }
    }
}