using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace EOS
{
    public partial class StocksForm : Form
    {
        public StocksForm()
        {
            InitializeComponent();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void StocksForm_Load(object sender, EventArgs e)
        {
            string tablename = GetUsername.Userloggedname;
            SqlConnection conn = ConnectUserStock.GetStockSqlcon();
            string sql = $"SELECT Inventory, Item, UM, Qty, Price " +
                $"FROM {tablename}";
            SqlDataAdapter adapter = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            adapter.Fill(dt);

            // Eliminați coloana "ID" din DataTable, dacă este prezentă
            if (dt.Columns.Contains("ID"))
            {
                dt.Columns.Remove("ID");
            }

            // Setarea proprietatii AllowUserToAddRows la false
            dataGridView1.AllowUserToAddRows = false;

            // Setarea proprietatii RowHeadersVisible la false
            dataGridView1.RowHeadersVisible = false;

            // Atribuiți DataTable la DataSource-ul DataGridView
            dataGridView1.DataSource = dt;
            while (dataGridView1.Rows.Count < dataGridView1.RowCount)
            {
                DataGridViewRow row = new DataGridViewRow();
                dataGridView1.Rows.Add(row);
            }
        }
    }
}
