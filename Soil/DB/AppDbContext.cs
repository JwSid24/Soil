using Microsoft.EntityFrameworkCore;
using Soil.Models;

namespace Soil.DB;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<SoilMoistureReading> SoilReadings { get; set; }
}