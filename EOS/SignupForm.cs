using EOS.Command;
using EOS.Password_Syntax;
using EOS.Sql_Connections;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using System.IO;
namespace EOS
{
    public partial class SignupForm : Form
    {
        public SignupForm()
        {
            InitializeComponent();
        }

        private void signupUsertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // suppress the enter key
                e.SuppressKeyPress = true; // suppress the beep sound
                signupButton.PerformClick(); // perform the login action
                signupUsertxtbox.Clear();
                signupPasstxtbox.Clear();
                signupConfirmpasstxtbox.Clear();
            }
        }

        private void singupPasstxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // suppress the enter key
                e.SuppressKeyPress = true; // suppress the beep sound
                signupButton.PerformClick(); // perform the login action
                signupUsertxtbox.Clear();
                signupPasstxtbox.Clear();
                signupConfirmpasstxtbox.Clear();
            }
        }

        private void signupConfirmpasstxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // suppress the enter key
                e.SuppressKeyPress = true; // suppress the beep sound
                signupButton.PerformClick(); // perform the login action
                signupUsertxtbox.Clear();
                signupPasstxtbox.Clear();
                signupConfirmpasstxtbox.Clear();
            }
        }

        private void signupButton_Click(object sender, EventArgs e)
        {                
            bool a = signupConfirmpasstxtbox.Text == signupPasstxtbox.Text;                
            if (a == true)
            {                    
                bool b = CheckPassword.ValidatePassword(signupPasstxtbox.Text);
                if (b == true)
                {
                    string folderpath = AppDomain.CurrentDomain.BaseDirectory + 
                        @"\Database";
                    if (!Directory.Exists(folderpath))
                    {
                        Directory.CreateDirectory(folderpath);
                    }
                    CheckExist checker = new CheckExist();
                    bool c = checker.IsUserDatabaseExists();
                    bool d = checker.IsStocksDatabaseExist();
                    if (!c && !d)
                    {
                        // Create a new SQL connection
                        using (SqlConnection connectionSql = ConnectSQL.GetSqlcon())
                        {
                            // Create the database
                            string databaseName = "users";
                            string stockdatabase = "stocks";
                            string databaseFilePath = 
                                Path.Combine(folderpath, "users.mdf");
                            string stockdatabaseFilePath =
                                Path.Combine(folderpath, "stocks.mdf");
                            string databaseLogFilePath = 
                                Path.Combine(folderpath, "users_log.ldf");
                            string stockdatabaseLogFilePath =
                                Path.Combine(folderpath, "stocks_log.ldf");
                            string createDatabaseQuery =
                                $"CREATE DATABASE {databaseName} ON (NAME = " +
                                $"'{databaseName}', FILENAME = '{databaseFilePath}') " +
                                $"LOG ON (NAME = '{databaseName}_log', " +
                                $"FILENAME = '{databaseLogFilePath}') " +
                                $"CREATE DATABASE {stockdatabase} ON (NAME = " +
                                $"'{stockdatabase}', FILENAME = " +
                                $"'{stockdatabaseFilePath}') " +
                                $"LOG ON (NAME = '{stockdatabase}_log', FILENAME = " +
                                $"'{stockdatabaseLogFilePath}')";
                            using (SqlConnection connection = ConnectSQL.GetSqlcon())
                            {
                                using (SqlCommand command = 
                                    new SqlCommand(createDatabaseQuery, connection))
                                {
                                    connection.Open();
                                    command.ExecuteNonQuery();
                                }
                            }
                            using (SqlConnection userconnection = 
                                ConnectUser.GetUserSqlcon())
                            {
                                userconnection.Open();
                                // Create the user login table in the database
                                string createTableQuery = "CREATE TABLE tbl_Login " +
                                    "(loginId INT PRIMARY KEY, username NVARCHAR(50), " +
                                    "password NVARCHAR(50))";
                                using (SqlCommand createTable =
                                new SqlCommand(createTableQuery, userconnection))
                                {
                                    createTable.ExecuteNonQuery();
                                }
                            }
                        }
                        //get unique id to set it into database
                        int id = CountUserId.A() + 1;
                        if (CheckUserExist())
                        {
                            MessageBox.Show("That username already exist in " +
                                "database!");
                        }
                        else
                        {
                            //get password hashed for store in database
                            string hashedPassword =
                                CryptPassword.GetMd5Hash(signupPasstxtbox.Text);
                            // Create a new SQL connection to User database
                            string insertUser = "INSERT INTO tbl_Login(loginId, " +
                                "username, password) VALUES ('" + id + "','"
                                + signupUsertxtbox.Text + "', '" + hashedPassword + "')";
                            SqlConnection userSqlCon = ConnectUser.GetUserSqlcon();
                            {
                                SqlCommand command = new SqlCommand(insertUser,
                                    userSqlCon);
                                {
                                    userSqlCon.Open();
                                    command.ExecuteNonQuery();
                                    userSqlCon.Close();
                                }
                            }
                            // Create a new SQL connection to Stock database
                            SqlConnection stockSqlCon = ConnectStock.GetStockSqlcon();
                            {
                                // SQL Server connection string
                                stockSqlCon.Open();
                                string tableName = signupUsertxtbox.Text;
                                string columnID = "ID";
                                string columnInventory = "Inventory";
                                string columnItem = "Item";
                                string columnUM = "UM";
                                string columnQty = "Qty";
                                string columnPrice = "Price";
                                string columnDate = "Date";
                                // create SQL query to create table
                                string createStockTable = $"CREATE TABLE " +
                                    $"{tableName} ({columnID} " +
                                    $"INT PRIMARY KEY, {columnInventory} " +
                                    $"VARCHAR(50), {columnItem} VARCHAR(50), {columnUM} " +
                                    $"VARCHAR(10), {columnQty} INT, {columnPrice} " +
                                    $"DECIMAL(10,2), {columnDate} DATE)";
                                SqlCommand createTableCommand =
                                    new SqlCommand(createStockTable, stockSqlCon);
                                createTableCommand.ExecuteNonQuery();
                                stockSqlCon.Close();
                            }
                            MessageBox.Show("SignIn succesful!");
                            this.Close();
                        }
                    }
                    else
                    {
                        //get unique id to set it into database
                        int id = CountUserId.A() + 1;
                        if (CheckUserExist())
                        {
                            MessageBox.Show("That username already exist in " +
                                "database!");
                        }
                        else
                        {
                            //get password hashed for store in database
                            string hashedPassword =
                                CryptPassword.GetMd5Hash(signupPasstxtbox.Text);
                            // Create a new SQL connection to User database
                            string insertUser = "INSERT INTO tbl_Login(loginId, " +
                                "username, password) VALUES ('" + id + "','"
                                + signupUsertxtbox.Text + "', '" + hashedPassword + "')";
                            SqlConnection userSqlCon = ConnectUser.GetUserSqlcon();
                            {
                                SqlCommand command = new SqlCommand(insertUser,
                                    userSqlCon);
                                {
                                    userSqlCon.Open();
                                    command.ExecuteNonQuery();
                                    userSqlCon.Close();
                                }
                            }
                            // Create a new SQL connection to Stock database
                            SqlConnection stockSqlCon = ConnectStock.GetStockSqlcon();
                            {
                                // SQL Server connection string
                                stockSqlCon.Open();
                                string tableName = signupUsertxtbox.Text;
                                string columnID = "ID";
                                string columnInventory = "Inventory";
                                string columnItem = "Item";
                                string columnUM = "UM";
                                string columnQty = "Qty";
                                string columnPrice = "Price";
                                string columnDate = "Date";
                                // create SQL query to create table
                                string createStockTable = $"CREATE TABLE " +
                                    $"{tableName} ({columnID} " +
                                    $"INT PRIMARY KEY, {columnInventory} " +
                                    $"VARCHAR(50), {columnItem} VARCHAR(50), {columnUM} " +
                                    $"VARCHAR(10), {columnQty} INT, {columnPrice} " +
                                    $"DECIMAL(10,2), {columnDate} DATE)";
                                SqlCommand createTableCommand =
                                    new SqlCommand(createStockTable, stockSqlCon);
                                createTableCommand.ExecuteNonQuery();
                                /*// Grant INSERT permission to a user or role
                                createTableCommand = new SqlCommand($"GRANT INSERT " +
                                    $"ON dbo.{tableName} TO public", stockSqlCon);
                                createTableCommand.ExecuteNonQuery();*/
                                stockSqlCon.Close();
                            }
                            MessageBox.Show("SignIn succesful!");
                            this.Close();
                        }
                    }
                }                    
                else
                {
                    MessageBox.Show("Invalid password syntax!");
                }
            }
            else            
            {            
                MessageBox.Show("The passwords doesn't match.");   
            }
        }

        private void linkLabel1_LinkClicked(object sender, 
            LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                signupPasstxtbox.PasswordChar = '\0'; 
                // show password in plain text
            }
            else
            {
                signupPasstxtbox.PasswordChar = '*'; 
                // hide password
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                signupConfirmpasstxtbox.PasswordChar = '\0';
                // show password in plain text
            }
            else
            {
                signupConfirmpasstxtbox.PasswordChar = '*';
                // hide password
            }
        }

        private bool CheckUserExist()
        {
            var name = signupUsertxtbox.Text;
            var table = "tbl_Login";
            var column = "username";
            string query = "SELECT COUNT(*) FROM " + table + " WHERE "
                + column + " = @Name";

            using (SqlConnection connection = ConnectUser.GetUserSqlcon())
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