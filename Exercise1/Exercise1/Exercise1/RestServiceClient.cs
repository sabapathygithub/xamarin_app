using Exercise1.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Diagnostics;

namespace Exercise1
{
    public class RestServiceClient
    {
        HttpClient _client;

        public RestServiceClient()
        {
            _client = new HttpClient();
        }

        public async Task<WeatherData> GetWeatherDataAsync(string uri)
        {
            WeatherData weatherData = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if(response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    weatherData = JsonConvert.DeserializeObject<WeatherData>(content);

                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine("\tERROR {0}", ex.Message);
            }
            return weatherData;
        }
    }
}
