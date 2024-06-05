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
    public partial class AdminForm : Form
    {
        string[] user;
        string userPhone = "";
        public AdminForm(string[] user)
        {
            InitializeComponent();
            this.userPhone = user[4];
            this.user = user;
        }

        private void LoadUserInformation()
        {
            string csvFilePath = "users.csv";

            if (!File.Exists(csvFilePath))
            {
                MessageBox.Show("CSV file not found.");
                return;
            }

            listView1.Clear();

            // Add columns to the ListView
            listView1.View = View.Details;
            listView1.Columns.Add("First Name", 100);
            listView1.Columns.Add("Last Name", 100);
            listView1.Columns.Add("Location", 150);
            listView1.Columns.Add("ID", 80);
            listView1.Columns.Add("Phone", 100);
            listView1.Columns.Add("Email", 150);
            listView1.Columns.Add("Role", 80);

            var lines = File.ReadAllLines(csvFilePath);

            // Add data to the ListView
            foreach (string line in lines)
            {
                string[] parts = line.Split(',');
                ListViewItem item = new ListViewItem(parts);
                listView1.Items.Add(item);
            }
        }

        private void UpdateUserTypeByPhoneNumber(string phoneNumber, string newUserType)
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

                // If the phoneNumber matches, update the userType
                if (parts.Length > 4 && parts[4] == phoneNumber) // Assuming phoneNumber is at index 4
                {
                    parts[6] = newUserType; // Assuming userType is at index 6
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


        private void AdminForm_Load(object sender, EventArgs e)
        {
            LoadUserInformation();
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
            {
                MessageBox.Show("Please select a user to update.");
                return;
            }
            if(listView1.SelectedItems.Count > 1)
            {
                MessageBox.Show("Please select only one user to update.");
                return;
            }
            if(yeniRolComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a role to update.");
                return;
            }

            string phoneNumber = listView1.SelectedItems[0].SubItems[4].Text;
            string newUserType = yeniRolComboBox.SelectedItem.ToString();

            UpdateUserTypeByPhoneNumber(phoneNumber, newUserType);
            LoadUserInformation();

        }

        private void kullanıcıButton_Click(object sender, EventArgs e)
        {
            UserForm userForm = new UserForm(user);
            userForm.Show();

        }
    }
}
