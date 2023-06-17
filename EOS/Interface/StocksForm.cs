using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using EOS.Command;

namespace EOS
{
    public partial class StocksForm : Form
    {
        public StocksForm()
        {
            InitializeComponent();
        }

        private void StocksForm_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedOption = comboBox1.SelectedItem.ToString();
            string sqlQuery = string.Empty;

            if (selectedOption == "All")
            {
                Inventory inventory = new Inventory();
                sqlQuery = inventory.All();
            }
            else if (selectedOption == "Home")
            {
                Inventory inventory = new Inventory();
                sqlQuery = inventory.Home();
            }
            else if (selectedOption == "Work")
            {
                Inventory inventory = new Inventory();
                sqlQuery = inventory.Work();
            }

            // Ștergeți coloanele existente din DataGridView
            dataGridView1.Columns.Clear();

            // Utilizați sqlQuery pentru a accesa baza de date și afișa rezultatele în DataGridView

            SqlConnection conn = ConnectUserStock.GetStockSqlcon();
            SqlCommand command = new SqlCommand(sqlQuery, conn);
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

        }
    }
}
