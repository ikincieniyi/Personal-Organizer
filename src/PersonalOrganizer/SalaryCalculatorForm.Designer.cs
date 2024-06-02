namespace PersonalOrganizer
{
    partial class SalaryCalculatorForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.deneyimComboBox = new System.Windows.Forms.ComboBox();
            this.yasanilanSehirComboBox = new System.Windows.Forms.ComboBox();
            this.ustOgrenimComboBox = new System.Windows.Forms.ComboBox();
            this.yoneticilikComboBox = new System.Windows.Forms.ComboBox();
            this.AileDurumuGb = new System.Windows.Forms.GroupBox();
            this.yabanciDilGb = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cocuk0_6 = new System.Windows.Forms.NumericUpDown();
            this.cocuk7_18 = new System.Windows.Forms.NumericUpDown();
            this.cocuk18 = new System.Windows.Forms.NumericUpDown();
            this.label11 = new System.Windows.Forms.Label();
            this.belgeliIngilizceCheckBox = new System.Windows.Forms.CheckBox();
            this.ingilizceOkulCheckBox = new System.Windows.Forms.CheckBox();
            this.digerYabanciDilSayisi = new System.Windows.Forms.NumericUpDown();
            this.esDurumuComboBox = new System.Windows.Forms.CheckBox();
            this.maasLabel = new System.Windows.Forms.Label();
            this.maasHesaplaButton = new System.Windows.Forms.Button();
            this.AileDurumuGb.SuspendLayout();
            this.yabanciDilGb.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cocuk0_6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cocuk7_18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cocuk18)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.digerYabanciDilSayisi)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(50, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Deneyim";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Yaşanılan İl";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(50, 134);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Üst Öğrenim";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(50, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(89, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Yöneticilik Görevi";
            // 
            // deneyimComboBox
            // 
            this.deneyimComboBox.FormattingEnabled = true;
            this.deneyimComboBox.Items.AddRange(new object[] {
            "2-4 Yıl",
            "5-9 Yıl",
            "10-14 Yıl",
            "15-20 Yıl",
            "20 Yıl Üstü"});
            this.deneyimComboBox.Location = new System.Drawing.Point(204, 37);
            this.deneyimComboBox.Name = "deneyimComboBox";
            this.deneyimComboBox.Size = new System.Drawing.Size(121, 21);
            this.deneyimComboBox.TabIndex = 6;
            // 
            // yasanilanSehirComboBox
            // 
            this.yasanilanSehirComboBox.FormattingEnabled = true;
            this.yasanilanSehirComboBox.Items.AddRange(new object[] {
            "TR10: İstanbul",
            "TR51: Ankara",
            "TR31: İzmir",
            "TR42: Kocaeli, Sakarya, Düzce, Bolu, Yalova",
            "TR21: Edirne, Kırklareli, Tekirdağ",
            "TR90: Trabzon, Ordu, Giresun, Rize, Artvin, Gümüşhane",
            "TR41: Bursa, Eskişehir, Bilecik",
            "TR32: Aydın, Denizli Muğla",
            "TR62: Adana, Mersin",
            "TR22: Balıkesir, Çanakkale",
            "TR61: Antalya, Isparta, Burdur",
            "Diğer"});
            this.yasanilanSehirComboBox.Location = new System.Drawing.Point(204, 78);
            this.yasanilanSehirComboBox.Name = "yasanilanSehirComboBox";
            this.yasanilanSehirComboBox.Size = new System.Drawing.Size(121, 21);
            this.yasanilanSehirComboBox.TabIndex = 7;
            // 
            // ustOgrenimComboBox
            // 
            this.ustOgrenimComboBox.FormattingEnabled = true;
            this.ustOgrenimComboBox.Items.AddRange(new object[] {
            "Meslek alanı ile ilgili yüksek lisans",
            "Meslek alanı ile ilgili doktora",
            "Meslek alanı ile ilgili doçentlik",
            "Meslek alanı ile ilgili olmayan yüksek lisans",
            "Meslek alanı ile ilgili olmayan doktora/doçentlik"});
            this.ustOgrenimComboBox.Location = new System.Drawing.Point(204, 126);
            this.ustOgrenimComboBox.Name = "ustOgrenimComboBox";
            this.ustOgrenimComboBox.Size = new System.Drawing.Size(121, 21);
            this.ustOgrenimComboBox.TabIndex = 8;
            // 
            // yoneticilikComboBox
            // 
            this.yoneticilikComboBox.FormattingEnabled = true;
            this.yoneticilikComboBox.Items.AddRange(new object[] {
            "Takım Lideri/Grup Yöneticisi/Teknik Yönetici/Yazılım Mimarı",
            "Proje Yöneticisi",
            "Direktör/Projeler Yöneticisi ",
            "CTO/Genel Müdür",
            "Bilgi İşlem Sorumlusu/Müdürü (Bilgi İşlem biriminde en çok 5 bilişim personeli va" +
                "rsa) ",
            "Bilgi İşlem Sorumlusu/Müdürü (Bilgi İşlem biriminde 5\'ten çok bilişim personeli v" +
                "arsa) "});
            this.yoneticilikComboBox.Location = new System.Drawing.Point(204, 176);
            this.yoneticilikComboBox.Name = "yoneticilikComboBox";
            this.yoneticilikComboBox.Size = new System.Drawing.Size(121, 21);
            this.yoneticilikComboBox.TabIndex = 9;
            // 
            // AileDurumuGb
            // 
            this.AileDurumuGb.Controls.Add(this.esDurumuComboBox);
            this.AileDurumuGb.Controls.Add(this.cocuk18);
            this.AileDurumuGb.Controls.Add(this.cocuk7_18);
            this.AileDurumuGb.Controls.Add(this.cocuk0_6);
            this.AileDurumuGb.Controls.Add(this.label8);
            this.AileDurumuGb.Controls.Add(this.label7);
            this.AileDurumuGb.Controls.Add(this.label6);
            this.AileDurumuGb.Location = new System.Drawing.Point(49, 238);
            this.AileDurumuGb.Name = "AileDurumuGb";
            this.AileDurumuGb.Size = new System.Drawing.Size(276, 232);
            this.AileDurumuGb.TabIndex = 10;
            this.AileDurumuGb.TabStop = false;
            this.AileDurumuGb.Text = "Aile Durumu";
            // 
            // yabanciDilGb
            // 
            this.yabanciDilGb.Controls.Add(this.digerYabanciDilSayisi);
            this.yabanciDilGb.Controls.Add(this.ingilizceOkulCheckBox);
            this.yabanciDilGb.Controls.Add(this.belgeliIngilizceCheckBox);
            this.yabanciDilGb.Controls.Add(this.label11);
            this.yabanciDilGb.Location = new System.Drawing.Point(331, 238);
            this.yabanciDilGb.Name = "yabanciDilGb";
            this.yabanciDilGb.Size = new System.Drawing.Size(288, 231);
            this.yabanciDilGb.TabIndex = 11;
            this.yabanciDilGb.TabStop = false;
            this.yabanciDilGb.Text = "Yabancı Dil Bilgisi";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 90);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "0-6 yaş arası çocuk";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 132);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 13);
            this.label7.TabIndex = 2;
            this.label7.Text = "7-18 yaş arası çocuk";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 177);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(94, 26);
            this.label8.TabIndex = 3;
            this.label8.Text = "18 yaş üstü çocuk\r\n(Öğrenci)\r\n";
            // 
            // cocuk0_6
            // 
            this.cocuk0_6.Location = new System.Drawing.Point(141, 83);
            this.cocuk0_6.Name = "cocuk0_6";
            this.cocuk0_6.Size = new System.Drawing.Size(120, 20);
            this.cocuk0_6.TabIndex = 5;
            // 
            // cocuk7_18
            // 
            this.cocuk7_18.Location = new System.Drawing.Point(141, 125);
            this.cocuk7_18.Name = "cocuk7_18";
            this.cocuk7_18.Size = new System.Drawing.Size(120, 20);
            this.cocuk7_18.TabIndex = 6;
            // 
            // cocuk18
            // 
            this.cocuk18.Location = new System.Drawing.Point(141, 175);
            this.cocuk18.Name = "cocuk18";
            this.cocuk18.Size = new System.Drawing.Size(120, 20);
            this.cocuk18.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 132);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(157, 26);
            this.label11.TabIndex = 2;
            this.label11.Text = "Belgelendirilmiş diğer yabancı dil\r\n(her dil için)";
            // 
            // belgeliIngilizceCheckBox
            // 
            this.belgeliIngilizceCheckBox.AutoSize = true;
            this.belgeliIngilizceCheckBox.Location = new System.Drawing.Point(9, 39);
            this.belgeliIngilizceCheckBox.Name = "belgeliIngilizceCheckBox";
            this.belgeliIngilizceCheckBox.Size = new System.Drawing.Size(138, 17);
            this.belgeliIngilizceCheckBox.TabIndex = 3;
            this.belgeliIngilizceCheckBox.Text = "Belgelendirilmiş İngilizce";
            this.belgeliIngilizceCheckBox.UseVisualStyleBackColor = true;
            // 
            // ingilizceOkulCheckBox
            // 
            this.ingilizceOkulCheckBox.AutoSize = true;
            this.ingilizceOkulCheckBox.Location = new System.Drawing.Point(9, 84);
            this.ingilizceOkulCheckBox.Name = "ingilizceOkulCheckBox";
            this.ingilizceOkulCheckBox.Size = new System.Drawing.Size(177, 17);
            this.ingilizceOkulCheckBox.TabIndex = 4;
            this.ingilizceOkulCheckBox.Text = "İngilizce Eğitim Veren Okul Mez.";
            this.ingilizceOkulCheckBox.UseVisualStyleBackColor = true;
            // 
            // digerYabanciDilSayisi
            // 
            this.digerYabanciDilSayisi.Location = new System.Drawing.Point(189, 130);
            this.digerYabanciDilSayisi.Name = "digerYabanciDilSayisi";
            this.digerYabanciDilSayisi.Size = new System.Drawing.Size(53, 20);
            this.digerYabanciDilSayisi.TabIndex = 5;
            // 
            // esDurumuComboBox
            // 
            this.esDurumuComboBox.AutoSize = true;
            this.esDurumuComboBox.Location = new System.Drawing.Point(9, 39);
            this.esDurumuComboBox.Name = "esDurumuComboBox";
            this.esDurumuComboBox.Size = new System.Drawing.Size(122, 17);
            this.esDurumuComboBox.TabIndex = 8;
            this.esDurumuComboBox.Text = "Evli ve eşi çalışmıyor";
            this.esDurumuComboBox.UseVisualStyleBackColor = true;
            // 
            // maasLabel
            // 
            this.maasLabel.AutoSize = true;
            this.maasLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.maasLabel.Location = new System.Drawing.Point(353, 44);
            this.maasLabel.Name = "maasLabel";
            this.maasLabel.Size = new System.Drawing.Size(168, 62);
            this.maasLabel.TabIndex = 12;
            this.maasLabel.Text = "MAAŞINIZ: \r\n0TL";
            // 
            // maasHesaplaButton
            // 
            this.maasHesaplaButton.Location = new System.Drawing.Point(359, 162);
            this.maasHesaplaButton.Name = "maasHesaplaButton";
            this.maasHesaplaButton.Size = new System.Drawing.Size(119, 30);
            this.maasHesaplaButton.TabIndex = 13;
            this.maasHesaplaButton.Text = "MAAŞ HESAPLA";
            this.maasHesaplaButton.UseVisualStyleBackColor = true;
            this.maasHesaplaButton.Click += new System.EventHandler(this.maasHesaplaButton_Click);
            // 
            // SalaryCalculatorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(944, 501);
            this.Controls.Add(this.maasHesaplaButton);
            this.Controls.Add(this.maasLabel);
            this.Controls.Add(this.yabanciDilGb);
            this.Controls.Add(this.AileDurumuGb);
            this.Controls.Add(this.yoneticilikComboBox);
            this.Controls.Add(this.ustOgrenimComboBox);
            this.Controls.Add(this.yasanilanSehirComboBox);
            this.Controls.Add(this.deneyimComboBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "SalaryCalculatorForm";
            this.Text = "SalaryCalculatorForm";
            this.AileDurumuGb.ResumeLayout(false);
            this.AileDurumuGb.PerformLayout();
            this.yabanciDilGb.ResumeLayout(false);
            this.yabanciDilGb.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cocuk0_6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cocuk7_18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cocuk18)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.digerYabanciDilSayisi)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox deneyimComboBox;
        private System.Windows.Forms.ComboBox yasanilanSehirComboBox;
        private System.Windows.Forms.ComboBox ustOgrenimComboBox;
        private System.Windows.Forms.ComboBox yoneticilikComboBox;
        private System.Windows.Forms.GroupBox AileDurumuGb;
        private System.Windows.Forms.GroupBox yabanciDilGb;
        private System.Windows.Forms.NumericUpDown cocuk18;
        private System.Windows.Forms.NumericUpDown cocuk7_18;
        private System.Windows.Forms.NumericUpDown cocuk0_6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.CheckBox ingilizceOkulCheckBox;
        private System.Windows.Forms.CheckBox belgeliIngilizceCheckBox;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.NumericUpDown digerYabanciDilSayisi;
        private System.Windows.Forms.CheckBox esDurumuComboBox;
        private System.Windows.Forms.Label maasLabel;
        private System.Windows.Forms.Button maasHesaplaButton;
    }
}