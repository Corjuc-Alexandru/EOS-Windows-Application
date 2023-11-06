using System;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace EOS
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, 
            LinkLabelLinkClickedEventArgs e)
        {
            SignupForm signForm = new SignupForm();
            signForm.ShowDialog();
        }

        private void loginUsertxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // suppress the enter key
                e.SuppressKeyPress = true; // suppress the beep sound
                loginButton.PerformClick(); // perform the login action
                loginUsertxtbox.Clear();
                loginPasswordtxtbox.Clear();
            }
        }

        private void loginPasswordtxtbox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.Handled = true; // suppress the enter key
                e.SuppressKeyPress = true; // suppress the beep sound
                loginButton.PerformClick(); // perform the login action
                loginUsertxtbox.Clear();
                loginPasswordtxtbox.Clear();
            }
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //verify hashed password
            string inputPassword = loginPasswordtxtbox.Text;
            string hashedInputPassword = CryptPassword.GetMd5Hash(inputPassword);
            //create instanace of database connection
            SqlConnection sqlcon1 = ConnectLogin.GetLoginSqlcon();
            string querry = 
                "Select * from tbl_Login Where username = '" + loginUsertxtbox.Text + "' " +
                "and password = '" + hashedInputPassword + "'";
            SqlDataAdapter sda = new SqlDataAdapter(querry, sqlcon1);
            DataTable dtbl = new DataTable();
            sda.Fill(dtbl);

            if (dtbl.Rows.Count == 1)
            {
                GetUsername.Userloggedname = loginUsertxtbox.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            }

            else
            {
                MessageBox.Show("wrong user or password");
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                loginPasswordtxtbox.PasswordChar = '\0'; 
                // show password in plain text
            }

            else
            {
                loginPasswordtxtbox.PasswordChar = '*'; 
                // hide password
            }
        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgotForm forgotForm = new ForgotForm();
            forgotForm.ShowDialog();
        }
    }
}
