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
    public partial class WeatherPage : ContentPage
    {
        RestServiceClient _restServiceClient;
        public WeatherPage()
        {
            InitializeComponent();
            _restServiceClient = new RestServiceClient();
        }

        async void Button_Clicked(object sender, EventArgs e)
        {
            if(!string.IsNullOrWhiteSpace(cityEntry.Text))
            { 
                var weatherData = await _restServiceClient.GetWeatherDataAsync(GenerateRequestUri(Constants.OpenWeatherMapEndpoint));
                this.BindingContext = weatherData;
            }
        }

        string GenerateRequestUri(string endpoint)
        {
            string requestUri = endpoint;
            requestUri += $"?q={cityEntry.Text}";
            requestUri += "&units=imperial"; // or units=metric
            requestUri += $"&APPID={Constants.OpenWeatherMapAPIKey}";
            return requestUri;
        }
    }
}