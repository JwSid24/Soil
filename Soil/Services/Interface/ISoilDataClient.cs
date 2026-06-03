namespace Soil.Services.Interface;

public interface ISoilDataClient
{
    Task<(double Surface, double Underground)> FetchLatestReadingsAsync();
}