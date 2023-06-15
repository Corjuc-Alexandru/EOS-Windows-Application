using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS.Sql_Connections
{
    internal class ConnectSQL
    {
        public static SqlConnection GetSqlcon()
        {
            return new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;" +
            @"Initial Catalog=master;");
        }
    }
}
