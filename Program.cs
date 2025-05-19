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
        var weatherCountry = await weatherForecast.GetWeatherForecastByCountry(country);
        var weatherLocation = await weatherForecast.GetWeatherForecastByCurrentLocation(lat, lon);

        Console.WriteLine($"[Cidade: {city}] Temp: {weatherCity.Temperature}°C - {weatherCity.Description} - Umidade: {weatherCity.Humidity}%");
        if (state != city || weatherState.Temperature != weatherCity.Temperature)
            Console.WriteLine($"[Estado: {state}] Temp: {weatherState.Temperature}°C - {weatherState.Description} - Umidade: {weatherState.Humidity}%");

        Console.WriteLine($"[País: {country}] Temp: {weatherCountry.Temperature}°C - {weatherCountry.Description} - Umidade: {weatherCountry.Humidity}%");
        Console.WriteLine($"[Lat: {lat}, Lon: {lon}] Temp: {weatherLocation.Temperature}°C - {weatherLocation.Description} - Umidade: {weatherLocation.Humidity}%");

        Console.ReadKey();
    }
}
