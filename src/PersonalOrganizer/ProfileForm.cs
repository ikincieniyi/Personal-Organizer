using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PersonalOrganizer
{
    public partial class ProfileForm : Form
    {
        string phoneNumber = "";

        public ProfileForm(string[] user)
        {
            InitializeComponent();
            phoneNumber = user[4];
        }

        public bool checkUserInformations(string Isim, string Soyisim, string Adres, string Telefon, string Mail)
        {
            if (Isim == "" || Soyisim == "" || Adres == "" || Telefon == "" || Mail == "")
            {
                MessageBox.Show("Lütfen tüm alanları doldurunuz.");
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

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (!checkUserInformations(isimTextBox.Text, soyisimTextBox.Text, adresTextBox.Text, telNoTextBox.Text, epostaTextBox.Text))
            {
                return;
            }

            UpdateUserByPhoneNumber(phoneNumber);
            MessageBox.Show("User updated successfully.");
        }

        private void UpdateUserByPhoneNumber(string phoneNumber)
        {
            string csvFilePath = "users.csv";

            if (!File.Exists(csvFilePath))
            {
                MessageBox.Show("CSV file not found.");
                return;
            }

            // Read all lines from the CSV file
            var lines = File.ReadAllLines(csvFilePath);
            List<string> newLines = new List<string>();
            bool updated = false;

            // Loop through each line
            foreach (string line in lines)
            {
                // Split the line into parts
                string[] parts = line.Split(',');

                // If the phoneNumber matches, update the user
                if (parts.Length > 4 && parts[4] == phoneNumber) // Assuming phoneNumber is at index 4
                {
                    parts[0] = isimTextBox.Text;
                    parts[1] = soyisimTextBox.Text;
                    parts[2] = adresTextBox.Text;
                    parts[5] = epostaTextBox.Text;
                    updated = true;
                }

                // Join the parts back into a line and add it to the new lines
                newLines.Add(string.Join(",", parts));
            }

            // If the userType was updated, write the new lines back to the CSV file
            if (updated)
            {
                File.WriteAllLines(csvFilePath, newLines.ToArray());
            }
            else
            {
                MessageBox.Show("User with the specified phone number not found.");
            }
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            //find user via phone number from users.csv
            string[] user = FindUserByPhone(phoneNumber);


            isimTextBox.Text = user[0];
            soyisimTextBox.Text = user[1];
            adresTextBox.Text = user[2];
            telNoTextBox.Text = user[4];
            epostaTextBox.Text = user[5];
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
    }
}
