using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Exercise2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class DatabindingPage : ContentPage
    {
        string[] quotes = new string[3]
       {
            "I measure the progress of a community by the degree of progress which women have achieved.",
            "You cannot expect any rational thought from a religious man. He is like a rocking log in water.",
            "The relationship between husband and wife should be one of closest friends."
       };

        int currentQuote = 0;

        public DatabindingPage()
        {
            InitializeComponent();
            DisplayQuote();
        }

        private void Next_Clicked(object sender, EventArgs e)
        {
            DisplayQuote();
        }

        private void DisplayQuote()
        {
            QuoteLabel.Text = quotes[currentQuote];
            currentQuote++;
            if (currentQuote >= quotes.Length)
                currentQuote = 0;
        }
    }
}