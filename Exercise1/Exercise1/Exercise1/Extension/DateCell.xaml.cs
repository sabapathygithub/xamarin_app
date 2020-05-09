using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Exercise1.Extension
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DateCell : ViewCell
    {
        private static readonly BindableProperty LabelProperty = BindableProperty.Create("Label", typeof(string), typeof(DateCell));     
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public DateCell()
        {
            InitializeComponent();
            BindingContext = this;
        }
    }
}