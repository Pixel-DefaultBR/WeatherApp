using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Interfaces;
using WeatherApp.Models;
using WeatherApp.Services;

public class WeatherForecast: IWeatherForecast
{
    private readonly HttpClient _httpClient;
    public WeatherForecast()
    {
        _httpClient = new HttpClient();
    }
    public async Task<WeatherForecastModel> GetWeatherForecastByCurrentLocation(string lat, string lon)
    {
        var api = new WeatherForecastService();
        var weatherForecastAtCurrentLocation = await api.GetApiResponseMetNoAsync(lat, lon);
        Console.WriteLine($"[met.no] Temp: {weatherForecastAtCurrentLocation.Temperature}°C - Umidade: {weatherForecastAtCurrentLocation.Humidity}%");
        
        return weatherForecastAtCurrentLocation;
    }
    public async Task<WeatherForecastModel> GetWeatherForecastByCity(string city)
    {
        var api = new WeatherForecastService();

        var weatherForecastAtCity = await api.GetApiResponseWttrAsync(city);
        Console.WriteLine($"[wttr.in] Temp: {weatherForecastAtCity.Temperature}°C - {weatherForecastAtCity.Description} - Umidade: {weatherForecastAtCity.Humidity}%");

        return weatherForecastAtCity;

    }
    public async Task<WeatherForecastModel> GetWeatherForecastByState(string state)
    {
        var api = new WeatherForecastService();

        var weatherForecastAtState = await api.GetApiResponseWttrAsync(state);
        Console.WriteLine($"[wttr.in] Temp: {weatherForecastAtState.Temperature}°C - {weatherForecastAtState.Description} - Umidade: {weatherForecastAtState.Humidity}%");
        
        return weatherForecastAtState;
    }
    public async Task<WeatherForecastModel> GetWeatherForecastByCountry(string country)
    {
        var api = new WeatherForecastService();

        var weatherForecastAtCountry = await api.GetApiResponseWttrAsync(country);
        Console.WriteLine($"[wttr.in] Temp: {weatherForecastAtCountry.Temperature}°C - {weatherForecastAtCountry.Description} - Umidade: {weatherForecastAtCountry.Humidity}%");
        
        return weatherForecastAtCountry;
    }
}