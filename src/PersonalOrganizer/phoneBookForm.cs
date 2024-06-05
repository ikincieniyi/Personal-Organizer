using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalOrganizer
{
    public partial class phoneBookForm : Form
    {
        string phoneBookDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "phoneBooks");
        string phoneNumber = "";

        public phoneBookForm(string phone)
        {
            InitializeComponent();
            phoneNumber = phone;
        }

        private void kayitButton_Click(object sender, EventArgs e)
        {
            bool checkInformation = checkUserInformations(isimTextBox.Text, soyisimTextBox.Text, adresTextBox.Text, telNoTextBox.Text, epostaTextBox.Text);
            if (checkInformation)
            {
                saveUser(isimTextBox.Text, soyisimTextBox.Text, adresTextBox.Text, telNoTextBox.Text, epostaTextBox.Text);
            }
        }

        public void saveUser(string Isim, string Soyisim, string Adres, string Telefon, string Mail)
        {
            if (!Directory.Exists(phoneBookDirectory))
            {
                Directory.CreateDirectory(phoneBookDirectory);
            }
            string filePath = Path.Combine(phoneBookDirectory, $"{phoneNumber}.csv");
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{Isim},{Soyisim},{Adres},{Telefon},{Mail}");
            }
            LoadUserInformation();
        }

        //check if the user informations are valid
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

        private void LoadUserInformation()
        {
            if (!Directory.Exists(phoneBookDirectory))
            {
                Directory.CreateDirectory(phoneBookDirectory);
            }
            string filePath = Path.Combine(phoneBookDirectory, $"{phoneNumber}.csv");
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }

            listView1.Clear();

            // Add columns to the ListView
            listView1.View = View.Details;
            listView1.Columns.Add("First Name", 100);
            listView1.Columns.Add("Last Name", 100);
            listView1.Columns.Add("Location", 150);
            listView1.Columns.Add("Phone", 100);
            listView1.Columns.Add("Email", 150);

            var lines = File.ReadAllLines(filePath);

            // Add data to the ListView
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                ListViewItem item = new ListViewItem(parts);
                listView1.Items.Add(item);
            }
        }

        // Delete a user entry
        public void DeleteUser(string phoneNumber, string firstName, string lastName)
        {
            string filePath = Path.Combine(phoneBookDirectory, $"{phoneNumber}.csv");
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                var remainingLines = lines.Where(line => !line.StartsWith($"{firstName},{lastName},"));
                File.WriteAllLines(filePath, remainingLines);
            }
        }


        // Update a user entry
        public void UpdateUser(string phoneNumber, string oldFirstName, string oldLastName, string newFirstName, string newLastName, string newAddress, string newTelephone, string newEmail)
        {
            string filePath = Path.Combine(phoneBookDirectory, $"{phoneNumber}.csv");
            if (File.Exists(filePath))
            {
                var lines = File.ReadAllLines(filePath);
                var updatedLines = new List<string>();
                foreach (var line in lines)
                {
                    if (line.StartsWith($"{oldFirstName},{oldLastName},"))
                    {
                        // Replace the old entry with the updated one
                        updatedLines.Add($"{newFirstName},{newLastName},{newAddress},{newTelephone},{newEmail}");
                    }
                    else
                    {
                        updatedLines.Add(line);
                    }
                }
                File.WriteAllLines(filePath, updatedLines);
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string firstName = selectedItem.SubItems[0].Text;
                string lastName = selectedItem.SubItems[1].Text;
                DeleteUser(phoneNumber, firstName, lastName);
                LoadUserInformation(); // Reload the ListView after deletion
            }
            else
            {
               MessageBox.Show("Please select a user to delete.");
            }
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 1)
            {
                ListViewItem selectedItem = listView1.SelectedItems[0];
                string oldFirstName = selectedItem.SubItems[0].Text;
                string oldLastName = selectedItem.SubItems[1].Text;
                UpdateUser(phoneNumber, oldFirstName, oldLastName, isimTextBox.Text, soyisimTextBox.Text, adresTextBox.Text, telNoTextBox.Text, epostaTextBox.Text);
                LoadUserInformation(); // Reload the ListView after updating
            }
            else
            {
                MessageBox.Show("Please select a user to update.");
            }
        }

        private void phoneBookForm_Load(object sender, EventArgs e)
        {
            LoadUserInformation();
        }

        private void listButton_Click(object sender, EventArgs e)
        {
            LoadUserInformation();
        }
    }

}
