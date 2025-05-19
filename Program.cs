using WeatherApp;
public class Program
{
    public static async Task Main(string[] args)
    {
        WeatherForecast weatherForecast = new WeatherForecast();
        GeoLocation geo = new GeoLocation();
      
        var (lat, lon) = await geo.GetGeoLocation();

        string city = "Sao Paulo";
        string state = "Sao Paulo";
        string country = "Brazil";

        var weatherCity = await weatherForecast.GetWeatherForecastByCity(city);
        var weatherState = await weatherForecast.GetWeatherForecastByState(state);
        var weatherCounty = await weatherForecast.GetWeatherForecastByCountry(country);
        var weatherLocation = await weatherForecast.GetWeatherForecastByCurrentLocation(lat, lon);

        Console.WriteLine($"[{city}] Temp: {weatherCity.Temperature}°C - {weatherState.Description} - Umidade: {weatherCity.Humidity}%");
        Console.WriteLine($"[{state}] Temp: {weatherState.Temperature}°C - {weatherState.Description} - Umidade: {weatherState.Humidity}%");
        Console.WriteLine($"[{country}] Temp: {weatherCounty.Temperature}°C - {weatherCounty.Description} - Umidade: {weatherCounty.Humidity}%");
        Console.WriteLine($"[lat: {lat} - lon: {lon}] Temp: {weatherCity.Temperature}°C - Umidade: {weatherCity.Humidity}%");

        Console.ReadKey();
    }
}