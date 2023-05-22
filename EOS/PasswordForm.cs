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
    public partial class PasswordForm : Form
    {
        public PasswordForm()
        {
            InitializeComponent();
        }

        private void newpassButton_Click(object sender, EventArgs e)
        {
            bool a = newpasstxtbox.Text == confirmpasstxtbox.Text;
            if (a == true)
            {
                SqlConnection sqlcon = ConnectUser.GetUserSqlcon();
                {
                    sqlcon.Open();
                    // allow user to change password                    
                    string hashedNewPassword =
                        CryptPassword.GetMd5Hash(newpasstxtbox.Text);
                    // Store the hashed password in the database                    
                    using (SqlCommand updateCmd = new SqlCommand(
                        "UPDATE tbl_Login SET Password = @password WHERE " +
                        "Username = @username", sqlcon))
                    {
                        updateCmd.Parameters.AddWithValue(
                            "@password", hashedNewPassword);
                        updateCmd.Parameters.AddWithValue(
                            "@username", GetUsername.Userchangepass);
                        updateCmd.ExecuteNonQuery();
                    }
                }
            }
            else
            {
                MessageBox.Show("The passwords doesn't match.");
            }
            MessageBox.Show("Password was changed!");
            this.Close();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                newpasstxtbox.PasswordChar = '\0';
                // show password in plain text
            }
            else
            {
                newpasstxtbox.PasswordChar = '*';
                // hide password
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                confirmpasstxtbox.PasswordChar = '\0';
                // show password in plain text
            }
            else
            {
                confirmpasstxtbox.PasswordChar = '*';
                // hide password
            }
        }

    }
}
