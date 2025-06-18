using Microsoft.Maui.Controls;
using System;
using System.IO;

namespace GuevaraGCreacionAppApuntes.Views
{
    public partial class NotePage : ContentPage
    {
        string _fileName = Path.Combine(FileSystem.AppDataDirectory, "notes.txt");
        public NotePage()
        {
            InitializeComponent();

            string appDataPath = FileSystem.AppDataDirectory;
            string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";

            LoadNote(Path.Combine(appDataPath, randomFileName));
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            File.WriteAllText(_fileName, TextEditor.Text);
        }

        private void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (File.Exists(_fileName))
                File.Delete(_fileName);

            TextEditor.Text = string.Empty;
        }

        private void LoadNote(string _fileName)
        {
            Models.Note noteModel = new Models.Note();
            noteModel.Filename = _fileName;

            if (File.Exists(_fileName))
            {
                noteModel.Date = File.GetCreationTime(_fileName);
                noteModel.Text = File.ReadAllText(_fileName);
            }

            BindingContext = noteModel;
        }
    }
}