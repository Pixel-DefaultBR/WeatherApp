using WeatherApp.Services;
using System.Threading.Tasks;

public class GeoLocation
{
    public async Task<(string lat, string lon)> GetGeoLocation()
    {
        GeoLocationService geo = new GeoLocationService();
        var (lat, lon) = await geo.GetCordinates();

        return (lat, lon);
    }
}
