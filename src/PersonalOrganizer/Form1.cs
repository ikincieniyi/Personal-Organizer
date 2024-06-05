using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PersonalOrganizer
{
    public partial class Form1 : Form
    {
        string stdUser = "user";
        public string exeDirectory = AppDomain.CurrentDomain.BaseDirectory;
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
                bool isUserSaveSucceed = saveUser(isimTextBox.Text, soyisimTextBox.Text, adresTextBox.Text, sifreTextBox.Text, telNoTextBox.Text, epostaTextBox.Text, stdUser);
                if (isUserSaveSucceed)
                {
                    MessageBox.Show("Kayıt başarılı.");
                    KayitOlgb.Visible = false;
                    KayitOlgb.Enabled = false;
                }
                else
                {
                    MessageBox.Show("Kullanıcı zaten kayıtlı.");
                }
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

        public bool saveUser(string Isim, string Soyisim, string Adres, string Sifre, string Telefon, string Mail, string userType)
        {
            // Check if user already exists
            if (FindUserByPhone(Telefon) != null)
            {
                return false; // User already exists
            }

            // Check if it's the first user being registered
            bool isFirstUser = !File.Exists(exeDirectory + "users.csv") || new FileInfo(exeDirectory + "users.csv").Length == 0;

            // Add this user to a csv file named users.csv
            using (StreamWriter sw = new StreamWriter(exeDirectory + "users.csv", true))
            {
                if (isFirstUser)
                {
                    sw.WriteLine($"{Isim},{Soyisim},{Adres},{Sifre},{Telefon},{Mail},admin");
                }
                else
                {
                    sw.WriteLine($"{Isim},{Soyisim},{Adres},{Sifre},{Telefon},{Mail},{userType}");
                }
            }
            return true;
        }




        private void girisYapButton_Click(object sender, EventArgs e)
        {
            string[] user = FindUserByPhone(girisTelNoTextBox.Text);
            if (user == null)
            {
                MessageBox.Show("Kullanıcı bulunamadı.");
                return;
            }
            string userPhone = user[4];
            string userPassword = user[3];
            string userType = user[6];
            if (userPassword != girisSifreTextBox.Text)
            {
                MessageBox.Show("Şifre hatalı.");
            }
            else
            {
                if (userType.ToLower() == "admin")
                {
                    // If the user is an admin
                    AdminForm adminForm = new AdminForm(user);
                    adminForm.Show();
                }
                else
                {
                    // If the user is not an admin
                    UserForm userForm = new UserForm(user);
                    userForm.Show();
                }
            }
        }

        static string[] FindUserByPhone(string phoneNumber)
        {
            try
            {
                if (!File.Exists(AppDomain.CurrentDomain.BaseDirectory + "users.csv"))
                {
                    File.Create(AppDomain.CurrentDomain.BaseDirectory + "users.csv").Close();
                }
                string[] lines = File.ReadAllLines(AppDomain.CurrentDomain.BaseDirectory + "users.csv");
                foreach (string line in lines)
                {
                    string[] parts = line.Split(',');
                    if (parts.Length >= 7 && parts[4] == phoneNumber) // Ensure there are at least 7 parts and check phone
                    {
                        return parts;
                    }
                }
                return null;
            }
            catch (Exception e)
            {
                MessageBox.Show("Kullanıcılar dosyası bulunamadı.");
                return null;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SalaryCalculatorForm salaryCalculatorForm = new SalaryCalculatorForm("5389371723");
            salaryCalculatorForm.Show();
        }
    }
}
