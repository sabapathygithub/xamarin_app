using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Exercise2
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : MasterDetailPage
    {

        public MainPage()
        {
            InitializeComponent();
            MenuList.ItemSelected += MenuList_ItemSelected;
        }

        private void MenuList_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var selectedMenu = e.SelectedItem as MasterPageItem;
            if(selectedMenu != null)
            {
                var page = (Page)Activator.CreateInstance(selectedMenu.TargetType);
                page.Title = selectedMenu.Title;
                Detail = new NavigationPage(page);
                MenuList.SelectedItem = null;
                IsPresented = false;
            }
        }
    }

    public class MasterPageItem
    {
        public string Title { get; set; }

        public Type TargetType { get; set; }
    }
}
