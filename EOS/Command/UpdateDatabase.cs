using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EOS
{
    internal class UpdateDatabase
    {
        public void UpdateDataFromDataGridView(DataGridView dataGridView)
        {
            try
            {
                using (SqlConnection conn = ConnectUserStock.GetStockSqlcon())
                {
                    conn.Open();

                    foreach (DataGridViewRow row in dataGridView.Rows)
                    {
                        // Get the item name from the ComboBox column
                        string itemName = row.Cells["Item"].Value.ToString();

                        // Get the new quantity from the Quantity column
                        int newQuantity = Convert.ToInt32(row.Cells["Qty"].Value);

                        // Get the table name from the "Inventory" column
                        string tableName = row.Cells["Inventory"].Value.ToString();

                        // Prepare your SQL update query to subtract the new quantity
                        // from the existing quantity
                        string updateQuery = 
                            $"UPDATE {tableName} SET Qty = Qty - @Qty WHERE Item = '{itemName}'";

                        using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                        {
                            // Set the parameter value
                            cmd.Parameters.AddWithValue("@Qty", newQuantity);

                            // Execute the update query
                            cmd.ExecuteNonQuery();
                        }
                    }

                    MessageBox.Show("Database updated successfully!", 
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

            catch (Exception ex)
            {
                // Handle any exceptions that might occur during the database update
                MessageBox.Show("Error updating database: " + ex.Message, 
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}


