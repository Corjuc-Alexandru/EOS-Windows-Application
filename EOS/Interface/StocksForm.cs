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
            string tablename = "Home";
            string tablename2 = "Work";
            SqlConnection conn = ConnectUserStock.GetStockSqlcon();
            string selectAll = $"SELECT *, '{tablename}' AS Inventory FROM {tablename} " +
                $"UNION ALL SELECT *, '{tablename2}' AS Inventory FROM {tablename2}";
            SqlCommand command = new SqlCommand(selectAll, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            // Eliminarea coloanei "ID" din dataGridView1 (dacă există)
            if (dataGridView1.Columns.Contains("ID"))
            {
                dataGridView1.Columns.Remove("ID");
            }

            // Adăugarea coloanei "TableName" la începutul dataGridView1
            dataGridView1.Columns.Add("Inventory", "Inventory");

            // Adăugarea coloanelor din primul tabel
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string columnName = reader.GetName(i);
                if (columnName != "ID" && columnName != "Inventory")
                {
                    dataGridView1.Columns.Add(columnName, columnName);
                }
            }

            // Setarea corectă a numărului de coloane înainte de adăugarea rândurilor
            int columnCount = dataGridView1.Columns.Count;
            // Obțineți referința coloanei "Date" din dataGridView1
            DataGridViewColumn dateColumn = dataGridView1.Columns["Date"];

            // Setarea opțiunii de formatare pentru a afișa doar data
            dateColumn.DefaultCellStyle.Format = "dd.MM.yyyy";

            while (reader.Read())
            {
                object[] row = new object[columnCount];
                row[0] = reader.GetValue(reader.GetOrdinal("Inventory")); // Valoarea pentru coloana "TableName"

                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string columnName = reader.GetName(i);
                    if (columnName != "ID" && columnName != "Inventory")
                    {
                        int columnIndex = dataGridView1.Columns[columnName].Index;
                        row[columnIndex] = reader.GetValue(i);
                    }
                }

                dataGridView1.Rows.Add(row);
            }

            reader.Close();
            conn.Close();

            // Setarea proprietății AllowUserToAddRows la false
            dataGridView1.AllowUserToAddRows = false;

            // Setarea proprietății RowHeadersVisible la false
            dataGridView1.RowHeadersVisible = false;

            // Setarea proprietății AutoSizeColumnsMode la None pentru a permite dimensiunilor
            // personalizate ale coloanelor
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;

            // Setarea dimensiunilor coloanelor pentru a se potrivi conținutului
            dataGridView1.AutoResizeColumns();

            // Activarea barei de derulare orizontală și verticală
            dataGridView1.ScrollBars = ScrollBars.Both;
        }
    }
}
