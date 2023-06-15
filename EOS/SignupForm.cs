using EOS.Password_Syntax;
using EOS.Sql_Connections;
using System;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

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
          /*  if (CheckExist())
            {
                MessageBox.Show("That username already exist in database!");
            }
            else
            {*/
                bool a = signupConfirmpasstxtbox.Text == signupPasstxtbox.Text;
                if (a == true)
                {
                    bool b = CheckPassword.ValidatePassword(signupPasstxtbox.Text);
                    if (b == true)
                    {
                        // Creare baza de date
                        string createDatabaseQuery = "CREATE DATABASE user123";

                        SqlConnection connectionsql = ConnectSQL.GetSqlcon();
                        {
                            SqlCommand createDatabaseCommand = new SqlCommand(createDatabaseQuery, connectionsql);
                            connectionsql.Open();
                            createDatabaseCommand.ExecuteNonQuery();
                            connectionsql.Close();
                        }

                        // Creare tabel "tbl_Login" în baza de date
                        string createTableQuery = "CREATE TABLE tbl_Login (loginId INT PRIMARY KEY, username NVARCHAR(50), password NVARCHAR(50))";


                        {
                            SqlCommand createTable = new SqlCommand(createTableQuery, connectionsql);
                            connectionsql.Open();
                            createTable.ExecuteNonQuery();
                            connectionsql.Close();
                        }
                    int id = CountUserId.A() + 1;

                    if (CheckExist())
                        {
                            MessageBox.Show("That username already exist in database!");
                        }
                        else
                        {
                            //get password hashed for store in database
                            string hashedPassword =
                                CryptPassword.GetMd5Hash(signupPasstxtbox.Text);
                        //create instanace of database connection
                        string querry1 = "INSERT INTO tbl_Login(loginId, username, "
                            + "password) VALUES ('" + id + "','"
                            + signupUsertxtbox.Text + "', '" + hashedPassword + "')";
                        SqlConnection sqlcon = ConnectUser.GetUserSqlcon();
                        {
                            SqlCommand command = new SqlCommand(querry1, sqlcon);
                            {
                                sqlcon.Open();
                                command.ExecuteNonQuery();
                            }
                        }
                        // Create a new SqlConnection object
                        SqlConnection connection = ConnectStock.GetStockSqlcon();

                        // Open the connection
                        connection.Open();
                        // SQL Server connection string
                        string tableName = signupUsertxtbox.Text;
                        string columnID = "ID";
                        string columnInventory = "Inventory";
                        string columnItem = "Item";
                        string columnUM = "UM";
                        string columnQty = "Qty";
                        string columnPrice = "Price";
                        string columnDate = "Date";

                        // create SQL query to create table
                        string sqlQuery = $"CREATE TABLE {tableName} ({columnID} " +
                            $"INT PRIMARY KEY, {columnInventory} " +
                            $"VARCHAR(50), {columnItem} VARCHAR(50), {columnUM} " +
                            $"VARCHAR(10), {columnQty} INT, {columnPrice} " +
                            $"DECIMAL(10,2), {columnDate} DATE)";
                        // Create a new SqlCommand object with the
                        // CREATE TABLE query
                        SqlCommand createTableCommand =
                            new SqlCommand(sqlQuery, connection);
                        // Execute the query
                        createTableCommand.ExecuteNonQuery();

                        // Close the connection
                        connection.Close();

                        // Grant INSERT permission to a user or role
                        connection.Open();
                        createTableCommand = new SqlCommand($"GRANT INSERT " +
                            $"ON dbo.{tableName} TO public", connection);
                        createTableCommand.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("SignIn succesful!");
                        this.Close();
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
           // }
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

        private bool CheckExist()
        {
            var name = signupUsertxtbox.Text;
            var table = "tbl_Login";
            var column = "username";
            string query = "SELECT COUNT(*) FROM " + table + " WHERE "
                + column + " = @Name";

            SqlConnection connection = ConnectUser.GetUserSqlcon();
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