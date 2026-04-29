using System.Text.Json.Serialization;
namespace Soil.Models.DataTransferObject;

public class OpenMateoResponse
{
    [JsonPropertyName("hourly")] 
    public TimevisData TimeVis { get; set; }
}

public class TimevisData
{
    
    //Parse JSon felter til noget forståelig c# kode.
    
    [JsonPropertyName("time")] 
    public List<string> Tider { get; set; }
    
    [JsonPropertyName("soil_moisture_0_to_1cm")]
    public List<double> FugtighedsOverflade { get; set; }
    
    [JsonPropertyName("soil_moisture_27_to_81cm")]
    public List<double> FugtighedsUndergrund { get; set; }
}