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
        private const string DbName = "Learndotnet";
        
        public T ExecuteReader<T>(
            string query,
            IList<SqlParameter> parameters,
            Func<DbDataReader, T, T> callback) where T : new()
        {
            var dbCommand = new SqlCommand()
            {
                CommandText = query,
                //CommandType = CommandType.StoredProcedure,
            };

            using (dbCommand.Connection = GetConnection()) // Close connection automatically after request
            {
                foreach (var sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }

                return callback(dbCommand.ExecuteReader(), new T());    
            }
        }

        public T ExecuteScalar<T>(
            string query,
            IList<SqlParameter> parameters)            
        {
            var dbCommand = new SqlCommand()
            {
                CommandText = query,
            };

            using (dbCommand.Connection = GetConnection())
            {
                foreach (var sqlParameter in parameters)
                {
                    dbCommand.Parameters.Add(sqlParameter);
                }

                var queryResult = dbCommand.ExecuteScalar();
                if (queryResult is DBNull || queryResult == null)
                {
                    return default(T);
                }
                
                return (T) queryResult;    
            }
        }
        
        private SqlConnection GetConnection()
        {
            var connection = new SqlConnection
            {
                ConnectionString = ConfigurationManager.ConnectionStrings[DbName].ConnectionString
            };
            connection.Open();
            return connection;
        }
    }
}