using EOS.Password_Syntax;
using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EOS
{
    public partial class ForgotForm : Form
    {
        public ForgotForm()
        {
            InitializeComponent();
        }

        private void changeButton_Click(object sender, EventArgs e)
        {
            bool a = changeConfirmpasstxtbox.Text == changePasstxtbox.Text;
            if (a == true)
            {
                bool b = CheckPassword.ValidatePassword(changePasstxtbox.Text);
                if (b == true)            
                {
                    SqlConnection sqlcon = ConnectUser.GetUserSqlcon();           
                    {                    
                        sqlcon.Open();                    
                        // Current password is correct, allow user to change password                    
                        string hashedNewPassword =
                            CryptPassword.GetMd5Hash(changePasstxtbox.Text);                    
                        // Store the hashed password in the database                    
                        using (SqlCommand updateCmd = new SqlCommand(
                            "UPDATE tbl_Login SET Password = @password WHERE " +
                            "Username = @username", sqlcon))                    
                        {                        
                            updateCmd.Parameters.AddWithValue(
                                "@password", hashedNewPassword);                        
                            updateCmd.Parameters.AddWithValue(
                                "@username", changeUsertxtbox.Text);                        
                            updateCmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Password was changed!");
                        this.Close();
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

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Close();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                changePasstxtbox.PasswordChar = '\0'; 
                // show password in plain text
            }
            else
            {
                changePasstxtbox.PasswordChar = '*'; 
                // hide password
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                changeConfirmpasstxtbox.PasswordChar = '\0'; 
                // show password in plain text
            }
            else
            {
                changeConfirmpasstxtbox.PasswordChar = '*'; 
                // hide password
            }
        }
    }
}
