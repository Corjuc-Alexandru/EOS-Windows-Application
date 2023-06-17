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
    public partial class EditStockForm : Form
    {

        public EditStockForm()
        {
            InitializeComponent();
        }

        private string select;


        private void EditStockForm_Load(object sender, EventArgs e)
        {

            string tablename = "Home";
            SqlConnection connection = ConnectUserStock.GetStockSqlcon();
            connection.Open();
            string query = $"SELECT * FROM {tablename}";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader1 = command.ExecuteReader();

            // Crearea obiectului DataGridViewComboBoxColumn și adăugarea valorilor
            DataGridViewComboBoxColumn comboBoxColumn1 = 
                new DataGridViewComboBoxColumn();
            comboBoxColumn1.Name = "Inventory";
            while (reader1.Read())
            {
                string value = reader1[tablename].ToString();
                comboBoxColumn1.Items.Add(value);
            }
            // Adăugarea obiectului DataGridViewComboBoxColumn la DataGridView
            dataGridView1.Columns.Add(comboBoxColumn1);
            reader1.Close();
            if (comboBoxColumn1.Items.Count > 0)
            {
                DataGridViewRow firstRow = dataGridView1.Rows[0];
                firstRow.Cells["Inventory"].Value = comboBoxColumn1.Items[0];
            }

            //column2
            string columnName2 = "Item";
            string query2 = $"SELECT DISTINCT {columnName2} FROM {tablename}" +
                $" WHERE Inventory = '{select}'";
            SqlCommand command2 = new SqlCommand(query2, connection);
            SqlDataReader reader2 = command2.ExecuteReader();

            // Crearea obiectului DataGridViewComboBoxColumn și adăugarea valorilor
            DataGridViewComboBoxColumn comboBoxColumn2 = 
                new DataGridViewComboBoxColumn();
            comboBoxColumn2.Name = "Item";
            while (reader2.Read())
            {
                string value2 = reader2[columnName2].ToString();
                comboBoxColumn2.Items.Add(value2);
            }

            // Adăugarea obiectului DataGridViewComboBoxColumn la DataGridView
            dataGridView1.Columns.Add(comboBoxColumn2);
            reader2.Close();
            // Închiderea conexiunii și eliberarea resurselor

            connection.Close();
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged;
        }

        private void dataGridView1_CellValueChanged(object sender, 
            DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Inventory"].Index)
            {

                ResetSecondComboBoxValues();
            }

            if (e.ColumnIndex == dataGridView1.Columns["Inventory"].Index 
                && e.RowIndex >= 0)
            {
                // Obțineți valoarea selectată din combobox-ul column 1
                DataGridViewComboBoxCell comboBoxCell1 = 
                    dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex] 
                    as DataGridViewComboBoxCell;
                string selectedValue = comboBoxCell1.Value?.ToString();

                if (!string.IsNullOrEmpty(selectedValue))
                {
                    // Obțineți combobox-ul column 2 din rândul curent
                    DataGridViewComboBoxCell comboBoxCell2 = 
                        dataGridView1.Rows[e.RowIndex].Cells["Item"] 
                        as DataGridViewComboBoxCell;

                    // Resetați valorile combobox-ului column 2
                    comboBoxCell2.Items.Clear();

                    // Adăugați valorile corespunzătoare din baza de date
                    // în comboBoxCell2.Items
                    string tablename = GetUsername.Userloggedname;
                    SqlConnection connection = ConnectUserStock.GetStockSqlcon();
                    connection.Open();

                    string columnName2 = "Item";
                    string query2 = $"SELECT DISTINCT {columnName2} FROM {tablename} " +
                        $"WHERE Inventory = @selectedValue";
                    SqlCommand command2 = new SqlCommand(query2, connection);
                    command2.Parameters.AddWithValue("@selectedValue", selectedValue);
                    SqlDataReader reader2 = command2.ExecuteReader();

                    while (reader2.Read())
                    {
                        string value2 = reader2[columnName2].ToString();
                        comboBoxCell2.Items.Add(value2);
                    }

                    reader2.Close();

                    // Închiderea conexiunii și eliberarea resurselor
                    connection.Close();
                }
            }

        }

        private void ResetSecondComboBoxValues()
        {
            string selectedValue = 
                dataGridView1.CurrentRow.Cells["Inventory"].Value.ToString();
            DataGridViewComboBoxColumn comboBoxColumn2 = 
                dataGridView1.Columns["Item"] as DataGridViewComboBoxColumn;
            comboBoxColumn2.Items.Clear();

            // Populați comboBoxColumn2 cu valorile actualizate în funcție de
            // selectedValue
            // Adăugați valorile corespunzătoare din baza de date în
            // comboBoxCell2.Items
            string tablename = GetUsername.Userloggedname;
            SqlConnection connection = ConnectUserStock.GetStockSqlcon();
            connection.Open();

            string columnName2 = "Item";
            string query2 = $"SELECT DISTINCT {columnName2} FROM {tablename} " +
                $"WHERE Inventory = @selectedValue";
            SqlCommand command2 = new SqlCommand(query2, connection);
            command2.Parameters.AddWithValue("@selectedValue", selectedValue);
            SqlDataReader reader2 = command2.ExecuteReader();

            while (reader2.Read())
            {
                string value2 = reader2[columnName2].ToString();
                comboBoxColumn2.Items.Add(value2);
            }

            reader2.Close();

            // Închiderea conexiunii și eliberarea resurselor
            connection.Close();
            // Adăugați noile valori în comboBoxColumn2.Items
        }
    }
}
