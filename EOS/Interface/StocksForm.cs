using System;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;
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
                dataGridView1.Columns.Clear();
            }

            else if (selectedOption == "Home")
            {
                Inventory inventory = new Inventory();
                sqlQuery = inventory.Home();
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
            dataGridView1.Columns.Add("Inventory", "Inventory");

            for (int i = 0; i < reader.FieldCount; i++)
            {
                string columnName = reader.GetName(i);
                if (columnName != "Inventory" && columnName != "Inventory")
                {
                    dataGridView1.Columns.Add(columnName, columnName);
                }
            }

            int columnCount = dataGridView1.Columns.Count;
            DataGridViewColumn dateColumn = dataGridView1.Columns["Date"];
            dateColumn.DefaultCellStyle.Format = "dd.MM.yyyy";

            while (reader.Read())
            {
                object[] row = new object[columnCount];
                row[0] = reader.GetValue(reader.GetOrdinal("Inventory"));
                for (int i = 0; i < reader.FieldCount; i++)
                {
                    string columnName = reader.GetName(i);
                    if (columnName != "Inventory" && columnName != "Inventory")
                    {
                        int columnIndex = dataGridView1.Columns[columnName].Index;
                        row[columnIndex] = reader.GetValue(i);
                    }
                }

                dataGridView1.DataSource = null;
                dataGridView1.Rows.Add(row);
            }

            reader.Close();
            conn.Close();

            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.RowHeadersVisible = false;

            if (dataGridView1.Columns != null && dataGridView1.Columns.Contains("ID"))
            {
                dataGridView1.Columns.Remove("ID");
            }

            if (dataGridView1.Columns.Contains("ID"))
            {
                dataGridView1.Columns.Remove("ID");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string search = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(search))
            {
                comboBox1_SelectedIndexChanged(sender, e);
            }

            else
            {
                string selectedOption = comboBox1.SelectedItem.ToString();
                string sqlQuery = string.Empty;

                if (selectedOption == "All")
                {
                    sqlQuery = $"SELECT *, 'Home' AS Inventory FROM Home WHERE Item" +
                        $" LIKE @search ESCAPE '\\'" +
                        $"UNION ALL SELECT *, 'Work' AS Inventory FROM Work WHERE Item" +
                        $" LIKE @search ESCAPE '\\'";
                }

                else if (selectedOption == "Home")
                {
                    Inventory inventory = new Inventory();
                    sqlQuery = inventory.Home();
                    sqlQuery += " WHERE Item LIKE @search ESCAPE '\\'";
                }

                else if (selectedOption == "Work")
                {
                    Inventory inventory = new Inventory();
                    sqlQuery = inventory.Work();
                    sqlQuery += " WHERE Item LIKE @search ESCAPE '\\'";
                }

                dataGridView1.Columns.Clear();

                using (SqlConnection connection = ConnectUserStock.GetStockSqlcon())
                {
                    SqlCommand command = new SqlCommand(sqlQuery, connection);
                    command.Parameters.AddWithValue("@search", "%" +
                        search.Replace("[", "[[]").Replace("%", "[%]")
                        .Replace("_", "[_]").Replace("\\", "\\\\")
                        .Replace("'", "''") + "%");
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();
                    DataTable filteredDataTable = new DataTable();

                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);
                        filteredDataTable.Columns.Add(columnName, reader.GetFieldType(i));
                    }

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

                    foreach (DataColumn column in filteredDataTable.Columns)
                    {
                        if (column.ColumnName != "Inventory")
                        {
                            dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);
                        }
                    }

                    if (filteredDataTable.Columns.Contains("Inventory"))
                    {
                        DataGridViewTextBoxColumn inventoryColumn = 
                            new DataGridViewTextBoxColumn();
                        inventoryColumn.HeaderText = "Inventory";
                        inventoryColumn.Name = "Inventory";
                        dataGridView1.Columns.Insert(0, inventoryColumn);
                    }

                    foreach (DataRow row in filteredDataTable.Rows)
                    {
                        object[] rowData = new object[dataGridView1.Columns.Count];

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
                                    int columnIndex = 
                                        dataGridView1.Columns[column.ColumnName].Index;
                                    rowData[columnIndex] = row[column];
                                }
                            }
                        }

                        dataGridView1.Rows.Add(rowData);
                        DataGridViewColumn dateColumn = dataGridView1.Columns["Date"];
                        dateColumn.DefaultCellStyle.Format = "dd.MM.yyyy";

                        if (dataGridView1.Columns != null && dataGridView1.Columns.Contains("ID"))
                        {
                            dataGridView1.Columns.Remove("ID");
                        }

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
                e.Handled = true;
                button1.PerformClick();
            }
        }
    }
}
