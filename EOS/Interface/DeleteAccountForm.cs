using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EOS
{
    public partial class DeleteAccountForm : Form
    {
        public DeleteAccountForm()
        {
            InitializeComponent();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                deletePasswordtxtbox.PasswordChar = '\0';
                // show password in plain text
            }
            else
            {
                deletePasswordtxtbox.PasswordChar = '*';
                // hide password
            }
        }
        private void deleteButton_Click(object sender, EventArgs e)
        {
            //verify hashed password
            string inputPassword = deletePasswordtxtbox.Text;
            string hashedInputPassword = CryptPassword.GetMd5Hash(inputPassword);
            //create instanace of database connection
            SqlConnection sqlcon = ConnectLogin.GetLoginSqlcon();
            string querry = "Select * from tbl_Login Where username = '"
                + deleteUsertxtbox.Text + "' and password = '"
                + hashedInputPassword + "'";
            SqlDataAdapter sda = new SqlDataAdapter(querry, sqlcon);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);
            if (dtbl.Rows.Count == 1)
            {
                //create instanace of database connection
                SqlConnection sqlconuser = ConnectLogin.GetLoginSqlcon();
                //create SQL query to delete user from database
                string querryuser = "DELETE from tbl_Login Where username = '"
                    + deleteUsertxtbox.Text + "'";
                //
                SqlDataAdapter sda1 = new SqlDataAdapter(querryuser, sqlconuser);
                //Fill new data to table
                DataTable dtbl1 = new DataTable();
                sda1.Fill(dtbl1);
                // Create a new SqlConnection object
                SqlConnection connectionstock = ConnectUserStock.GetStockSqlcon();
                // Open the connection
                connectionstock.Open();
                // create SQL query to delete table
                string sqlQuerystock = $"DROP DATABASE {deleteUsertxtbox.Text}";
                // Create a new SqlCommand object with the
                // DELETE TABLE query
                SqlCommand deleteTableCommand =
                    new SqlCommand(sqlQuerystock, connectionstock);
                // Execute the query
                deleteTableCommand.ExecuteNonQuery();

                // Close the connection
                connectionstock.Close();
                MessageBox.Show("The user was succesfuly deleted!");
                if (deleteUsertxtbox.Text == GetUsername.Userloggedname)
                {
                    Application.Restart();
                }
                else
                {
                    deleteUsertxtbox.Clear();
                    deletePasswordtxtbox.Clear();
                }
            }
            else
            {
                MessageBox.Show("wrong user or password");
            }
        }
    }
}
