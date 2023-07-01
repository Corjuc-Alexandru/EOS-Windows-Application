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
            string selectAll = $"SELECT *, 'Home' AS Inventory FROM Home " +
                $"UNION ALL SELECT *, 'Work' AS Inventory FROM Work";
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
