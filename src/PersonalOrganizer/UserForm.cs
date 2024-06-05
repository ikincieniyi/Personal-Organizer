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
    public partial class UserForm : Form
    {
        public static string userPhoneNumber = "";
        string[] user;

        public UserForm(string[] user)
        {
            InitializeComponent();
            userPhoneNumber = user[4];
            this.user = user;
        }

        private void notesButton_Click(object sender, EventArgs e)
        {
            notesForm notesForm = new notesForm();
            notesForm.Show();
        }

        private void personalInformationButton_Click(object sender, EventArgs e)
        {
            ProfileForm profileForm = new ProfileForm(user);
            profileForm.Show();
        }

        private void salaryCalculatorButton_Click(object sender, EventArgs e)
        {
            SalaryCalculatorForm salaryCalculatorForm = new SalaryCalculatorForm(userPhoneNumber);
            salaryCalculatorForm.Show();
        }


        private void phonebookButton_Click(object sender, EventArgs e)
        {
            phoneBookForm phoneBookForm = new phoneBookForm(userPhoneNumber);
            phoneBookForm.Show();
        }

        private void reminderButton_Click(object sender, EventArgs e)
        {
            ReminderForm reminderForm = new ReminderForm(userPhoneNumber);
            reminderForm.Show();
        }
    }
}
