using Exercise1.Models;
using Exercise1.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;
using System.Linq;

namespace Exercise1.ViewModels
{
    public class NoteListViewModel: INotifyPropertyChanged
    {
        private List<Note> _notesList;
        public NoteListViewModel()
        {
            GetData();
            EraseCommand = new Command(() => {
                Note = string.Empty;
            });

            SaveCommand = new Command(async (parameter) => {                
                if (SaveText.Equals("Save"))
                {
                    Note note = new Note() { Text = Note, Date = DateTime.Now };
                    Notes.Add(note);
                    await App.Database.SaveNoteAsync(note);
                    Note = string.Empty;
                }
                else if(SelectedNote != null)
                {
                    int currentIndex = Notes.IndexOf(SelectedNote);
                    Notes.Remove(SelectedNote);                    
                    Note note = new Note() { Text = Note, Date = DateTime.Now, ID = SelectedNote.ID };
                    await App.Database.SaveNoteAsync(note);
                    Notes.Insert(currentIndex, note);
                    SelectedNote = null;
                    Note = string.Empty;
                    SaveText = "Save";
                }
                if (parameter != null)
                {
                    var page = parameter as ContentPage;
                    await page.Navigation.PopModalAsync();
                }
            });

            SelectionChangedCommand = new Command(async () => {
                var detailVM = new DetailPageViewModel(SelectedNote);

                var detailView = new DetailPage();
                detailView.BindingContext = detailVM;
                await Application.Current.MainPage.Navigation.PushAsync(detailView);
            });

            DeleteCommand = new Command(async (parameter) => { 
                if(parameter != null)
                {
                    Note currentNote = (parameter as Note);
                    SelectedNote = currentNote;
                    Notes.Remove(currentNote);
                    await App.Database.DeleteNoteAsync(currentNote);
                }
            });

            EditCommand = new Command((parameter) => { 
                if(parameter != null)
                {
                    Note currentNote = (parameter as Note);
                    SelectedNote = currentNote;
                    Note = currentNote.Text;
                    SaveText = "Update";                    
                }
            });

            SearchCommand = new Command((parameter) => {
                var textchanged = parameter as TextChangedEventArgs;
                if(textchanged != null)
                {
                    Notes.Clear();
                    foreach(var note in _notesList.Where(i=> i.Text.StartsWith(textchanged.NewTextValue)))
                    {
                        Notes.Add(note);
                    }
                }
            });
        }

        private async void GetData()
        {
            _notesList = await App.Database.GetNotesAsync();
            foreach (var note in _notesList)
            {
                notes.Add(note);
            }
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

        private string saveText = "Save";

        public string SaveText
        {
            get { return saveText; }
            set { saveText = value;
                var args = new PropertyChangedEventArgs(nameof(SaveText));

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

        public Command DeleteCommand { get; }

        public Command EditCommand { get; }

        public Command SearchCommand { get; }
    }
}
