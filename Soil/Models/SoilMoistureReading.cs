namespace Soil.Models;

public class SoilMoistureReading
{
    public int Id { get; set; };
    public DateTime Timestamp = DateTime.Now { get; set; };
    public double MoistureLevel { get; set; };
    public double Depth {get; set;};
    public string Location = "Satemin" { get; set; }; 
    
}