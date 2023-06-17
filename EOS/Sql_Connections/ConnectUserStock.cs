using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS
{
    internal class ConnectUserStock
    {
        public static SqlConnection GetStockSqlcon()
        {
            return new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;" +
            @"AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + @"Database\" +
            $"{GetUsername.Userloggedname}.mdf;Connect Timeout=30");
        }
        public static SqlConnection GetSignupUserSqlcon()
        {
            return new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;" +
            @"AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + @"Database\" +
            $"{GetUsername.userSignUp}.mdf;Connect Timeout=30");
        }
    }
}