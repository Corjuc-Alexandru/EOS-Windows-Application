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
        private CellValueChangeHandler cellValueChangeHandler;

        public EditStockForm()
        {
            InitializeComponent();
        }

        private void EditStockForm_Load(object sender, EventArgs e)
        {
            dataGridView1.DataError += DataGridView1_DataError;

            cellValueChangeHandler = new CellValueChangeHandler(dataGridView1, "totalPrice");

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Create an instance of the AddButtonHandler class
            AddButtonHandler addButtonHandler = new AddButtonHandler(dataGridView1);

            addButtonHandler.HandleAddButton();
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

                // Create an instance of the UpdateDatabase class
                UpdateDatabase updateDatabase = new UpdateDatabase();

                updateDatabase.UpdateDataFromDataGridView(dataGridView1);

        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            e.ThrowException = false;
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            // Check rows in datagridview
            if (dataGridView1.Rows.Count > 0)
            {
                if (dataGridView1.CurrentRow != null)
                {

                    DataGridViewRow currentRow = dataGridView1.CurrentRow;

                    dataGridView1.Rows.Remove(currentRow);
                }
                else
                {
                    MessageBox.Show("Select a row to delete.", "Warning",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }

        }
    }
}
