using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace EOS
{
    internal class ConnectLogin
    {
        public static SqlConnection GetLoginSqlcon()
        {
            return new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;" +
            @"AttachDbFilename=" + AppDomain.CurrentDomain.BaseDirectory + @"Database\" +
            @"users.mdf;Connect Timeout=30");
        }

    }
}
