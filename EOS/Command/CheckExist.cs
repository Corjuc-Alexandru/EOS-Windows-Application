﻿using EOS.Sql_Connections;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace EOS.Command
{
    public class CheckExist
    {
        public bool IsUserDatabaseExists()
        {
            string databaseName = "users";
            string query = "SELECT COUNT(*) FROM sys.databases WHERE name = @Name";
            using (SqlConnection connection = ConnectSQL.GetSqlcon())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", databaseName);
                    connection.Open();
                    int databaseCount = (int)command.ExecuteScalar();
                    return databaseCount > 0;
                }
            }
        }
        public bool IsStocksDatabaseExist()
        {
            string databaseName = "stocks";
            string query = "SELECT COUNT(*) FROM sys.databases WHERE name = @Name";
            using (SqlConnection connection = ConnectSQL.GetSqlcon())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", databaseName);
                    connection.Open();
                    int databaseCount = (int)command.ExecuteScalar();
                    return databaseCount > 0;
                }
            }
        }
        public bool IsUserExists()
        {
            var name = GetUsername.userSignUp;
            var table = "tbl_Login";
            var column = "username";
            string query = "SELECT COUNT(*) FROM " + table + " WHERE "
                + column + " = @Name";

            using (SqlConnection connection = ConnectLogin.GetLoginSqlcon())
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

    }
}
