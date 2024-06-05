namespace PersonalOrganizer
{
    partial class AdminForm
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
            this.listView1 = new System.Windows.Forms.ListView();
            this.yeniRolComboBox = new System.Windows.Forms.ComboBox();
            this.updateButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.kullanıcıButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listView1
            // 
            this.listView1.AllowColumnReorder = true;
            this.listView1.HideSelection = false;
            this.listView1.Location = new System.Drawing.Point(12, 12);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(618, 477);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            // 
            // yeniRolComboBox
            // 
            this.yeniRolComboBox.FormattingEnabled = true;
            this.yeniRolComboBox.Items.AddRange(new object[] {
            "admin",
            "user",
            "partTimeUser"});
            this.yeniRolComboBox.Location = new System.Drawing.Point(718, 12);
            this.yeniRolComboBox.Name = "yeniRolComboBox";
            this.yeniRolComboBox.Size = new System.Drawing.Size(190, 21);
            this.yeniRolComboBox.TabIndex = 1;
            // 
            // updateButton
            // 
            this.updateButton.Location = new System.Drawing.Point(810, 39);
            this.updateButton.Name = "updateButton";
            this.updateButton.Size = new System.Drawing.Size(98, 41);
            this.updateButton.TabIndex = 2;
            this.updateButton.Text = "Kullanıcı Tipini Değiştir";
            this.updateButton.UseVisualStyleBackColor = true;
            this.updateButton.Click += new System.EventHandler(this.updateButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(665, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Yeni Rol";
            // 
            // kullanıcıButton
            // 
            this.kullanıcıButton.Location = new System.Drawing.Point(791, 426);
            this.kullanıcıButton.Name = "kullanıcıButton";
            this.kullanıcıButton.Size = new System.Drawing.Size(127, 63);
            this.kullanıcıButton.TabIndex = 4;
            this.kullanıcıButton.Text = "Kullanıcı Ekranı";
            this.kullanıcıButton.UseVisualStyleBackColor = true;
            this.kullanıcıButton.Click += new System.EventHandler(this.kullanıcıButton_Click);
            // 
            // AdminForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.kullanıcıButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateButton);
            this.Controls.Add(this.yeniRolComboBox);
            this.Controls.Add(this.listView1);
            this.Name = "AdminForm";
            this.Text = "AdminForm";
            this.Load += new System.EventHandler(this.AdminForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.ComboBox yeniRolComboBox;
        private System.Windows.Forms.Button updateButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button kullanıcıButton;
    }
}