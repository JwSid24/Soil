using Microsoft.EntityFrameworkCore;
using Soil.Models;
using Soil.Services.Interface;
using Soil.DB;

namespace Soil.Services.Implementation;

public class SoilService : ISoilService
{
    private readonly AppDbContext _context;
    private readonly IJordDataKlient _jordDataKlient;

    public SoilService(AppDbContext context, IJordDataKlient jordDataKlient)
    {
        _context = context;
        _jordDataKlient = jordDataKlient;
    }
    
    public async Task<SoilMoistureReading> GetLatestReadingAsync()
    {
        return await _context.SoilReadings.OrderByDescending(r => r.Timestamp).FirstOrDefaultAsync();
    }

    public async Task<List<SoilMoistureReading>> GetHistoryAsync()
    {
        return await _context.SoilReadings.OrderByDescending(r => r.Timestamp).Take(24).ToListAsync();
    }
    
    public async Task GemMålingAsync(double overflade, double undergrund)
    {
        var (apiOverflade, apiUndergrund) = await _jordDataKlient.HentSenesteMålingerAsync();
        if (apiOverflade == 0 && apiUndergrund == 0) return;
        _context.SoilReadings.AddRange(
            new SoilMoistureReading
        {
            Timestamp = DateTime.UtcNow,
            MoistureLevel = apiOverflade,
            Depth = 1,       
            Location = "Satemin"
        }, 
            new SoilMoistureReading
                {
                    Timestamp = DateTime.UtcNow,
                    MoistureLevel = apiUndergrund,
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