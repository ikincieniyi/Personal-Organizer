using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonalOrganizer
{
    public partial class ReminderForm : Form
    {
        private string phoneNumber;
        private ReminderManager reminderManager;
        private ReminderService reminderService;
        private System.Windows.Forms.Timer reminderCheckTimer;

        public ReminderForm(string phoneNumber)
        {
            InitializeComponent();
            this.phoneNumber = phoneNumber;
            reminderManager = new ReminderManager();
            reminderService = new ReminderService();

            // Load reminders from file
            reminderManager.LoadReminders(phoneNumber);
            foreach (var reminder in reminderManager.ListReminders(phoneNumber))
            {
                reminderService.AddReminder(reminder);
            }

            UpdateReminderList();

            // Set up a timer to check for due reminders every minute
            reminderCheckTimer = new System.Windows.Forms.Timer();
            reminderCheckTimer.Interval = 60000; // 1 minute
            reminderCheckTimer.Tick += ReminderCheckTimer_Tick;
            reminderCheckTimer.Start();
        }

        private void ReminderCheckTimer_Tick(object sender, EventArgs e)
        {
            reminderService.CheckReminders();
        }

        private void UpdateReminderList()
        {
            listBoxReminders.Items.Clear();
            var reminders = reminderManager.ListReminders(phoneNumber);
            foreach (var reminder in reminders)
            {
                listBoxReminders.Items.Add($"{reminder.DateTime} - {reminder.Summary}");
            }
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            if(dateTimePicker.Value < DateTime.Now)
            {
                MessageBox.Show("Please select a future date and time.");
                return;
            }
            if(textBoxSummary.Text == "")
            {
                MessageBox.Show("Please enter a summary.");
                return;
            }
            if(textBoxDescription.Text == "")
            {
                MessageBox.Show("Please enter a description.");
                return;
            }
            if(reminderTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a reminder type.");
                return;
            }



            DateTime dateTime = dateTimePicker.Value;
            string summary = textBoxSummary.Text;
            string description = textBoxDescription.Text;

            IReminderFactory factory;
            if(reminderTypeComboBox.SelectedItem.ToString() == "Task Reminder")
            {
                factory = new MeetingReminderFactory();
            }
            else
            {
                factory = new TaskReminderFactory();
            }
            var reminder = factory.CreateReminder(phoneNumber, dateTime, summary, description);
            reminderManager.AddReminder(reminder);
            reminderService.AddReminder(reminder);

            UpdateReminderList();
            reminderManager.SaveReminders(phoneNumber);
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            if (reminderTypeComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Please select a reminder type.");
                return;
            }

            int selectedIndex = listBoxReminders.SelectedIndex;
            if (selectedIndex != -1)
            {
                DateTime dateTime = dateTimePicker.Value;
                string summary = textBoxSummary.Text;
                string description = textBoxDescription.Text;
                IReminderFactory factory;
                if (reminderTypeComboBox.SelectedItem.ToString() == "Task Reminder")
                {
                    factory = new MeetingReminderFactory();
                }
                else
                {
                    factory = new TaskReminderFactory();
                }
                var reminder = factory.CreateReminder(phoneNumber, dateTime, summary, description);
                reminderManager.UpdateReminder(selectedIndex, reminder);

                UpdateReminderList();
                reminderManager.SaveReminders(phoneNumber);
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            int selectedIndex = listBoxReminders.SelectedIndex;
            if (selectedIndex != -1)
            {
                reminderManager.DeleteReminder(selectedIndex);

                UpdateReminderList();
                reminderManager.SaveReminders(phoneNumber);
            }
        }

        abstract class Reminder
        {
            public string UserPhoneNumber { get; set; }
            public DateTime DateTime { get; set; }
            public string Summary { get; set; }
            public string Description { get; set; }

            protected Reminder(string userPhoneNumber, DateTime dateTime, string summary, string description)
            {
                UserPhoneNumber = userPhoneNumber;
                DateTime = dateTime;
                Summary = summary;
                Description = description;
            }

            public abstract void Notify();

            public virtual string ToCsvString()
            {
                return $"{GetType().Name},{UserPhoneNumber},{DateTime},{Summary},{Description}";
            }

            public static Reminder FromCsvString(string csv)
            {
                string[] parts = csv.Split(new[] { ',' }, 5);
                string type = parts[0];
                string userPhoneNumber = parts[1];
                DateTime dateTime = DateTime.Parse(parts[2]);
                string summary = parts[3];
                string description = parts[4];

                if (type == nameof(MeetingReminder))
                {
                    return new MeetingReminder(userPhoneNumber, dateTime, summary, description);
                }
                else if (type == nameof(TaskReminder))
                {
                    return new TaskReminder(userPhoneNumber, dateTime, summary, description);
                }
                return null;
            }
        }


        class MeetingReminder : Reminder
        {
            public MeetingReminder(string userPhoneNumber, DateTime dateTime, string summary, string description)
                : base(userPhoneNumber, dateTime, summary, description) { }

            public override void Notify()
            {
                MessageBox.Show($"Meeting Reminder: {Summary}\nDescription: {Description}", "Reminder");
            }
        }

        class TaskReminder : Reminder
        {
            public TaskReminder(string userPhoneNumber, DateTime dateTime, string summary, string description)
                : base(userPhoneNumber, dateTime, summary, description) { }

            public override void Notify()
            {
                MessageBox.Show($"Task Reminder: {Summary}\nDescription: {Description}", "Reminder");
            }
        }


        interface IReminderFactory
        {
            Reminder CreateReminder(string userPhoneNumber, DateTime dateTime, string summary, string description);
        }


        class MeetingReminderFactory : IReminderFactory
        {
            public Reminder CreateReminder(string userPhoneNumber, DateTime dateTime, string summary, string description)
            {
                return new MeetingReminder(userPhoneNumber, dateTime, summary, description);
            }
        }

        class TaskReminderFactory : IReminderFactory
        {
            public Reminder CreateReminder(string userPhoneNumber, DateTime dateTime, string summary, string description)
            {
                return new TaskReminder(userPhoneNumber, dateTime, summary, description);
            }
        }


        class ReminderManager
        {
            private List<Reminder> reminders = new List<Reminder>();
            private string remindersDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "reminders");

            public void LoadReminders(string phoneNumber)
            {
                reminders.Clear();
                string filePath = Path.Combine(remindersDirectory, $"{phoneNumber}.csv");
                if (File.Exists(filePath))
                {
                    string[] lines = File.ReadAllLines(filePath);
                    foreach (string line in lines)
                    {
                        Reminder reminder = Reminder.FromCsvString(line);
                        if (reminder != null)
                        {
                            reminders.Add(reminder);
                        }
                    }
                }
            }

            public void SaveReminders(string phoneNumber)
            {
                if (!Directory.Exists(remindersDirectory))
                {
                    Directory.CreateDirectory(remindersDirectory);
                }
                string filePath = Path.Combine(remindersDirectory, $"{phoneNumber}.csv");
                List<string> lines = new List<string>();
                foreach (Reminder reminder in reminders.Where(r => r.UserPhoneNumber == phoneNumber))
                {
                    lines.Add(reminder.ToCsvString());
                }
                File.WriteAllLines(filePath, lines);
            }

            public void AddReminder(Reminder reminder)
            {
                reminders.Add(reminder);
            }

            public void UpdateReminder(int index, Reminder reminder)
            {
                if (index >= 0 && index < reminders.Count)
                {
                    reminders[index] = reminder;
                }
            }

            public void DeleteReminder(int index)
            {
                if (index >= 0 && index < reminders.Count)
                {
                    reminders.RemoveAt(index);
                }
            }

            public List<Reminder> ListReminders(string phoneNumber)
            {
                return reminders.Where(r => r.UserPhoneNumber == phoneNumber).ToList();
            }
        }


        class ReminderNotifier
        {
            public void OnReminderDue(Reminder reminder)
            {
                reminder.Notify();
                // simulate window shaking
                for (int i = 0; i < 10; i++)
                {
                    if (ReminderForm.ActiveForm != null)
                    {
                        ReminderForm.ActiveForm.Location = new Point(ReminderForm.ActiveForm.Location.X + 1, ReminderForm.ActiveForm.Location.Y);
                        Thread.Sleep(100);
                        ReminderForm.ActiveForm.Location = new Point(ReminderForm.ActiveForm.Location.X - 1, ReminderForm.ActiveForm.Location.Y);
                        Thread.Sleep(100);
                    }
                }
            }
        }

        class ReminderService
        {
            private List<Reminder> reminders = new List<Reminder>();
            private ReminderNotifier notifier = new ReminderNotifier();

            public void AddReminder(Reminder reminder)
            {
                reminders.Add(reminder);
            }

            public void CheckReminders()
            {
                foreach (var reminder in reminders)
                {
                    if (reminder.DateTime <= DateTime.Now)
                    {
                        notifier.OnReminderDue(reminder);
                    }
                }
            }
        }

    }
}
