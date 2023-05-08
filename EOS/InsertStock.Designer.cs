namespace EOS
{
    partial class InsertStock
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.insertNametxtbox = new System.Windows.Forms.TextBox();
            this.insertQtytxtbox = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.insertPricetxtbox = new System.Windows.Forms.TextBox();
            this.insertButton = new System.Windows.Forms.Button();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.insertDatepicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // comboBox2
            // 
            this.comboBox2.DisplayMember = "PCS";
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "PCS",
            "Kg",
            "M",
            "L"});
            this.comboBox2.Location = new System.Drawing.Point(195, 31);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(58, 21);
            this.comboBox2.TabIndex = 1;
            // 
            // comboBox1
            // 
            this.comboBox1.DisplayMember = "Home Stuff";
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Home",
            "Work"});
            this.comboBox1.Location = new System.Drawing.Point(12, 31);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 21);
            this.comboBox1.TabIndex = 0;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Control;
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox1.Location = new System.Drawing.Point(12, 96);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 13);
            this.textBox1.TabIndex = 7;
            this.textBox1.TabStop = false;
            this.textBox1.Text = "Item";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Location = new System.Drawing.Point(165, 96);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 13);
            this.textBox2.TabIndex = 8;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "Qty";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // insertNametxtbox
            // 
            this.insertNametxtbox.Location = new System.Drawing.Point(12, 115);
            this.insertNametxtbox.Multiline = true;
            this.insertNametxtbox.Name = "insertNametxtbox";
            this.insertNametxtbox.Size = new System.Drawing.Size(121, 20);
            this.insertNametxtbox.TabIndex = 2;
            // 
            // insertQtytxtbox
            // 
            this.insertQtytxtbox.Location = new System.Drawing.Point(182, 115);
            this.insertQtytxtbox.Multiline = true;
            this.insertQtytxtbox.Name = "insertQtytxtbox";
            this.insertQtytxtbox.Size = new System.Drawing.Size(71, 20);
            this.insertQtytxtbox.TabIndex = 3;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Location = new System.Drawing.Point(22, 162);
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(100, 13);
            this.textBox5.TabIndex = 9;
            this.textBox5.TabStop = false;
            this.textBox5.Text = "Price";
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // insertPricetxtbox
            // 
            this.insertPricetxtbox.Location = new System.Drawing.Point(22, 181);
            this.insertPricetxtbox.Name = "insertPricetxtbox";
            this.insertPricetxtbox.Size = new System.Drawing.Size(100, 20);
            this.insertPricetxtbox.TabIndex = 4;
            // 
            // insertButton
            // 
            this.insertButton.Location = new System.Drawing.Point(103, 278);
            this.insertButton.Name = "insertButton";
            this.insertButton.Size = new System.Drawing.Size(93, 29);
            this.insertButton.TabIndex = 6;
            this.insertButton.Text = "Insert";
            this.insertButton.UseVisualStyleBackColor = true;
            this.insertButton.Click += new System.EventHandler(this.insertButton_Click);
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.SystemColors.Control;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Location = new System.Drawing.Point(22, 12);
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(100, 13);
            this.textBox3.TabIndex = 10;
            this.textBox3.TabStop = false;
            this.textBox3.Text = "Inventory";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Location = new System.Drawing.Point(175, 12);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 13);
            this.textBox4.TabIndex = 11;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "U.M.";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Control;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Location = new System.Drawing.Point(165, 162);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 13);
            this.textBox6.TabIndex = 12;
            this.textBox6.TabStop = false;
            this.textBox6.Text = "Date";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // insertDatepicker
            // 
            this.insertDatepicker.CustomFormat = "dd/mm/yyy";
            this.insertDatepicker.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.insertDatepicker.Location = new System.Drawing.Point(172, 181);
            this.insertDatepicker.Name = "insertDatepicker";
            this.insertDatepicker.Size = new System.Drawing.Size(93, 20);
            this.insertDatepicker.TabIndex = 13;
            // 
            // InsertStock
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 361);
            this.Controls.Add(this.insertDatepicker);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.insertButton);
            this.Controls.Add(this.insertPricetxtbox);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.insertQtytxtbox);
            this.Controls.Add(this.insertNametxtbox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.comboBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "InsertStock";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "InsertStock";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox insertNametxtbox;
        private System.Windows.Forms.TextBox insertQtytxtbox;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.TextBox insertPricetxtbox;
        private System.Windows.Forms.Button insertButton;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.DateTimePicker insertDatepicker;
    }
}