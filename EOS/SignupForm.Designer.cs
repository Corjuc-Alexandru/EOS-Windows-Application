namespace EOS
{
    partial class SignupForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SignupForm));
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.signupUsertxtbox = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.signupPasstxtbox = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.signupConfirmpasstxtbox = new System.Windows.Forms.TextBox();
            this.signupButton = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBox1, "textBox1");
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBox2, "textBox2");
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.TabStop = false;
            // 
            // signupUsertxtbox
            // 
            resources.ApplyResources(this.signupUsertxtbox, "signupUsertxtbox");
            this.signupUsertxtbox.Name = "signupUsertxtbox";
            this.signupUsertxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.signupUsertxtbox_KeyDown);
            // 
            // textBox4
            // 
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBox4, "textBox4");
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.TabStop = false;
            // 
            // signupPasstxtbox
            // 
            this.signupPasstxtbox.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            resources.ApplyResources(this.signupPasstxtbox, "signupPasstxtbox");
            this.signupPasstxtbox.Name = "signupPasstxtbox";
            this.signupPasstxtbox.Tag = "";
            this.toolTip1.SetToolTip(this.signupPasstxtbox, resources.GetString("signupPasstxtbox.ToolTip"));
            this.signupPasstxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.singupPasstxtbox_KeyDown);
            // 
            // textBox6
            // 
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBox6, "textBox6");
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.TabStop = false;
            // 
            // signupConfirmpasstxtbox
            // 
            resources.ApplyResources(this.signupConfirmpasstxtbox, "signupConfirmpasstxtbox");
            this.signupConfirmpasstxtbox.Name = "signupConfirmpasstxtbox";
            this.signupConfirmpasstxtbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.signupConfirmpasstxtbox_KeyDown);
            // 
            // signupButton
            // 
            resources.ApplyResources(this.signupButton, "signupButton");
            this.signupButton.Name = "signupButton";
            this.signupButton.UseVisualStyleBackColor = true;
            this.signupButton.Click += new System.EventHandler(this.signupButton_Click);
            // 
            // checkBox1
            // 
            resources.ApplyResources(this.checkBox1, "checkBox1");
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // linkLabel1
            // 
            resources.ApplyResources(this.linkLabel1, "linkLabel1");
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.TabStop = true;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // checkBox2
            // 
            resources.ApplyResources(this.checkBox2, "checkBox2");
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // textBox3
            // 
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            resources.ApplyResources(this.textBox3, "textBox3");
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.TabStop = false;
            // 
            // SignupForm
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.linkLabel1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.signupButton);
            this.Controls.Add(this.signupConfirmpasstxtbox);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.signupPasstxtbox);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.signupUsertxtbox);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SignupForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox signupUsertxtbox;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox signupPasstxtbox;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox signupConfirmpasstxtbox;
        private System.Windows.Forms.Button signupButton;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.LinkLabel linkLabel1;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.TextBox textBox3;
    }
}