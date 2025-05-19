using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Models;

namespace WeatherApp.Services
{
    public class WeatherForecastService
    {
        private readonly HttpClient _httpClient;
        public WeatherForecastService()
        {
            _httpClient = new HttpClient();
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "WeatherApp/1.0");
        }
        public async Task<WeatherForecastModel> GetApiResponseWttrAsync(string city)
        {
            var url = $"https://wttr.in/{city}?format=j1";
            var response = await _httpClient.GetStringAsync(url);

            using var doc = JsonDocument.Parse(response);
            var current = doc.RootElement.GetProperty("current_condition")[0];

            return new WeatherForecastModel
            {
                Temperature = current.GetProperty("temp_C").GetString(),
                Description = current.GetProperty("weatherDesc")[0].GetProperty("value").GetString(),
                Humidity = current.GetProperty("humidity").GetString()
            };
        }
        public async Task<WeatherForecastModel> GetApiResponseMetNoAsync(string lat, string lon)
        {
            var url = $"https://api.met.no/weatherapi/locationforecast/2.0/compact?lat={lat}&lon={lon}";
            var response = await _httpClient.GetStringAsync(url);

            using var doc = JsonDocument.Parse(response);
            var timeseries = doc.RootElement.GetProperty("properties").GetProperty("timeseries")[0];
            var instant = timeseries.GetProperty("data").GetProperty("instant").GetProperty("details");

            return new WeatherForecastModel
            {
                Temperature = instant.GetProperty("air_temperature").ToString(),
                Description = "Sem descrição (met.no não fornece no modo 'compact')",
                Humidity = instant.GetProperty("relative_humidity").ToString()
            };
        }
    }
}
