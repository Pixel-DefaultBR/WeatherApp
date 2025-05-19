using WeatherApp;
public class Program
{
    public static async Task Main(string[] args)
    {
        WeatherForecast weatherForecast = new WeatherForecast();
        GeoLocation geo = new GeoLocation();
      
        var (lat, lon) = await geo.GetGeoLocation();

        await weatherForecast.GetWeatherForecastByCity("Sao Paulo");
        await weatherForecast.GetWeatherForecastByState("Sao Paulo");
        await weatherForecast.GetWeatherForecastByCountry("Brazil");
        await weatherForecast.GetWeatherForecastByCurrentLocation(lat, lon);
    }
}