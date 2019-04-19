using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;

namespace SmartAdLibrary.Utils
{
    public interface IDbManager
    {
        T ExecuteReader<T>(string query, IList<SqlParameter> parameters, 
            Func<DbDataReader, T, T> callback) where T : new();

        T ExecuteScalar<T>(string query, IList<SqlParameter> parameters);
    }
}