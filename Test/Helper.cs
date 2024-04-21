using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Threading.Tasks;
using Npgsql;

namespace Test
{
    public class Helper
    {
        public static readonly NpgsqlDataSource dataSource;
        public static readonly string testConnectionString 
                                = "Server=localhost:5432;Database=CurrencyConverted;User Id=appuser;Password=secret;";
    
    static Helper()
    {
        try
        {
            dataSource = new NpgsqlDataSourceBuilder(testConnectionString).Build();
            dataSource.OpenConnection().Close();
        }
        catch (Exception)
        {
            throw new Exception("There is a problem with the dataSource!");
        }
    }

        public NpgsqlDataSource GetNpgsqlDataSource()
        {
            return dataSource;
        }
    }
}