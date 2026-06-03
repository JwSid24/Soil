using Soil.Models;
namespace Soil.Services.Interface;

public interface ISoilService
{
    Task<List<SoilMoistureReading>> GetHistoryAsync();
    Task SaveReadingAsync();
    Task<SoilMoistureReading?> GetLatestByDepthAsync(double depth);
}