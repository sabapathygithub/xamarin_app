using Exercise1.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Exercise1.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NoteList : ContentPage
    {
        public NoteList()
        {
            BindingContext = new NoteListViewModel(new PageService());
            InitializeComponent();
        }

        async void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            string action = await DisplayActionSheet("Share to?", "Cancel", null, "Email", "WhatsApp", "Facebook");
            Console.WriteLine("Action :" + action);
        }

        private void ListView_Refreshing(object sender, EventArgs e)
        {
            listview.EndRefresh();
        }

        private void addtask_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NoteEntryPage() {BindingContext = this.BindingContext });
        }

        private void MenuItem_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new NoteEntryPage() { BindingContext = this.BindingContext });
        }
    }
}