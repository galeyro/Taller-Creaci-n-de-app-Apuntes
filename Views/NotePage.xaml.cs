using Microsoft.Maui.Controls;
using System;
using System.IO;

namespace GuevaraGCreacionAppApuntes.Views
{
    [QueryProperty(nameof(ItemId), nameof(ItemId))]
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
        public string ItemId
        {
            set { LoadNote(value); }
        }

        private async void SaveButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is Models.Note note)
                File.WriteAllText(note.Filename, TextEditor.Text);

            await Shell.Current.GoToAsync("..");
        }

        private async void DeleteButton_Clicked(object sender, EventArgs e)
        {
            if (BindingContext is Models.Note note)
            {
                // Delete the file.
                if (File.Exists(note.Filename))
                    File.Delete(note.Filename);
            }

            await Shell.Current.GoToAsync("..");
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