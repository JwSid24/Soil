using Soil.Models;
namespace Soil.Services.Interface;

public interface ISoilService
{
    
    Task<List<SoilMoistureReading>> GetHistoryAsync();
    
    Task GemMålingAsync(double overflade, double undergrund);
    Task<SoilMoistureReading?> GetLatestByDepthAsync(double depth);
    
}