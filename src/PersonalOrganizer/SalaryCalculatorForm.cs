﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalOrganizer
{
    public partial class SalaryCalculatorForm : Form
    {
        //baz ücret, brüt asgari ücretin 2 katıdır
        double bazUcret = 20002.5 * 2;
        string phoneNumber;
        string usertype;

        Dictionary<string, double> deneyim = new Dictionary<string, double>()
        {
            {"Hiçbiri", 0 },
            {"2-4 Yıl", 0.6},
            {"5-9 Yıl", 1},
            {"10-14 Yıl", 1.2},
            {"15-19 Yıl", 1.35},
            {"20 Yıl Üstü", 1.5},
        };

        Dictionary<string, double> sehir = new Dictionary<string, double>()
        {
            {"TR10: İstanbul", 0.3},
            {"TR51: Ankara", 0.2},
            {"TR31: İzmir", 0.2},
            {"TR42: Kocaeli-Sakarya-Düzce-Bolu-Yalova", 0.1},
            {"TR21: Edirne-Kırklareli-Tekirdağ", 0.1},
            {"TR90: Trabzon-Ordu-Giresun-Rize-Artvin-Gümüşhane", 0.05},
            {"TR41: Bursa-Eskişehir-Bilecik", 0.05},
            {"TR32: Aydın-Denizli-Muğla", 0.05},
            {"TR62: Adana-Mersin", 0.05},
            {"TR22: Balıkesir-Çanakkale", 0.05},
            {"TR61: Antalya-Isparta-Burdur", 0.05},
            {"Diğer", 0},
        };

        Dictionary<string, double> egitim = new Dictionary<string, double>()
        {
            {"Hiçbiri", 0 },
            {"Meslek alanı ile ilgili yüksek lisans", 0.1},
            {"Meslek alanı ile ilgili doktora", 0.3},
            {"Meslek alanı ile ilgili doçentlik", 0.35},
            {"Meslek alanı ile ilgili olmayan yüksek lisans", 0.05},
            {"Meslek alanı ile ilgili olmayan doktora/doçentlik", 0.15},
        };

        Dictionary<string, double> pozisyon = new Dictionary<string, double>()
        {
            {"Hiçbiri", 0 },
            {"Takım Lideri-Grup Yöneticisi-Teknik Yönetici-Yazılım Mimarı", 0.5},
            {"Proje Yöneticisi", 0.75},
            {"Direktör-Projeler Yöneticisi", 0.85},
            {"CTO-Genel Müdür", 1},
            {"Bilgi İşlem Sorumlusu-Müdürü (Bilgi İşlem biriminde en çok 5 bilişim personeli varsa)", 0.4},
            {"Bilgi İşlem Sorumlusu-Müdürü (Bilgi İşlem biriminde 5'ten çok bilişim personeli varsa)", 0.6},
        };

        Dictionary<string, double> aile = new Dictionary<string, double>()
        {
            {"esDurumu", 0.2},
            {"cocuk0_6", 0.2},
            {"cocuk7_18", 0.3},
            {"cocuk18", 0.4},
        };

        Dictionary<string, double> yabanciDil = new Dictionary<string, double>()
        {
            {"Hiçbiri", 0 },
            {"Belgelendirilmiş İngilizce", 0.2},
            {"İngilizce Eğitim Veren Okul Mez.", 0.2},
            {"Belgelendirilmiş diğer yabancı dil", 0.05},
        };


        public SalaryCalculatorForm(string phoneNumber, string userType)
        {
            InitializeComponent();
            this.phoneNumber = phoneNumber;
            this.usertype = userType;
        }

        private double maasHesapla()
        {
            double maas = 0;
            double deneyimDegeri = 0;
            double sehirDegeri = 0;
            double egitimDegeri = 0;
            double pozisyonDegeri = 0;
            double aileDegeri = 0;
            double yabanciDilDegeri = 0;

            if (deneyimComboBox.SelectedItem != null)
            {
                deneyim.TryGetValue(deneyimComboBox.SelectedItem.ToString(), out deneyimDegeri);
            }
            if (yasanilanSehirComboBox.SelectedItem != null)
            {
                sehir.TryGetValue(yasanilanSehirComboBox.SelectedItem.ToString(), out sehirDegeri);
            }
            if (ustOgrenimComboBox.SelectedItem != null)
            {
                egitim.TryGetValue(ustOgrenimComboBox.SelectedItem.ToString(), out egitimDegeri);
            }
            if (yoneticilikComboBox.SelectedItem != null)
            {
                pozisyon.TryGetValue(yoneticilikComboBox.SelectedItem.ToString(), out pozisyonDegeri);
            }
            //aile durumu için kullanıcı es durumu seçeneğini seçtiyse bu değeri al, çocuklar için de en büyük 2 çocuğun değerini al
            if (esDurumuComboBox.Checked)
            {
                aile.TryGetValue("esDurumu", out aileDegeri);
            }
            Stack<string> cocuklar = new Stack<string>();
            for (int i = 0; i < cocuk0_6.Value; i++)
            {
                cocuklar.Push("cocuk0_6");
            }
            for (int i = 0; i < cocuk7_18.Value; i++)
            {
                cocuklar.Push("cocuk7_18");
            }
            for (int i = 0; i < cocuk18.Value; i++)
            {
                cocuklar.Push("cocuk18");
            }
            for (int i = 0; i < 2; i++)
            {
                if (cocuklar.Count > 0)
                {
                    string cocuk = cocuklar.Pop();
                    aile.TryGetValue(cocuk, out double cocukDegeri);
                    aileDegeri += cocukDegeri;
                }
            }

            //yabancı dil bilgisi
            if (belgeliIngilizceCheckBox.Checked)
            {
                yabanciDil.TryGetValue("Belgelendirilmiş İngilizce", out double belgeliIngLocale);
                yabanciDilDegeri += belgeliIngLocale;
            }
            if (ingilizceOkulCheckBox.Checked)
            {
                yabanciDil.TryGetValue("İngilizce Eğitim Veren Okul Mez.", out double ingEgitimLocale);
                yabanciDilDegeri += ingEgitimLocale;
            }
            if (digerYabanciDilSayisi.Value > 0)
            {
                yabanciDil.TryGetValue("Belgelendirilmiş diğer yabancı dil", out double digerDilLocale);
                yabanciDilDegeri += Convert.ToInt32(digerYabanciDilSayisi.Value) * digerDilLocale;
            }

            double maasKatSayisi = 1 + deneyimDegeri + sehirDegeri + egitimDegeri + pozisyonDegeri + aileDegeri + yabanciDilDegeri;

            maas = bazUcret * maasKatSayisi;

            if(usertype == "partTimeUser")
            {
                return maas * 0.5;
            }
            else
            {
                return maas;
            }
        }

        private void maasHesaplaButton_Click(object sender, EventArgs e)
        {
            maasLabel.Text = "Maaş: " + Environment.NewLine + maasHesapla().ToString() + "TL";
            updateSalary();
        }

        private void loadSalary()
        {
            string filePath = "salaries.csv"; // Dosya yolu

            if (!File.Exists(filePath))
            {
                MessageBox.Show("No salary data found.");
                return;
            }

            var lines = File.ReadAllLines(filePath);
            var line = lines.FirstOrDefault(l => l.StartsWith(phoneNumber + ","));
            if (line == null)
            {
                MessageBox.Show("No salary data found for this phone number.");
                return;
            }

            var data = line.Split(',');

            // Verileri UI elementlerine yükle
            deneyimComboBox.SelectedItem = data[1];
            yasanilanSehirComboBox.SelectedItem = data[2];
            ustOgrenimComboBox.SelectedItem = data[3];
            yoneticilikComboBox.SelectedItem = data[4];
            esDurumuComboBox.Checked = bool.Parse(data[5]);
            cocuk0_6.Value = decimal.Parse(data[6]);
            cocuk7_18.Value = decimal.Parse(data[7]);
            cocuk18.Value = decimal.Parse(data[8]);
            belgeliIngilizceCheckBox.Checked = bool.Parse(data[9]);
            ingilizceOkulCheckBox.Checked = bool.Parse(data[10]);
            digerYabanciDilSayisi.Value = decimal.Parse(data[11]);

            MessageBox.Show("Salary data loaded successfully.");
        }

        private void updateSalary()
        {
            string filePath = "salaries.csv"; // Dosya yolu

            if (!File.Exists(filePath))
            {
                MessageBox.Show("No salary data found.");
                return;
            }

            var lines = File.ReadAllLines(filePath).ToList();
            bool found = false;
            for (int i = 0; i < lines.Count; i++)
            {
                var data = lines[i].Split(',');
                if (data[0] == phoneNumber)
                {
                    var updatedData = new List<string>
                    {
                        phoneNumber,
                        deneyimComboBox.SelectedItem?.ToString() ?? "",
                        yasanilanSehirComboBox.SelectedItem?.ToString() ?? "",
                        ustOgrenimComboBox.SelectedItem?.ToString() ?? "",
                        yoneticilikComboBox.SelectedItem?.ToString() ?? "",
                        esDurumuComboBox.Checked.ToString(),
                        cocuk0_6.Value.ToString(),
                        cocuk7_18.Value.ToString(),
                        cocuk18.Value.ToString(),
                        belgeliIngilizceCheckBox.Checked.ToString(),
                        ingilizceOkulCheckBox.Checked.ToString(),
                        digerYabanciDilSayisi.Value.ToString()
                    };

                    lines[i] = string.Join(",", updatedData);
                    found = true;
                    break;
                }
            }

            if (found)
            {
                File.WriteAllLines(filePath, lines);
                MessageBox.Show("Salary data updated successfully.");
            }
            else
            {
                saveSalary();
            }
        }

        private void saveSalary()
        {
            string filePath = "salaries.csv"; // Dosya yolu

            var data = new List<string>
            {
                phoneNumber,
                deneyimComboBox.SelectedItem?.ToString() ?? "",
                yasanilanSehirComboBox.SelectedItem?.ToString() ?? "",
                ustOgrenimComboBox.SelectedItem?.ToString() ?? "",
                yoneticilikComboBox.SelectedItem?.ToString() ?? "",
                esDurumuComboBox.Checked.ToString(),
                cocuk0_6.Value.ToString(),
                cocuk7_18.Value.ToString(),
                cocuk18.Value.ToString(),
                belgeliIngilizceCheckBox.Checked.ToString(),
                ingilizceOkulCheckBox.Checked.ToString(),
                digerYabanciDilSayisi.Value.ToString()
            };

            File.AppendAllLines(filePath, new[] { string.Join(",", data) });
            MessageBox.Show("Salary data saved successfully.");
        }

        private void SalaryCalculatorForm_Load(object sender, EventArgs e)
        {
            if (!File.Exists("salaries.csv"))
            {
                File.Create("salaries.csv").Close();
            }
            loadSalary();
            maasLabel.Text = "Maaş: " + Environment.NewLine + maasHesapla().ToString() + "TL";
        }

        private void deneyimComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
