using System;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace EOS
{
    public partial class MainMenuForm : Form
    {
        public MainMenuForm()
        {
            InitializeComponent();
        }

        private void MainMenuForm_Load(object sender, EventArgs e)
        {
            LoginForm loginForm = new LoginForm();
            if (loginForm.ShowDialog() != DialogResult.OK)
            {
                this.Close();
            }
            string username = GetUsername.Userloggedname;
            label1.Text = "Logged in as " + username; // replace "label1" with the actual name of your Label control

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void entryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Check if the form is already open
            if (Application.OpenForms.OfType<InsertStock>().Any())
            {
                // The form is already open, bring it to the front
                Application.OpenForms.OfType<InsertStock>().First().BringToFront();
            }
            else
            {
                // The form is not open, create a new instance of it
                InsertStock insertStock = new InsertStock();
                insertStock.Show();
            }

        }

        private void accountSettingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            ForgotForm forgotForm = new ForgotForm();
            forgotForm.Show();
        }

        private void stocksToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            if (Application.OpenForms.OfType<StocksForm>().Any())
            {
                // The form is already open, bring it to the front
                Application.OpenForms.OfType<StocksForm>().First().BringToFront();
            }
            else
            {
                // The form is not open, create a new instance of it
                StocksForm stockForm = new StocksForm();
                stockForm.Show();
            }
        }
    }
}