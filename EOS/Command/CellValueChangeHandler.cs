using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EOS
{
    public class CellValueChangeHandler
    {
        private DataGridView dataGridView;
        private string totalPriceColumnName;

        public CellValueChangeHandler(DataGridView dataGridView, string totalPriceColumnName)
        {
            this.dataGridView = dataGridView;
            this.totalPriceColumnName = totalPriceColumnName;
            this.dataGridView.CellValueChanged += DataGridView_CellValueChanged;
        }

        private void DataGridView_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                DataGridViewRow row = dataGridView.Rows[e.RowIndex];
                DataGridViewCell cell = row.Cells[e.ColumnIndex];

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

                        DataGridViewComboBoxCell itemComboBoxCell = (DataGridViewComboBoxCell)dataGridView.Rows[e.RowIndex].Cells["Item"];
                        itemComboBoxCell.Items.Clear();

                        while (reader.Read())
                        {
                            itemComboBoxCell.Items.Add(reader["Item"].ToString());
                        }

                        reader.Close();
                        connection.Close();
                    }
                }
                else if (cell.OwningColumn.Name == "Item" || cell.OwningColumn.Name == "Qty")
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
                        string umValue = addReader["UM"].ToString();
                        string qtyIn = addReader["Qty"].ToString();
                        decimal price = Convert.ToDecimal(addReader["Price"]);

                        dataGridView.Rows[e.RowIndex].Cells["UM"].Value = umValue;
                        dataGridView.Rows[e.RowIndex].Cells["qtyStock"].Value = qtyIn;
                        dataGridView.Rows[e.RowIndex].Cells["Price"].Value = price;
                    }

                    addReader.Close();
                    connection1.Close();

                    if (row.Cells["Qty"].Value != null && !string.IsNullOrEmpty(row.Cells["Qty"].Value.ToString()))
                    {
                        qtyCompleted = true;
                    }

                    if (!string.IsNullOrEmpty(selectedInventory) && !string.IsNullOrEmpty(selectedItem) && qtyCompleted)
                    {
                        if (qtyCompleted)
                        {
                            if (int.TryParse(row.Cells["Qty"].Value?.ToString(), out int qty) &&
                                decimal.TryParse(row.Cells["Price"].Value?.ToString(), out decimal price))
                            {
                                decimal totalPrice = qty * price;
                                row.Cells[totalPriceColumnName].Value = totalPrice.ToString();
                            }
                        }
                    }
                }
            }
        }
    }
}

