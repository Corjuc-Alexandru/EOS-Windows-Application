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
            dataGridView1.CellValueChanged += dataGridView1_CellValueChanged; // Adăugați această linie pentru asocierea evenimentului
        }


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
                        if (cell.OwningColumn.Name == "Item" || cell.OwningColumn.Name == "Qty")
                        {
                            string selectedInventory = row.Cells["Inventory"].Value?.ToString();
                            string selectedItem = row.Cells["Item"].Value?.ToString();
                            bool qtyCompleted = false;

                            SqlConnection connection1 = ConnectUserStock.GetStockSqlcon();
                            connection1.Open();
                            string addvalues = $"Select UM, Qty, Price FROM {selectedInventory} WHERE Item = @selectedItem";
                            SqlCommand addcommand = new SqlCommand(addvalues, connection1);
                            addcommand.Parameters.AddWithValue("@selectedItem", selectedItem);
                            SqlDataReader addReader = addcommand.ExecuteReader();

                            if (addReader.Read())
                            {
                                // Obțineți UM din baza de date
                                string umValue = addReader["UM"].ToString();
                                string qtyIn = addReader["Qty"].ToString();
                                decimal price = Convert.ToDecimal(addReader["Price"]);

                                // Adăugați UM în lista de elemente a ComboBox-ului pentru coloana "UM"
                                dataGridView1.Rows[e.RowIndex].Cells["UM"].Value = umValue;
                                dataGridView1.Rows[e.RowIndex].Cells["qtyStock"].Value = qtyIn;
                                dataGridView1.Rows[e.RowIndex].Cells["Price"].Value = price;



                            }
                            addReader.Close();
                            connection1.Close();
                            // Verificați dacă coloana "Qty" a fost completată
                            if (row.Cells["Qty"].Value != null && !string.IsNullOrEmpty(row.Cells["Qty"].Value.ToString()))
                            {
                                qtyCompleted = true;
                            }

                            if (!string.IsNullOrEmpty(selectedInventory) && !string.IsNullOrEmpty(selectedItem) && qtyCompleted)
                            {

                                // Verificați dacă coloana "Qty" a fost completată
                                if (qtyCompleted)
                                {
                                    // Obțineți referința la celula totalPrice pentru rândul curent
                                    DataGridViewCell totalPriceCell = dataGridView1.Rows[e.RowIndex].Cells["totalPrice"];
                                      
                                    // Setați valoarea totalului în coloana "totalPrice"
                                    totalPriceCell.Value = totalPrice.ToString();
        
                                    // Verificați dacă coloana "Qty" este completată și are o valoare numerică
                                    if (int.TryParse(row.Cells["Qty"].Value.ToString(), 
                                        out int qty) && decimal.TryParse(row.Cells["Price"].Value.
                                        ToString(),out decimal price1))
                                    {
                                        // Calculați totalul
                                        decimal totalPrice = qty * price1;
                                      
                                        // Setează valoarea totalului în coloana "totalPrice"
                                        totalPriceCell.Value = totalPrice.ToString();
                                    }
                                }
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

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            // Verificați dacă există cel puțin un rând în DataGridView
            if (dataGridView1.Rows.Count > 0)
            {
                // Verificați dacă rândul curent este valid
                if (dataGridView1.CurrentRow != null)
                {
                    // Obțineți rândul curent
                    DataGridViewRow currentRow = dataGridView1.CurrentRow;

                    // Eliminați rândul curent din DataGridView
                    dataGridView1.Rows.Remove(currentRow);
                }
                else
                {
                    MessageBox.Show("Selectați un rând pentru a șterge.", "Atenție",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
    }
}
