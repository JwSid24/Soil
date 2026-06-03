using Soil.Models.DataTransferObject;
using Soil.Services.Interface;

namespace Soil.Services.Implementation;

public class SoilDataClient : ISoilDataClient
{
    private readonly HttpClient _httpClient;

    private const string Url =
        "https://api.open-meteo.com/v1/forecast?latitude=52.9566&longitude=11.0949&hourly=soil_moisture_0_to_1cm,soil_moisture_27_to_81cm&models=icon_seamless&past_days=7&forecast_days=1";

    public SoilDataClient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<(double Surface, double Underground)> FetchLatestReadingsAsync()
    {
        try
        {
            var response = await _httpClient.GetFromJsonAsync<OpenMeteoResponse>(Url);

            if (response?.HourlyData.SurfaceMoisture != null && response.HourlyData.SurfaceMoisture.Any())
            {
                var latestSurface = response.HourlyData.SurfaceMoisture.Last();
                var latestUnderground = response.HourlyData.UndergroundMoisture.Last();

                return (latestSurface, latestUnderground);
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error fetching data: {ex.Message}");
        }

        return (0, 0);
    }
}