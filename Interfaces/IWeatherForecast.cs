using WeatherApp.Models;

namespace WeatherApp.Interfaces
{
    public interface IWeatherForecast
    {
        Task<WeatherForecastModel> GetWeatherForecastByCurrentLocation(string x, string y);
        Task<WeatherForecastModel> GetWeatherForecastByCountry(string country);
        Task<WeatherForecastModel> GetWeatherForecastByState(string state);
        Task<WeatherForecastModel> GetWeatherForecastByCity(string city);
    }
}
