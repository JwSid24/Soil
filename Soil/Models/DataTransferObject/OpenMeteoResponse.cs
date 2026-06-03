using System.Text.Json.Serialization;
namespace Soil.Models.DataTransferObject;

public class OpenMeteoResponse
{
    [JsonPropertyName("hourly")]
    public HourlyData HourlyData { get; set; }
}

public class HourlyData
{
    [JsonPropertyName("time")]
    public List<string> Times { get; set; }

    [JsonPropertyName("soil_moisture_0_to_1cm")]
    public List<double> SurfaceMoisture { get; set; }

    [JsonPropertyName("soil_moisture_27_to_81cm")]
    public List<double> UndergroundMoisture { get; set; }
}