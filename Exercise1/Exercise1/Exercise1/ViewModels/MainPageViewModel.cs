using Exercise1.Models;
using Exercise1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Exercise1.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public MainPageViewModel()
        {
            List<Note> notesList = App.Database.GetNotesAsync().Result;
            foreach (var note in notesList)
            {
                notes.Add(note);
            }
            EraseCommand = new Command(() => {
                Note = string.Empty;
            });

            SaveCommand = new Command(async () => {
                Note note = new Note() { Text = Note, Date = DateTime.Now };
                Notes.Add(note);
                await App.Database.SaveNoteAsync(note);
                Note = string.Empty;
            });

            SelectionChangedCommand = new Command(async () => {
                var detailVM = new DetailPageViewModel(SelectedNote);

                var detailView = new DetailPage();
                detailView.BindingContext = detailVM;
                await Application.Current.MainPage.Navigation.PushAsync(detailView);
            });
        }

        private ObservableCollection<Note> notes = new ObservableCollection<Note>();

        public ObservableCollection<Note> Notes
        {
            get { return notes; }
            set { notes = value; }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        private string note;

        public string Note
        {
            get { return note; }
            set
            {
                note = value;
                var args = new PropertyChangedEventArgs(nameof(Note));

                PropertyChanged?.Invoke(this, args);
            }
        }

        private Note selectedNote;

        public Note SelectedNote
        {
            get { return selectedNote; }
            set { selectedNote = value; }
        }


        public Command SaveCommand { get; }
        public Command EraseCommand { get; }

        public Command SelectionChangedCommand { get; }

    }
}
