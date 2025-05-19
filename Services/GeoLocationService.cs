
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using WeatherApp.Interfaces;

namespace WeatherApp.Services
{
    public class GeoLocationService : IGeoLocation
    {
        private readonly HttpClient _httpClient = new();
        public async Task<(string lat, string lon)>  GetCordinates()
        {
            var response = await _httpClient.GetStringAsync("http://ip-api.com/json/");
            using var json = JsonDocument.Parse(response);
            var root = json.RootElement;

            var lat = root.GetProperty("lat").ToString();
            var lon = root.GetProperty("lon").ToString();

            return (lat, lon);

        }
    }
}