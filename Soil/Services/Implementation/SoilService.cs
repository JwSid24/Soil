using Microsoft.EntityFrameworkCore;
using Soil.Models;
using Soil.Services.Interface;
using Soil.DB;

namespace Soil.Services.Implementation;

public class SoilService : ISoilService
{
    private readonly AppDbContext _context;

    public SoilService(AppDbContext context)
    {
        _context = context;
    }
    
    // Implementere de her metoder, tilføj api logik 
    public async Task<SoilMoistureReading> GetLatestReadingAsync()
    {
        return await _context.SoilReadings.OrderByDescending(r => r.Timestamp).FirstOrDefaultAsync();
    }

    public async Task<List<SoilMoistureReading>> GetHistoryAsync()
    {
        return await _context.SoilReadings.OrderByDescending(r => r.Timestamp).Take(24).ToListAsync();
    }
}