using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS
{
    internal class ConnectStock
    {
        public static SqlConnection GetStockSqlcon()
        {
            return new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;" +
            @"AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + @"\Database\" +
            @"stocks.mdf;Connect Timeout=30");
        }
    }
}