using Soil.Models;
namespace Soil.Services.Interface;

public interface ISoilService
{
    Task<SoilMoistureReading> GetLatestReadingAsync(int depth);
    Task<List<SoilMoistureReading>> GetHistoryAsync();
}