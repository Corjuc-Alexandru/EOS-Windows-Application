using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EOS
{
    public class AddButtonHandler
    {
        private DataGridView dataGridView;

        public AddButtonHandler(DataGridView dataGridView)
        {
            this.dataGridView = dataGridView;
        }

        public void HandleAddButton()
        {
            SqlConnection connection = ConnectUserStock.GetStockSqlcon();
            connection.Open();
            string querytbl = "SELECT TABLE_NAME FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE = 'BASE TABLE'";
            SqlCommand tblcommand = new SqlCommand(querytbl, connection);
            SqlDataReader tblread = tblcommand.ExecuteReader();

            // Add a new row in the DataGridView
            int rowIndex = dataGridView.Rows.Add();

            // List to store table names
            List<string> tableNames = new List<string>();

            while (tblread.Read())
            {
                string tableName = tblread["TABLE_NAME"].ToString();
                tableNames.Add(tableName); // Add the table name to the list

                // Add a new ComboBox for each row in the DataGridView
                DataGridViewComboBoxCell inventoryComboBoxCell = new DataGridViewComboBoxCell();

                // Add the table names to the ComboBox list
                inventoryComboBoxCell.Items.AddRange(tableNames.ToArray());

                // Assign the DataGridViewComboBoxCell object to the corresponding cell in the "Inventory" column
                dataGridView.Rows[rowIndex].Cells["Inventory"] = inventoryComboBoxCell;
            }

            tblread.Close();
            connection.Close();
        }
    }
}


