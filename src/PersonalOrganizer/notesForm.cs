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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace PersonalOrganizer
{
    public partial class notesForm : Form
    {
        string notesDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "notes");
        string phoneNumber = UserForm.userPhoneNumber;
        Dictionary<string, string> notes;

        public notesForm()
        {
            InitializeComponent();
        }



        private void addNoteButton_Click(object sender, EventArgs e)
        {
            if(addNoteTitleTextBox.Text == "" || noteAdderTextBox.Text == "")
            {
                MessageBox.Show("Başlık ve not alanları boş bırakılamaz.");
                return;
            }
            AddNote(phoneNumber, addNoteTitleTextBox.Text, noteAdderTextBox.Text, notesDirectory);
            noteSelecterComboBox.Items.Add(addNoteTitleTextBox.Text);
            notes.Add(addNoteTitleTextBox.Text, noteAdderTextBox.Text);
            //clear the textboxes
            addNoteTitleTextBox.Text = "";
            noteAdderTextBox.Text = "";
        }

        private void noteSelecterComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            //find the note from the notes dictionary and display it in the noteViewerTextBox
            if (noteSelecterComboBox.SelectedIndex == -1)
            {
                return;
            }
            noteViewerTextBox.Text = notes[noteSelecterComboBox.SelectedItem.ToString()];
        }

        static void AddNote(string phoneNumber, string title, string content, string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string filePath = Path.Combine(directory, $"{phoneNumber}.csv");
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            using (StreamWriter sw = new StreamWriter(filePath, true))
            {
                sw.WriteLine($"{title},{content}");
            }
        }

        static void EditNote(string phoneNumber, string title, string newContent, string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string filePath = Path.Combine(directory, $"{phoneNumber}.csv");
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            var allLines = new List<string>();
            bool noteFound = false;

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts[0] == title)
                        {
                            line = $"{title},{newContent}";
                            noteFound = true;
                        }
                        allLines.Add(line);
                    }
                }

                if (noteFound)
                {
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        foreach (var line in allLines)
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }
        }

        static void DeleteNote(string phoneNumber, string title, string directory)
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            string filePath = Path.Combine(directory, $"{phoneNumber}.csv");
            if (!File.Exists(filePath))
            {
                File.Create(filePath).Close();
            }
            var allLines = new List<string>();
            bool noteFound = false;

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts[0] == title)
                        {
                            noteFound = true;
                            continue; // Skip the line with the note to be deleted
                        }
                        allLines.Add(line);
                    }
                }

                if (noteFound)
                {
                    using (StreamWriter sw = new StreamWriter(filePath))
                    {
                        foreach (var line in allLines)
                        {
                            sw.WriteLine(line);
                        }
                    }
                }
            }
        }

        static Dictionary<string, string> ReadNotes(string phoneNumber, string directory)
        {
            string filePath = Path.Combine(directory, $"{phoneNumber}.csv");
            var notes = new Dictionary<string, string>();

            if (File.Exists(filePath))
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        string[] parts = line.Split(',');
                        if (parts.Length >= 2)
                        {
                            notes[parts[0]] = parts[1];
                        }
                    }
                }
            }
            return notes;
        }

        private void deleteNoteButton_Click(object sender, EventArgs e)
        {
            if(noteSelecterComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Silinecek notu seçiniz.");
                return;
            }
            DeleteNote(phoneNumber, noteSelecterComboBox.SelectedItem.ToString(), notesDirectory);
            noteSelecterComboBox.Items.Remove(noteSelecterComboBox.SelectedItem);
            notes.Remove(noteSelecterComboBox.SelectedItem.ToString());
            noteViewerTextBox.Text = "";

        }

        private void updateNoteButton_Click(object sender, EventArgs e)
        {
            if(noteSelecterComboBox.SelectedIndex == -1)
            {
                MessageBox.Show("Güncellenecek notu seçiniz.");
                return;
            }
            EditNote(phoneNumber, noteSelecterComboBox.SelectedItem.ToString(), noteViewerTextBox.Text, notesDirectory);
            notes[noteSelecterComboBox.SelectedItem.ToString()] = noteViewerTextBox.Text;

        }

        private void notesForm_Load(object sender, EventArgs e)
        {
            noteSelecterComboBox.Items.Clear();
            notes = ReadNotes(phoneNumber, notesDirectory);
            foreach (var note in notes)
            {
                noteSelecterComboBox.Items.Add(note.Key);
            }
        }
    }
}
