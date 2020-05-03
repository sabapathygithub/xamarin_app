using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Xamarin.Forms;

namespace Exercise1.ViewModels
{
    public class DetailPageViewModel : INotifyPropertyChanged
    {

        public DetailPageViewModel(Note note)
        {
            Note = note;
            DismissCommand = new Command(async () => {
                await Application.Current.MainPage.Navigation.PopAsync();
            });
        }

        public event PropertyChangedEventHandler PropertyChanged;


        private Note note;

        public Note Note
        {
            get { return note; }
            set { note = value; }
        }

        public Command DismissCommand { get; }
    }
}
