namespace Soil.Models;

public class SoilMoistureReading
{
    public int Id { get; set; }
    public DateTime Timestamp { get; set; } = DateTime.Now;
    public double MoistureLevel { get; set; }
    public double Depth { get; set; }
    public string Location { get; set; } = "Satemin";
}