using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EOS
{
    internal class CountLoginId
    {
        public static int A()
        {
            string stmt = "SELECT COUNT(*) FROM tbl_Login";
            SqlConnection thisConnection = ConnectLogin.GetLoginSqlcon();
            int count;
            {
                SqlCommand cmdCount = new SqlCommand(stmt, thisConnection);
                {
                    thisConnection.Open();
                    count = (int)cmdCount.ExecuteScalar();
                }
            }
            return count;
        }
    }
}
