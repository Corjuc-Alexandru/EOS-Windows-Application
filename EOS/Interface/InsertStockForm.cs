﻿using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace EOS
{
    public partial class InsertStockForm : Form
    {
        public InsertStockForm()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void insertButton_Click(object sender, EventArgs e)
        {
            string insertUnits = comboBox2.SelectedItem.ToString();
            string tableName = comboBox1.SelectedItem.ToString();
            string price = insertPricetxtbox.Text;
            decimal valueprice = decimal.Parse(price);

            string query1 = 
                $"INSERT INTO [{tableName}] (Item, UM, Qty, Price, Date) " +
                $"VALUES (@Item, @UM, @Qty, @Price, @Date)";

            SqlConnection sqlcon = ConnectUserStock.GetStockSqlcon();

            using (SqlCommand command = new SqlCommand(query1, sqlcon))
            {
                command.Parameters.AddWithValue("@Item", insertNametxtbox.Text);
                command.Parameters.AddWithValue("@UM", insertUnits);
                command.Parameters.AddWithValue("@Qty", insertQtytxtbox.Text);
                command.Parameters.AddWithValue("@Price", valueprice);
                DateTime selectedDate = insertDatepicker.Value.Date;
                SqlParameter param = new SqlParameter("@Date", SqlDbType.Date);
                param.Value = selectedDate;
                command.Parameters.Add(param);
                sqlcon.Open();
                command.ExecuteNonQuery();
            }

            MessageBox.Show("Was successfully entered!");
            insertNametxtbox.Clear();
            insertQtytxtbox.Clear();
            insertPricetxtbox.Clear();
            insertDatepicker.Refresh();
        }
    }
}
