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
            bool a = forgotConfirmpasstxtbox.Text == forgotPasstxtbox.Text;
            if (a == true)
            {
                bool b = CheckPassword.ValidatePassword(forgotPasstxtbox.Text);
                if (b == true)            
                {
                    SqlConnection sqlcon = ConnectLogin.GetLoginSqlcon();           
                    {                    
                        sqlcon.Open();                    
                        // Current password is correct, allow user to change password                    
                        string hashedNewPassword =
                            CryptPassword.GetMd5Hash(forgotPasstxtbox.Text);                    
                        // Store the hashed password in the database                    
                        using (SqlCommand updateCmd = new SqlCommand(
                            "UPDATE tbl_Login SET Password = @password WHERE " +
                            "Username = @username", sqlcon))                    
                        {                        
                            updateCmd.Parameters.AddWithValue(
                                "@password", hashedNewPassword);                        
                            updateCmd.Parameters.AddWithValue(
                                "@username", forgotUsertxtbox.Text);                        
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
                forgotPasstxtbox.PasswordChar = '\0'; 
                // show password in plain text
            }
            else
            {
                forgotPasstxtbox.PasswordChar = '*'; 
                // hide password
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                forgotConfirmpasstxtbox.PasswordChar = '\0'; 
                // show password in plain text
            }
            else
            {
                forgotConfirmpasstxtbox.PasswordChar = '*'; 
                // hide password
            }
        }
    }
}
