using Soil.Models;
namespace Soil.Services.Interface;

public interface ISoilService
{
    
    // tjek om den metode bliver brugt til noget, hvis ikke så slet overføldig kode 
    Task<SoilMoistureReading> GetLatestReadingAsync();
    Task<List<SoilMoistureReading>> GetHistoryAsync();
    
    Task GemMålingAsync(double overflade, double undergrund);
    Task<SoilMoistureReading?> GetLatestByDepthAsync(double depth);
    
}