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

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            SqlConnection connection = ConnectUserStock.GetStockSqlcon();
            connection.Open();
            string query = "SELECT Item FROM Home";
            SqlCommand command = new SqlCommand(query, connection);
            SqlDataReader reader = command.ExecuteReader();

            // Adăugați un rând nou în DataGridView
            int rowIndex = dataGridView1.Rows.Add();

            // Creați o variabilă pentru a aduna datele din baza de date
            List<string> databaseValues = new List<string>();

            // Obțineți referința la celula ComboBox pentru noul rând
            DataGridViewComboBoxCell comboBoxCell1 = (DataGridViewComboBoxCell)dataGridView1.Rows[rowIndex].Cells["Item"];

            while (reader.Read())
            {
                // Adăugați datele în lista de elemente a ComboBox-ului
                comboBoxCell1.Items.Add(reader["Item"].ToString());

                // Adăugați datele în listă
                databaseValues.Add(reader["Item"].ToString());
            }

            reader.Close();
            connection.Close();

        }


        private void buttonSave_Click(object sender, EventArgs e)
        {
            // Parcurgem fiecare rând din DataGridView și salvăm valorile în baza de date
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Obținem valorile din rândul curent
                string inventory = row.Cells["inventory"].Value.ToString();
                string item = row.Cells["item"].Value.ToString();
                string um = row.Cells["um"].Value.ToString();
                int qty = int.Parse(row.Cells["qty"].Value.ToString());

                // Salvăm valorile în baza de date
                // ...

                // Actualizăm valoarea din tabelul SQL (qty)
                // ...
            }
        }
    }
}
