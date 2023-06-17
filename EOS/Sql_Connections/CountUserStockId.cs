using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace EOS
{
    internal class CountUserStockId
    {
        public static int B()
        {
            string tbl_logged = "Home";
            string stmt = $"SELECT COUNT(*) FROM dbo.[{tbl_logged}]";
            SqlConnection thisConnection = ConnectUserStock.GetStockSqlcon();
            int count;
            {   
                SqlCommand command = new SqlCommand(stmt, thisConnection);
                {
                    thisConnection.Open();
                    count = (int)command.ExecuteScalar();
                }
            }
            return count;
        }
    }
}
