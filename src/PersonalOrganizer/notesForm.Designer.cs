namespace PersonalOrganizer
{
    partial class notesForm
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
            this.noteViewerTextBox = new System.Windows.Forms.TextBox();
            this.noteSelecterComboBox = new System.Windows.Forms.ComboBox();
            this.noteAdderTextBox = new System.Windows.Forms.TextBox();
            this.addNoteButton = new System.Windows.Forms.Button();
            this.deleteNoteButton = new System.Windows.Forms.Button();
            this.updateNoteButton = new System.Windows.Forms.Button();
            this.addNoteTitleTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // noteViewerTextBox
            // 
            this.noteViewerTextBox.Location = new System.Drawing.Point(12, 67);
            this.noteViewerTextBox.Multiline = true;
            this.noteViewerTextBox.Name = "noteViewerTextBox";
            this.noteViewerTextBox.Size = new System.Drawing.Size(373, 363);
            this.noteViewerTextBox.TabIndex = 0;
            // 
            // noteSelecterComboBox
            // 
            this.noteSelecterComboBox.FormattingEnabled = true;
            this.noteSelecterComboBox.Location = new System.Drawing.Point(12, 40);
            this.noteSelecterComboBox.Name = "noteSelecterComboBox";
            this.noteSelecterComboBox.Size = new System.Drawing.Size(185, 21);
            this.noteSelecterComboBox.TabIndex = 1;
            this.noteSelecterComboBox.SelectedIndexChanged += new System.EventHandler(this.noteSelecterComboBox_SelectedIndexChanged);
            // 
            // noteAdderTextBox
            // 
            this.noteAdderTextBox.Location = new System.Drawing.Point(559, 67);
            this.noteAdderTextBox.Multiline = true;
            this.noteAdderTextBox.Name = "noteAdderTextBox";
            this.noteAdderTextBox.Size = new System.Drawing.Size(363, 363);
            this.noteAdderTextBox.TabIndex = 2;
            // 
            // addNoteButton
            // 
            this.addNoteButton.Location = new System.Drawing.Point(805, 38);
            this.addNoteButton.Name = "addNoteButton";
            this.addNoteButton.Size = new System.Drawing.Size(117, 23);
            this.addNoteButton.TabIndex = 3;
            this.addNoteButton.Text = "Not Ekle";
            this.addNoteButton.UseVisualStyleBackColor = true;
            this.addNoteButton.Click += new System.EventHandler(this.addNoteButton_Click);
            // 
            // deleteNoteButton
            // 
            this.deleteNoteButton.Location = new System.Drawing.Point(391, 67);
            this.deleteNoteButton.Name = "deleteNoteButton";
            this.deleteNoteButton.Size = new System.Drawing.Size(117, 44);
            this.deleteNoteButton.TabIndex = 4;
            this.deleteNoteButton.Text = "Notu Sİl";
            this.deleteNoteButton.UseVisualStyleBackColor = true;
            this.deleteNoteButton.Click += new System.EventHandler(this.deleteNoteButton_Click);
            // 
            // updateNoteButton
            // 
            this.updateNoteButton.Location = new System.Drawing.Point(391, 117);
            this.updateNoteButton.Name = "updateNoteButton";
            this.updateNoteButton.Size = new System.Drawing.Size(117, 47);
            this.updateNoteButton.TabIndex = 5;
            this.updateNoteButton.Text = "Notu Güncelle";
            this.updateNoteButton.UseVisualStyleBackColor = true;
            this.updateNoteButton.Click += new System.EventHandler(this.updateNoteButton_Click);
            // 
            // addNoteTitleTextBox
            // 
            this.addNoteTitleTextBox.Location = new System.Drawing.Point(589, 41);
            this.addNoteTitleTextBox.Name = "addNoteTitleTextBox";
            this.addNoteTitleTextBox.Size = new System.Drawing.Size(184, 20);
            this.addNoteTitleTextBox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(556, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Title";
            // 
            // notesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addNoteTitleTextBox);
            this.Controls.Add(this.updateNoteButton);
            this.Controls.Add(this.deleteNoteButton);
            this.Controls.Add(this.addNoteButton);
            this.Controls.Add(this.noteAdderTextBox);
            this.Controls.Add(this.noteSelecterComboBox);
            this.Controls.Add(this.noteViewerTextBox);
            this.Name = "notesForm";
            this.Text = "notesForm";
            this.Load += new System.EventHandler(this.notesForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox noteViewerTextBox;
        private System.Windows.Forms.ComboBox noteSelecterComboBox;
        private System.Windows.Forms.TextBox noteAdderTextBox;
        private System.Windows.Forms.Button addNoteButton;
        private System.Windows.Forms.Button deleteNoteButton;
        private System.Windows.Forms.Button updateNoteButton;
        private System.Windows.Forms.TextBox addNoteTitleTextBox;
        private System.Windows.Forms.Label label1;
    }
}