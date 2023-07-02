using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Forms;

namespace EOS
{
    public partial class EditStockForm : Form
    {
        public EditStockForm()
        {
            InitializeComponent();
        }

        private void EditStockForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataError += DataGridView1_DataError;
        }

        private string selectedValue;

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            SqlConnection connection = ConnectUserStock.GetStockSqlcon();
            connection.Open();
            string querytbl = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
            SqlCommand tblcommand = new SqlCommand(querytbl, connection);
            SqlDataReader tblread = tblcommand.ExecuteReader();

            // Adăugați un nou rând în DataGridView
            int rowIndex = dataGridView1.Rows.Add();

            // Lista pentru a stoca numele tabelor
            List<string> tableNames = new List<string>();

            while (tblread.Read())
            {
                string tableName = tblread["TABLE_NAME"].ToString();
                tableNames.Add(tableName); // Adăugați numele tabelului la lista

                // Adăugați un nou ComboBox pentru fiecare rând din DataGridView
                DataGridViewComboBoxCell inventoryComboBoxCell = new DataGridViewComboBoxCell();

                // Adăugați numele tabelului în lista ComboBox-ului
                inventoryComboBoxCell.Items.AddRange(tableNames.ToArray());

                // Atribuiți obiectul DataGridViewComboBoxCell la celula corespunzătoare din coloana "Inventory"
                dataGridView1.Rows[rowIndex].Cells["Inventory"] = inventoryComboBoxCell;
            }

            tblread.Close();
            connection.Close();
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Parcurgem fiecare rând din DataGridView și salvăm valorile în baza de date
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Obținem valorile din rândul curent
                string inventory = row.Cells["Inventory"].Value.ToString();
                string item = row.Cells["Item"].Value.ToString();
                int qty = int.Parse(row.Cells["Qty"].Value.ToString());

                // Salvăm valorile în baza de date
                // ...

                // Actualizăm valoarea din tabelul SQL (qty)
                // ...
            }
        }

        private void dataGridView1_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Verificați dacă modificarea a avut loc într-o coloană validă
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Verificați dacă rândul există
                if (dataGridView1.Rows[e.RowIndex] is DataGridViewRow row)
                {
                    // Verificați dacă celula există
                    if (row.Cells[e.ColumnIndex] is DataGridViewCell cell)
                    {
                        // Verificați dacă modificarea a avut loc în coloana "Inventory"
                        if (cell.OwningColumn.Name == "Inventory")
                        {
                            string selectedValue = cell.Value?.ToString();

                            if (!string.IsNullOrEmpty(selectedValue))
                            {
                                SqlConnection connection = ConnectUserStock.GetStockSqlcon();
                                connection.Open();

                                string query = $"SELECT Item FROM {selectedValue}";
                                SqlCommand command = new SqlCommand(query, connection);
                                SqlDataReader reader = command.ExecuteReader();

                                // Obțineți referința la celula ComboBox pentru rândul curent în coloana "Item"
                                DataGridViewComboBoxCell itemComboBoxCell = (DataGridViewComboBoxCell)dataGridView1.Rows[e.RowIndex].Cells["Item"];

                                // Goliți lista de elemente din ComboBox-ul pentru coloana "Item"
                                itemComboBoxCell.Items.Clear();

                                while (reader.Read())
                                {
                                    // Adăugați datele în lista de elemente a ComboBox-ului pentru coloana "Item"
                                    itemComboBoxCell.Items.Add(reader["Item"].ToString());
                                }

                                reader.Close();
                                connection.Close();
                            }
                        }
                        // Verificați dacă modificarea a avut loc în coloana "Item"
                        else if (cell.OwningColumn.Name == "Item")
                        {
                            string selectedInventory = row.Cells["Inventory"].Value?.ToString();
                            string selectedItem = cell.Value?.ToString();

                            if (!string.IsNullOrEmpty(selectedInventory) && !string.IsNullOrEmpty(selectedItem))
                            {
                                SqlConnection connection = ConnectUserStock.GetStockSqlcon();
                                connection.Open();

                                string query = $"SELECT UM, Price FROM {selectedInventory} WHERE Item = @selectedItem";
                                SqlCommand command = new SqlCommand(query, connection);
                                command.Parameters.AddWithValue("@selectedItem", selectedItem);
                                SqlDataReader reader = command.ExecuteReader();

                                if (reader.Read())
                                {
                                    // Obțineți referința la celulele UM și Price pentru rândul curent
                                    DataGridViewCell umCell = dataGridView1.Rows[e.RowIndex].Cells["UM"];
                                    DataGridViewCell priceCell = dataGridView1.Rows[e.RowIndex].Cells["Price"];

                                    // Actualizați valorile UM și Price pentru rândul curent
                                    umCell.Value = reader["UM"].ToString();
                                    priceCell.Value = reader["Price"].ToString();
                                }

                                reader.Close();
                                connection.Close();
                            }
                        }
                    }
                }
            }
        }
        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            // Acest cod previne afișarea mesajului de eroare într-un dialog implicit
            e.ThrowException = false;
        }

    }
}
