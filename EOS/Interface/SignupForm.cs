using EOS.Command;
using EOS.Password_Syntax;
using EOS.Sql_Connections;
using System;
using System.Data.SqlClient;
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
                    GetUsername.userSignUp = signupUsertxtbox.Text;
                    string folderpath = 
                        AppDomain.CurrentDomain.BaseDirectory + @"Database";
                    if (!Directory.Exists(folderpath))
                    {
                        Directory.CreateDirectory(folderpath);
                    }

                    CheckExist checker = new CheckExist();
                    bool c = checker.IsUserDatabaseExists();

                    if (!c)
                    {
                        // Create a new SQL connection
                        using (SqlConnection connectionSql = ConnectSQL.GetSqlcon())
                        {
                            // Create the database
                            string loginDatabase = "users";

                            string userDatabase = GetUsername.userSignUp;

                            string loginDatabaseFilePath = 
                                Path.Combine(folderpath, "users.mdf");

                            string userDatabaseFilePath =
                                Path.Combine(folderpath, $"{userDatabase}.mdf");

                            string loginDatabaseLogFilePath = 
                                Path.Combine(folderpath, "users_log.ldf");

                            string userDatabaseLogFilePath =
                                Path.Combine(folderpath, $"{userDatabase}_log.ldf");

                            string createDatabaseQuery =
                                $"CREATE DATABASE {loginDatabase} ON (NAME = " +
                                $"'{loginDatabase}', FILENAME = '{loginDatabaseFilePath}') " +
                                $"LOG ON (NAME = '{loginDatabase}_log', " +
                                $"FILENAME = '{loginDatabaseLogFilePath}') " +
                                $"CREATE DATABASE {userDatabase} ON (NAME = " +
                                $"'{userDatabase}', FILENAME = " +
                                $"'{userDatabaseFilePath}') " +
                                $"LOG ON (NAME = '{userDatabase}_log', FILENAME = " +
                                $"'{userDatabaseLogFilePath}')";

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
                                ConnectLogin.GetLoginSqlcon())
                            {
                                userconnection.Open();
                                // Create the user login table in the database
                                string createTableQuery = "CREATE TABLE tbl_Login " +
                                    "(loginId INT IDENTITY (1,1) PRIMARY KEY, username " +
                                    "NVARCHAR(50), password NVARCHAR(50))";
                                using (SqlCommand createTable =
                                new SqlCommand(createTableQuery, userconnection))
                                {
                                    createTable.ExecuteNonQuery();
                                }
                            }
                        }

                        bool checkuser = checker.IsUserExists();

                        if (checkuser)
                        {
                            MessageBox.Show("That username already exist in database!");
                        }

                        else
                        {
                            //get password hashed for store in database
                            string hashedPassword =
                                CryptPassword.GetMd5Hash(signupPasstxtbox.Text);

                            string insertUser = "INSERT INTO tbl_Login(" +
                                "username, password) VALUES ('"
                                + signupUsertxtbox.Text + "', '" + hashedPassword + "')";

                            SqlConnection userSqlCon = ConnectLogin.GetLoginSqlcon();
                            {
                                SqlCommand command = new SqlCommand(insertUser,
                                    userSqlCon);
                                {
                                    userSqlCon.Open();
                                    command.ExecuteNonQuery();
                                    userSqlCon.Close();
                                }
                            }

                            SqlConnection stockSqlCon = ConnectUserStock.GetSignupUserSqlcon();
                            {
                                // SQL Server connection string
                                stockSqlCon.Open();
                                string tableName = "Home";
                                string tableName2 = "Work";
                                string columnID = "ID";
                                string columnItem = "Item";
                                string columnUM = "UM";
                                string columnQty = "Qty";
                                string columnPrice = "Price";
                                string columnDate = "Date";
                                // create SQL query to create table
                                string createStockTable = $"CREATE TABLE " +
                                    $"{tableName} ({columnID} " +
                                    $"INT IDENTITY(1,1) PRIMARY KEY, {columnItem} VARCHAR(50)," +
                                    $" {columnUM} VARCHAR(10), {columnQty} INT, {columnPrice} " +
                                    $"DECIMAL(10,2), {columnDate} DATE);" +
                                    $"CREATE TABLE " +
                                    $"{tableName2} ({columnID} " +
                                    $"INT IDENTITY(1,1) PRIMARY KEY, {columnItem} VARCHAR(50)," +
                                    $" {columnUM} VARCHAR(10), {columnQty} INT, {columnPrice} " +
                                    $"DECIMAL(10,2), {columnDate} DATE);";

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
                        bool checkuser = checker.IsUserExists();

                        if (checkuser)
                        {
                            MessageBox.Show("That username already exist in " +
                                "database!");
                        }

                        else
                        {
                            //get password hashed for store in database
                            string hashedPassword =
                                CryptPassword.GetMd5Hash(signupPasstxtbox.Text);

                            string insertUser = "INSERT INTO tbl_Login(" +
                                "username, password) VALUES ('"
                                + signupUsertxtbox.Text + "', '" + hashedPassword + "')";

                            SqlConnection userSqlCon = ConnectLogin.GetLoginSqlcon();
                            {
                                SqlCommand command = new SqlCommand(insertUser,
                                    userSqlCon);
                                {
                                    userSqlCon.Open();
                                    command.ExecuteNonQuery();
                                    userSqlCon.Close();
                                }
                            }

                            using (SqlConnection connectionSql = ConnectSQL.GetSqlcon())
                            {
                                // Create the database
                                string userDatabase = GetUsername.userSignUp;

                                string userDatabaseFilePath =
                                    Path.Combine(folderpath, $"{userDatabase}.mdf");

                                string userDatabaseLogFilePath =
                                    Path.Combine(folderpath, $"{userDatabase}_log.ldf");

                                string createDatabaseQuery =
                                    $"CREATE DATABASE {userDatabase} ON (NAME = " +
                                    $"'{userDatabase}', FILENAME = " +
                                    $"'{userDatabaseFilePath}') " +
                                    $"LOG ON (NAME = '{userDatabase}_log', FILENAME = " +
                                    $"'{userDatabaseLogFilePath}')";

                                using (SqlConnection connection = ConnectSQL.GetSqlcon())
                                {
                                    using (SqlCommand command =
                                        new SqlCommand(createDatabaseQuery, connection))
                                    {
                                        connection.Open();
                                        command.ExecuteNonQuery();
                                    }
                                }

                                // Create a new SQL connection to Stock database
                                SqlConnection stockSqlCon = 
                                    ConnectUserStock.GetSignupUserSqlcon();
                                {
                                    // SQL Server connection string
                                    stockSqlCon.Open();
                                    string tableName = "Home";
                                    string tableName2 = "Work";
                                    string columnID = "ID";
                                    string columnItem = "Item";
                                    string columnUM = "UM";
                                    string columnQty = "Qty";
                                    string columnPrice = "Price";
                                    string columnDate = "Date";
                                    // create SQL query to create table
                                    string createStockTable = $"CREATE TABLE " +
                                        $"{tableName} ({columnID} " +
                                        $"INT IDENTITY(1,1) PRIMARY KEY, {columnItem} " +
                                        $"VARCHAR(50), {columnUM} " +
                                        $"VARCHAR(10), {columnQty} INT, {columnPrice} " +
                                        $"DECIMAL(10,2), {columnDate} DATE);" +
                                        $"CREATE TABLE " +
                                        $"{tableName2} ({columnID} " +
                                        $"INT IDENTITY(1,1) PRIMARY KEY, {columnItem} " +
                                        $"VARCHAR(50), {columnUM} " +
                                        $"VARCHAR(10), {columnQty} INT, {columnPrice} " +
                                        $"DECIMAL(10,2), {columnDate} DATE);";

                                    SqlCommand createTableCommand =
                                        new SqlCommand(createStockTable, stockSqlCon);

                                    createTableCommand.ExecuteNonQuery();
                                    stockSqlCon.Close();
                                }
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
    }
}