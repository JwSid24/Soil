using Microsoft.EntityFrameworkCore;
using Soil.Models;
using Soil.Services.Interface;
using Soil.DB;

namespace Soil.Services.Implementation;

public class SoilService : ISoilService
{
    private readonly AppDbContext _context;
    private readonly ISoilDataClient _soilDataClient;

    public SoilService(AppDbContext context, ISoilDataClient soilDataClient)
    {
        _context = context;
        _soilDataClient = soilDataClient;
    }

    public async Task<List<SoilMoistureReading>> GetHistoryAsync()
    {
        return await _context.SoilReadings.OrderByDescending(r => r.Timestamp).Take(100).ToListAsync();
    }

    public async Task SaveReadingAsync()
    {
        var latest = await _context.SoilReadings
            .OrderByDescending(r => r.Timestamp)
            .FirstOrDefaultAsync();

        if (latest != null && (DateTime.UtcNow - latest.Timestamp).TotalMinutes < 60)
            return;

        var (surface, underground) = await _soilDataClient.FetchLatestReadingsAsync();
        if (surface == 0 && underground == 0) return;

        _context.SoilReadings.AddRange(
            new SoilMoistureReading
            {
                Timestamp = DateTime.UtcNow,
                MoistureLevel = surface,
                Depth = 1,
                Location = "Satemin"
            },
            new SoilMoistureReading
            {
                Timestamp = DateTime.UtcNow,
                MoistureLevel = underground,
                Depth = 54,
                Location = "Satemin"
            }
        );
        await _context.SaveChangesAsync();
    }

    public async Task<SoilMoistureReading?> GetLatestByDepthAsync(double depth)
    {
        return await _context.SoilReadings
            .Where(r => r.Depth == depth)
            .OrderByDescending(r => r.Timestamp)
            .FirstOrDefaultAsync();
    }
}