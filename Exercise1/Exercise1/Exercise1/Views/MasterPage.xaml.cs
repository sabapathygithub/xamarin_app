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
    public partial class MasterPage : ContentPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }        
    }

    public class MasterPageItem
    {
        public string Title { get; set; }

        public string Icon { get; set; }

        public Type TargetType { get; set; }
    }
}