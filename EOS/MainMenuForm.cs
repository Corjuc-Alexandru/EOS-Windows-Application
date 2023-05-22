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
            //Show what user is logged in
            label1.Text = "Logged in as " + GetUsername.Userloggedname;

        }

        private void exitToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void entryToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Check if the form is already open
            if (Application.OpenForms.OfType<InsertStockForm>().Any())
            {
                // The form is already open, bring it to the front
                Application.OpenForms.OfType<InsertStockForm>().First().BringToFront();
            }
            else
            {
                // The form is not open, create a new instance of it
                InsertStockForm insertStock = new InsertStockForm();
                insertStock.Show();
            }

        }

        private void accountSettingsToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            // Check if the form is already open
            if (Application.OpenForms.OfType<ChangePassForm>().Any())
            {
                // The form is already open, bring it to the front
                Application.OpenForms.OfType<ChangePassForm>().First().BringToFront();
            }
            else
            {
                // The form is not open, create a new instance of it
                ChangePassForm changePassForm = new ChangePassForm();
                changePassForm.Show();
            }
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

        private void switchAccountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void deleteAccountToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            if (Application.OpenForms.OfType<DeleteAccountForm>().Any())
            {
                // The form is already open, bring it to the front
                Application.OpenForms.OfType<DeleteAccountForm>().First().BringToFront();
            }
            else
            {
                // The form is not open, create a new instance of it
                DeleteAccountForm deleteAccountForm = new DeleteAccountForm();
                deleteAccountForm.Show();
            }
        }

        private void outToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Check if the form is already open
            if (Application.OpenForms.OfType<EditStockForm>().Any())
            {
                // The form is already open, bring it to the front
                Application.OpenForms.OfType<EditStockForm>().First().BringToFront();
            }
            else
            {
                // The form is not open, create a new instance of it
                EditStockForm outstockForm = new EditStockForm();
                outstockForm.Show();
            }
        }
    }
}