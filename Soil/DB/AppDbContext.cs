using Microsoft.EntityFrameworkCore;
using Soil.Models;

namespace Soil.DB;


public class AppDbContext
{
    // registere den ind i Program.cs og connection string i appsetting.json. + lave databasen i postgres bare lokalt. 
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<SoilMoistureReading> Readings { get; set; }
}