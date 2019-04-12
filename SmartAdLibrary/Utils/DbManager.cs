using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace SmartAdLibrary.Utils
{
    public class DbManager : IDbManager
    {
        private readonly SqlConnection _connection;
        private const string DbName = "Learndotnet";
        
        public DbManager()
        {
            _connection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings[DbName].ConnectionString
            };
        }
        
        public T ExecuteReader<T>(
            string query,
            IList<SqlParameter> parameters,
            Func<DbDataReader, T, T> callback) where T : new()
        {
            if (_connection.State == ConnectionState.Closed)
            {
                _connection.Open();
            }
            
            var dbCommand = new SqlCommand()
            {
                Connection = _connection,
                CommandText = query,
                //CommandType = CommandType.StoredProcedure,
            };
            
            foreach (var sqlParameter in parameters)
            {
                dbCommand.Parameters.Add(sqlParameter);
            }

            return callback(dbCommand.ExecuteReader(), new T());
        }
    }
}