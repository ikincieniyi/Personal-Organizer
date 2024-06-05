namespace PersonalOrganizer
{
    partial class UserForm
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
            this.notesButton = new System.Windows.Forms.Button();
            this.phonebookButton = new System.Windows.Forms.Button();
            this.salaryCalculatorButton = new System.Windows.Forms.Button();
            this.reminderButton = new System.Windows.Forms.Button();
            this.personalInformationButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // notesButton
            // 
            this.notesButton.Location = new System.Drawing.Point(12, 12);
            this.notesButton.Name = "notesButton";
            this.notesButton.Size = new System.Drawing.Size(157, 83);
            this.notesButton.TabIndex = 0;
            this.notesButton.Text = "NOTLAR";
            this.notesButton.UseVisualStyleBackColor = true;
            this.notesButton.Click += new System.EventHandler(this.notesButton_Click);
            // 
            // phonebookButton
            // 
            this.phonebookButton.Location = new System.Drawing.Point(175, 12);
            this.phonebookButton.Name = "phonebookButton";
            this.phonebookButton.Size = new System.Drawing.Size(157, 83);
            this.phonebookButton.TabIndex = 1;
            this.phonebookButton.Text = "TELEFON\r\nDEFTERİ\r\n";
            this.phonebookButton.UseVisualStyleBackColor = true;
            this.phonebookButton.Click += new System.EventHandler(this.phonebookButton_Click);
            // 
            // salaryCalculatorButton
            // 
            this.salaryCalculatorButton.Location = new System.Drawing.Point(12, 126);
            this.salaryCalculatorButton.Name = "salaryCalculatorButton";
            this.salaryCalculatorButton.Size = new System.Drawing.Size(157, 83);
            this.salaryCalculatorButton.TabIndex = 2;
            this.salaryCalculatorButton.Text = "MAAŞ\r\nHESAPLAYICI";
            this.salaryCalculatorButton.UseVisualStyleBackColor = true;
            this.salaryCalculatorButton.Click += new System.EventHandler(this.salaryCalculatorButton_Click);
            // 
            // reminderButton
            // 
            this.reminderButton.Location = new System.Drawing.Point(175, 126);
            this.reminderButton.Name = "reminderButton";
            this.reminderButton.Size = new System.Drawing.Size(157, 83);
            this.reminderButton.TabIndex = 3;
            this.reminderButton.Text = "HATIRLATICI";
            this.reminderButton.UseVisualStyleBackColor = true;
            this.reminderButton.Click += new System.EventHandler(this.reminderButton_Click);
            // 
            // personalInformationButton
            // 
            this.personalInformationButton.Location = new System.Drawing.Point(12, 239);
            this.personalInformationButton.Name = "personalInformationButton";
            this.personalInformationButton.Size = new System.Drawing.Size(157, 83);
            this.personalInformationButton.TabIndex = 4;
            this.personalInformationButton.Text = "PROFİLİM";
            this.personalInformationButton.UseVisualStyleBackColor = true;
            this.personalInformationButton.Click += new System.EventHandler(this.personalInformationButton_Click);
            // 
            // UserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.personalInformationButton);
            this.Controls.Add(this.reminderButton);
            this.Controls.Add(this.salaryCalculatorButton);
            this.Controls.Add(this.phonebookButton);
            this.Controls.Add(this.notesButton);
            this.Name = "UserForm";
            this.Text = "UserForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button notesButton;
        private System.Windows.Forms.Button phonebookButton;
        private System.Windows.Forms.Button salaryCalculatorButton;
        private System.Windows.Forms.Button reminderButton;
        private System.Windows.Forms.Button personalInformationButton;
    }
}