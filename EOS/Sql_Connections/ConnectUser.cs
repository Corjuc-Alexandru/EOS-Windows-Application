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
    internal class ConnectUser
    {
        public static SqlConnection GetUserSqlcon()
        {
            return new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;" +
            @"AttachDbFilename=C:\Users\alexd\source\repos\EOS\EOS\Database\" +
            @"users.mdf;Connect Timeout=30");
        }

    }
}
