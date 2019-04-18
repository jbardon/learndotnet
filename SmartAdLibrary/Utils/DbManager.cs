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
        
        /**
         * Use SQL Server Express LocalDB (SqlLocalDB Utility)
         *
         * - SqlLocalDB Utility (sqllocaldb): manage instances
         * - sqlcmd utility : connect (command) + GO (to exec)
         * 
         * $ sqllocaldb info MSSQLLocalDB (stop/delete/start)
         * $ sqllocaldb share MSSQLLocalDB SharedName
         * $ sqlcmd -S "(LocalDB)\MSSQLLocalDB" -Q "query"
         *
         * 1> select name from master.sys.databases
         * 1> create database learndotnet ON (
         *     Name='learndotnet',
         *     Filename='C:\smartdays\learndotnet\SmartAdLibrary\App_Data\Database\LearndotnetDB.mdf'
         * )
         * 2> go
         *
         * For shared: (LocalDB)\.\SharedName but DB saved in .mdf file         
         * 
         * Data Source=(LocalDB)\MSSQLLocalDB;
         * AttachDbFilename=C:\smartdays\learndotnet\SmartAdLibrary\App_Data\Database\LearndotnetDB.mdf;
         * Integrated Security=True
         *
         * https://www.sqlshack.com/how-to-connect-and-use-microsoft-sql-server-express-localdb/
         * https://stackoverflow.com/questions/15853382/how-to-manually-create-a-mdf-file-for-localdb-to-use/37049471
         * https://codemegeek.com/2018/05/13/configure-iis-to-us-localdb/
         *
         * LocalDB needs user profile to be loaded
         *
         * https://stackoverflow.com/questions/17012839/cannot-attach-the-file-mdf-as-database
         * https://forums.asp.net/t/2061083.aspx?Cannot+attach+the+file+mdf+as+database
         */
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