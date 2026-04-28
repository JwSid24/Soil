using Soil.Models;
using Soil.Services.Interface;

namespace Soil.Services.Implementation;

public class SoilService : ISoilService
{
    
    // Implementere de her metoder, tilføj api logik 
    public Task<SoilMoistureReading> GetLatestReadingAsync(int depth)
    {
        
    }

    Task<List<SoilMoistureReading>> GetHistoryAsync()
    {
    }
}