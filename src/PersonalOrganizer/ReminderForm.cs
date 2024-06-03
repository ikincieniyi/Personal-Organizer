using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PersonalOrganizer
{
    public partial class ReminderForm : Form
    {
        public ReminderForm()
        {
            InitializeComponent();
        }

        abstract class Reminder
        {
            public DateTime DateTime { get; set; }
            public string Summary { get; set; }
            public string Description { get; set; }

            protected Reminder(DateTime dateTime, string summary, string description)
            {
                DateTime = dateTime;
                Summary = summary;
                Description = description;
            }

            public abstract void Notify();

            public virtual string ToCsvString()
            {
                return $"{DateTime},{Summary},{Description}";
            }

            public static Reminder FromCsvString(string csv)
            {
                string[] parts = csv.Split(',');
                DateTime dateTime = DateTime.Parse(parts[0]);
                string summary = parts[1];
                string description = parts[2];
                return null; // Return appropriate reminder based on summary (MeetingReminder or TaskReminder)
            }
        }

        class MeetingReminder : Reminder
        {
            public MeetingReminder(DateTime dateTime, string summary, string description)
                : base(dateTime, summary, description) { }

            public override void Notify()
            {
                // Implementation for meeting reminder notification
            }
        }

        class TaskReminder : Reminder
        {
            public TaskReminder(DateTime dateTime, string summary, string description)
                : base(dateTime, summary, description) { }

            public override void Notify()
            {
                // Implementation for task reminder notification
            }
        }

        interface IReminderFactory
        {
            Reminder CreateReminder(DateTime dateTime, string summary, string description);
        }

        class MeetingReminderFactory : IReminderFactory
        {
            public Reminder CreateReminder(DateTime dateTime, string summary, string description)
            {
                return new MeetingReminder(dateTime, summary, description);
            }
        }

        class TaskReminderFactory : IReminderFactory
        {
            public Reminder CreateReminder(DateTime dateTime, string summary, string description)
            {
                return new TaskReminder(dateTime, summary, description);
            }
        }


        class ReminderManager
        {
            private List<Reminder> reminders = new List<Reminder>();
            private string remindersFilePath = "reminders.csv";

            public void LoadReminders()
            {
                if (File.Exists(remindersFilePath))
                {
                    string[] lines = File.ReadAllLines(remindersFilePath);
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

            public void SaveReminders()
            {
                List<string> lines = new List<string>();
                foreach (Reminder reminder in reminders)
                {
                    lines.Add(reminder.ToCsvString());
                }
                File.WriteAllLines(remindersFilePath, lines);
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

            public List<Reminder> ListReminders()
            {
                return new List<Reminder>(reminders);
            }
        }


        class ReminderNotifier
        {
            public void OnReminderDue(Reminder reminder)
            {
                // Display the reminder summary in the window header
                Console.Title = reminder.Summary;

                // Simulate window shaking
                for (int i = 0; i < 10; i++)
                {
                    Console.SetWindowPosition(Console.WindowLeft + 1, Console.WindowTop);
                    Thread.Sleep(100);
                    Console.SetWindowPosition(Console.WindowLeft - 1, Console.WindowTop);
                    Thread.Sleep(100);
                }

                reminder.Notify();
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
