using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Collections.Generic;
using EOS.Command;
using System.Windows.Shapes;

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
                dataGridView1.Columns.Clear();
            }
            else if (selectedOption == "Home")
            {
                Inventory inventory = new Inventory();
                sqlQuery = inventory.Home();
                // Ștergeți coloanele existente din DataGridView
                dataGridView1.Columns.Clear();
            }
            else if (selectedOption == "Work")
            {
                Inventory inventory = new Inventory();
                sqlQuery = inventory.Work();
                dataGridView1.Columns.Clear();
            }
            SqlConnection conn = ConnectUserStock.GetStockSqlcon();
            SqlCommand command = new SqlCommand(sqlQuery, conn);
            conn.Open();
            SqlDataReader reader = command.ExecuteReader();

            // Adăugarea coloanei "TableName" la începutul dataGridView1
            dataGridView1.Columns.Add("Inventory", "Inventory");

            // Adăugarea coloanelor din primul tabel
            for (int i = 0; i < reader.FieldCount; i++)
            {
                string columnName = reader.GetName(i);
                if (columnName != "Inventory" && columnName != "Inventory")
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
                    if (columnName != "Inventory" && columnName != "Inventory")
                    {
                        int columnIndex = dataGridView1.Columns[columnName].Index;
                        row[columnIndex] = reader.GetValue(i);
                    }
                }
                // Anulează legarea datelor
                dataGridView1.DataSource = null;
                dataGridView1.Rows.Add(row);
                // Reface legarea datelor
            }

            reader.Close();
            conn.Close();

            // Setarea proprietății AllowUserToAddRows la false
            dataGridView1.AllowUserToAddRows = false;

            // Setarea proprietății RowHeadersVisible la false
            dataGridView1.RowHeadersVisible = false;

            if (dataGridView1.Columns != null && dataGridView1.Columns.Contains("ID"))
            {
                dataGridView1.Columns.Remove("ID");
            }
            // Eliminarea coloanei "ID" din dataGridView1 (dacă există)
            if (dataGridView1.Columns.Contains("ID"))
            {
                dataGridView1.Columns.Remove("ID");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cuvantCautat = textBox1.Text.Trim();

            // Verifică dacă TextBox este gol
            if (string.IsNullOrEmpty(cuvantCautat))
            {
                // Dacă TextBox este gol, afișează toate înregistrările din DataGridView
                comboBox1_SelectedIndexChanged(sender, e);
            }
            else
            {
                string selectedOption = comboBox1.SelectedItem.ToString();
                string sqlQuery = string.Empty;

                if (selectedOption == "All")
                {
                    sqlQuery = $"SELECT *, 'Home' AS Inventory FROM Home WHERE Item" +
                        $" LIKE @cuvantCautat ESCAPE '\\'" +
                        $"UNION ALL SELECT *, 'Work' AS Inventory FROM Work WHERE Item" +
                        $" LIKE @cuvantCautat ESCAPE '\\'";
                }
                else if (selectedOption == "Home")
                {
                    Inventory inventory = new Inventory();
                    sqlQuery = inventory.Home();
                    // Adaugă clauza WHERE pentru a căuta înregistrările care conțin cuvântul căutat în coloana "Item"
                    sqlQuery += " WHERE Item LIKE @cuvantCautat ESCAPE '\\'";

                }
                else if (selectedOption == "Work")
                {
                    Inventory inventory = new Inventory();
                    sqlQuery = inventory.Work();
                    // Adaugă clauza WHERE pentru a căuta înregistrările care conțin cuvântul căutat în coloana "Item"
                    sqlQuery += " WHERE Item LIKE @cuvantCautat ESCAPE '\\'";

                }
                // Ștergeți coloanele existente din DataGridView
                dataGridView1.Columns.Clear();

                using (SqlConnection connection = ConnectUserStock.GetStockSqlcon())
                {
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    command.Parameters.AddWithValue("@cuvantCautat", "%" +
                        cuvantCautat.Replace("[", "[[]").Replace("%", "[%]")
                        .Replace("_", "[_]").Replace("\\", "\\\\")
                        .Replace("'", "''") + "%");

                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    // Crearea unui nou DataTable pentru a păstra rezultatele căutării
                    DataTable filteredDataTable = new DataTable();

                    // Copierea structurii coloanelor din reader în filteredDataTable
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);
                        filteredDataTable.Columns.Add(columnName, reader.GetFieldType(i));
                    }

                    // Adăugarea rândurilor care corespund criteriului de căutare în filteredDataTable
                    while (reader.Read())
                    {
                        DataRow newRow = filteredDataTable.NewRow();

                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            string columnName = reader.GetName(i);
                            newRow[columnName] = reader.GetValue(i);
                        }

                        filteredDataTable.Rows.Add(newRow);
                    }

                    reader.Close();
                    connection.Close();

                    // Rearanjarea coloanelor în dataGridView1
                    foreach (DataColumn column in filteredDataTable.Columns)
                    {
                        if (column.ColumnName != "Inventory")
                        {
                            dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);
                        }
                    }

                    // Adăugarea coloanei "Inventory" pe prima poziție în dataGridView1
                    if (filteredDataTable.Columns.Contains("Inventory"))
                    {
                        DataGridViewTextBoxColumn inventoryColumn = new DataGridViewTextBoxColumn();
                        inventoryColumn.HeaderText = "Inventory";
                        inventoryColumn.Name = "Inventory";
                        dataGridView1.Columns.Insert(0, inventoryColumn);
                    }

                    // Adăugarea rândurilor în dataGridView1
                    foreach (DataRow row in filteredDataTable.Rows)
                    {
                        // Creează un nou obiect object[] pentru valorile dorite în ordinea corectă a coloanelor
                        object[] rowData = new object[dataGridView1.Columns.Count];

                        // Adaugă valorile în obiectul rowData în ordinea corectă a coloanelor
                        for (int i = 0; i < filteredDataTable.Columns.Count; i++)
                        {
                            DataColumn column = filteredDataTable.Columns[i];

                            if (column.ColumnName == "Inventory")
                            {
                                rowData[0] = row[column];
                            }
                            else
                            {
                                if (dataGridView1.Columns[column.ColumnName] != null)
                                {
                                    int columnIndex = dataGridView1.Columns[column.ColumnName].Index;
                                    rowData[columnIndex] = row[column];
                                }
                            }
                        }

                        dataGridView1.Rows.Add(rowData);
                        // Obțineți referința coloanei "Date" din dataGridView1
                        DataGridViewColumn dateColumn = dataGridView1.Columns["Date"];

                        // Setarea opțiunii de formatare pentru a afișa doar data
                        dateColumn.DefaultCellStyle.Format = "dd.MM.yyyy";
                        if (dataGridView1.Columns != null && dataGridView1.Columns.Contains("ID"))
                        {
                            dataGridView1.Columns.Remove("ID");
                        }
                        // Eliminarea coloanei "ID" din dataGridView1 (dacă există)
                        if (dataGridView1.Columns.Contains("ID"))
                        {
                            dataGridView1.Columns.Remove("ID");
                        }
                    }
                }
            }

            textBox1.Clear();
        }
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; // Opriți sunetul caracterului Enter

                button1.PerformClick(); // Declanșați evenimentul Click al butonului button1

            }
        }

    }
}
