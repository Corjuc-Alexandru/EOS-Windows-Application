using EOS.Password_Syntax;
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
    public partial class ChangePassForm : Form
    {
        public ChangePassForm()
        {
            InitializeComponent();
        }
        private void changeButton_Click(object sender, EventArgs e)
        {
            GetUsername.Userchangepass = changeUsertxtbox.Text;
            bool a = CheckPassword.ValidatePassword(changePasstxtbox.Text);
            if (a == true)
            {
                // Check if the form is already open
                if (Application.OpenForms.OfType<PasswordForm>().Any())
                {
                    // The form is already open, bring it to the front
                    Application.OpenForms.OfType<PasswordForm>().First().BringToFront();
                }
                else
                {
                    // The form is not open, create a new instance of it
                    PasswordForm passwordForm = new PasswordForm();
                    passwordForm.ShowDialog();
                    changeUsertxtbox.Clear();
                    changePasstxtbox.Clear();
                }
            }
            else
            {
                MessageBox.Show("Invalid password syntax!");
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
    }
}