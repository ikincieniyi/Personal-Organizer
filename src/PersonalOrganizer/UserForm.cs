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

        public UserForm(string[] user)
        {
            InitializeComponent();
            userPhoneNumber = user[4];
        }

        private void notesButton_Click(object sender, EventArgs e)
        {
            notesForm notesForm = new notesForm();
            notesForm.Show();
        }

        private void personalInformationButton_Click(object sender, EventArgs e)
        {

        }

        private void salaryCalculatorButton_Click(object sender, EventArgs e)
        {

        }
    }
}
