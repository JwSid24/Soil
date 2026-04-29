using Soil.Models;
namespace Soil.Services.Interface;

public interface ISoilService
{
    Task<SoilMoistureReading> GetLatestReadingAsync();
    Task<List<SoilMoistureReading>> GetHistoryAsync();
    
}