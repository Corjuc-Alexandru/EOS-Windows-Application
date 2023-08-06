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

            // Inițializarea clasei CellValueChangeHandler și asocierea evenimentului CellValueChanged
            cellValueChangeHandler = new CellValueChangeHandler(dataGridView1, "totalPrice");

        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Create an instance of the AddButtonHandler class
            AddButtonHandler addButtonHandler = new AddButtonHandler(dataGridView1);

            // Call the HandleAddButton method to handle the "Add" button click event
            addButtonHandler.HandleAddButton();
            
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {

                // Create an instance of the UpdateDatabase class
                UpdateDatabase updateDatabase = new UpdateDatabase();

                // Call the UpdateDataFromDataGridView method and pass the dataGridView1 control
                updateDatabase.UpdateDataFromDataGridView(dataGridView1);

        }

        private void DataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {

            // Acest cod previne afișarea mesajului de eroare într-un dialog implicit
            e.ThrowException = false;
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
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
