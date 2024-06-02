using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalOrganizer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void SingInQButton_Click(object sender, EventArgs e)
        {
            KayitOlgb.Visible = true;
            KayitOlgb.Enabled = true;
        }

        private void kayitButton_Click(object sender, EventArgs e)
        {
            bool checkInformation = checkUserInformations(isimTextBox.Text, soyisimTextBox.Text, adresTextBox.Text, sifreTextBox.Text, sifreTekrarTextBox.Text, telNoTextBox.Text, epostaTextBox.Text);
            if(checkInformation)
            {
                //add user to database
                //if the user is added successfully
                MessageBox.Show("Kayıt başarılı.");
                KayitOlgb.Visible = false;
                KayitOlgb.Enabled = false;
            }
        }


        //check if the user informations are valid
        public bool checkUserInformations(string Isim, string Soyisim, string Adres, string Sifre, string SifreTekrar, string Telefon, string Mail)
        {
            if(Isim == "" || Soyisim == "" || Adres == "" || Sifre == "" || SifreTekrar == "" || Telefon == "" || Mail == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
                return false;
            }
            else if (Sifre != SifreTekrar)
            {
                MessageBox.Show("Şifreler uyuşmuyor.");
                return false;
            }
            //check if the name is valid it only should contain letters
            else if (!Isim.All(char.IsLetter) || Isim.Length < 2 || Isim.Length > 50)
            {
                MessageBox.Show("İsim hatalı." + Environment.NewLine +
                    "İsim 2-50 karakter arasında olmalıdır ve sadece harflerden oluşmalıdır");
                return false;
            }
            //check if the surname is valid it only should contain letters
            else if (!Soyisim.All(char.IsLetter) || Soyisim.Length < 2 || Soyisim.Length > 50)
            {
                MessageBox.Show("Soyisim hatalı." + Environment.NewLine +
                    "Soyisim 2-50 karakter arasında olmalıdır ve sadece harflerden oluşmalıdır");
                return false;
            }
            //check if the address is valid
            else if (Adres.Length < 10 || Adres.Length > 200)
            {
                MessageBox.Show("Adres hatalı." + Environment.NewLine +
                    "Adres 10-200 karakter arasında olmalıdır.");
                return false;
            }
            //check if the password is valid
            else if (Sifre.Length < 6 || Sifre.Length > 20)
            {
                MessageBox.Show("Şifre hatalı." + Environment.NewLine +
                    "Şifre 6-20 karakter arasında olmalıdır.");
                return false;
            }
            //check if the telephone number is like 5XX XXX XX XX and it should not contain any space and only contains numbers
            else if (!Telefon.All(char.IsDigit) || Telefon.Length != 10 || Telefon[0] != '5')
            {
                MessageBox.Show("Telefon numarası hatalı." + Environment.NewLine +
                    "Telefon numarası 5XX XXX XX XX şeklinde olmalıdır.");
                return false;
            }
            //check if the mail is valid with regex
            else if (!System.Text.RegularExpressions.Regex.IsMatch(epostaTextBox.Text, @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$"))
            {
                MessageBox.Show("E-posta adresi hatalı.");
                return false;
            }

            return true;
            

        }

        private void girisYapButton_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalaryCalculatorForm salaryCalculatorForm = new SalaryCalculatorForm();
            salaryCalculatorForm.Show();

        }
    }
}
