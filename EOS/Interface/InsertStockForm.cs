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
    public partial class InsertStockForm : Form
    {
        public InsertStockForm()
        {
            InitializeComponent();
            comboBox2.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            int id = CountUserStockId.B() + 1;
            string insertUnits = comboBox2.SelectedItem.ToString();
            string insertInventory = comboBox1.SelectedItem.ToString();
            string tableName = GetUsername.Userloggedname;
            //create instanace of database connection
            string query1 = $"INSERT INTO [{tableName}] (ID, Inventory, Item, " +
                $"UM, Qty, Price, Date) VALUES (@ID, @Inventory, @Item," +
                $" @UM, @Qty, @Price, @Date)";
            SqlConnection sqlcon = ConnectUserStock.GetStockSqlcon();
            {
                SqlCommand command = new SqlCommand(query1, sqlcon);
                {
                    // set parameter values
                    command.Parameters.AddWithValue("@ID", id);
                    command.Parameters.AddWithValue("@Inventory", insertInventory);
                    command.Parameters.AddWithValue("@Item",insertNametxtbox.Text);
                    command.Parameters.AddWithValue("@UM", insertUnits);
                    command.Parameters.AddWithValue("@Qty", insertQtytxtbox.Text);
                    command.Parameters.AddWithValue("@Price", insertPricetxtbox.Text);
                    DateTime selectedDate = insertDatepicker.Value.Date;
                    SqlParameter param = 
                        new SqlParameter("@Date", SqlDbType.Date);
                    param.Value = selectedDate;
                    command.Parameters.Add(param);

                    // open connection and execute query
                    sqlcon.Open();
                    command.ExecuteNonQuery();
                }
            }
            MessageBox.Show("Was succesfuly enter!");
        }
    }
}
