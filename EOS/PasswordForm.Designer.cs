namespace EOS
{
    partial class PasswordForm
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
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.newpassButton = new System.Windows.Forms.Button();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.newpasstxtbox = new System.Windows.Forms.TextBox();
            this.confirmpasstxtbox = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox2.Location = new System.Drawing.Point(421, 77);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(15, 14);
            this.checkBox2.TabIndex = 4;
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // newpassButton
            // 
            this.newpassButton.Location = new System.Drawing.Point(470, 47);
            this.newpassButton.Name = "newpassButton";
            this.newpassButton.Size = new System.Drawing.Size(98, 35);
            this.newpassButton.TabIndex = 5;
            this.newpassButton.Text = "Submit";
            this.newpassButton.UseVisualStyleBackColor = true;
            this.newpassButton.Click += new System.EventHandler(this.newpassButton_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.AutoSize = true;
            this.linkLabel1.Location = new System.Drawing.Point(301, 113);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(53, 22);
            this.linkLabel1.TabIndex = 6;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Close";
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.SystemColors.Control;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.Location = new System.Drawing.Point(29, 70);
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(224, 29);
            this.textBox4.TabIndex = 8;
            this.textBox4.TabStop = false;
            this.textBox4.Text = "Confirm Password :";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // newpasstxtbox
            // 
            this.newpasstxtbox.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newpasstxtbox.Location = new System.Drawing.Point(259, 23);
            this.newpasstxtbox.Name = "newpasstxtbox";
            this.newpasstxtbox.PasswordChar = '*';
            this.newpasstxtbox.Size = new System.Drawing.Size(187, 32);
            this.newpasstxtbox.TabIndex = 1;
            // 
            // confirmpasstxtbox
            // 
            this.confirmpasstxtbox.Font = new System.Drawing.Font("Cambria", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmpasstxtbox.Location = new System.Drawing.Point(259, 70);
            this.confirmpasstxtbox.Name = "confirmpasstxtbox";
            this.confirmpasstxtbox.PasswordChar = '*';
            this.confirmpasstxtbox.Size = new System.Drawing.Size(187, 32);
            this.confirmpasstxtbox.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Control;
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox2.Font = new System.Drawing.Font("Cambria", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.Location = new System.Drawing.Point(29, 23);
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(224, 29);
            this.textBox2.TabIndex = 7;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "New Password :";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.checkBox1.Location = new System.Drawing.Point(421, 33);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // PasswordForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 22F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 144);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.newpassButton);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.newpasstxtbox);
            this.Controls.Add(this.confirmpasstxtbox);
            this.Controls.Add(this.textBox2);
            this.Font = new System.Drawing.Font("Cambria", 14.25F);
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "PasswordForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "New password";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button newpassButton;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox newpasstxtbox;
        private System.Windows.Forms.TextBox confirmpasstxtbox;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}