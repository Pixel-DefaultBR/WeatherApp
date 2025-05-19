namespace WeatherApp.Interfaces
{
    public interface IGeoLocation
    {
        Task<(string lat, string lon)> GetCordinates();
    }
}