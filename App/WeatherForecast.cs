using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using WeatherApp.Interfaces;
using WeatherApp.Models;
using WeatherApp.Services;

public class WeatherForecast: IWeatherForecast
{
    private readonly HttpClient _httpClient;
    private readonly WeatherForecastService _weatherForecastService;

    public WeatherForecast()
    {
        _httpClient = new HttpClient();
        _weatherForecastService = new WeatherForecastService();
    }
    public async Task<WeatherForecastModel> GetWeatherForecastByCurrentLocation(string lat, string lon)
    {
        var weatherForecastAtCurrentLocation = await _weatherForecastService.GetApiResponseMetNoAsync(lat, lon);
        
        return weatherForecastAtCurrentLocation;
    }
    public async Task<WeatherForecastModel> GetWeatherForecastByCity(string city)
    {
        var weatherForecastAtCity = await _weatherForecastService.GetApiResponseWttrAsync(city);

        return weatherForecastAtCity;

    }
    public async Task<WeatherForecastModel> GetWeatherForecastByState(string state)
    {
        var weatherForecastAtState = await _weatherForecastService.GetApiResponseWttrAsync(state);

        return weatherForecastAtState;
    }
    public async Task<WeatherForecastModel> GetWeatherForecastByCountry(string country)
    {
        var weatherForecastAtCountry = await _weatherForecastService.GetApiResponseWttrAsync(country);

        return weatherForecastAtCountry;
    }
}