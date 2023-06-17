using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace EOS.Command
{
    internal class Inventory
    {
        public string All()
        {
            string tablename = "Home";
            string tablename2 = "Work";
            string selectAll = $"SELECT *, '{tablename}' AS Inventory FROM {tablename} " +
                $"UNION ALL SELECT *, '{tablename2}' AS Inventory FROM {tablename2}";
            return selectAll;
        }
        public string Home()
        {
            string selectAll = "SELECT *, 'Home' AS Inventory FROM Home";
            return selectAll;
        }
        public string Work()
        {
            string selectAll = "SELECT *, 'Work' AS Inventory FROM Work";
            return selectAll;
        }
    }
}
