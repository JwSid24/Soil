namespace Soil.Services.Interface;

public interface IJordDataKlient
{
    Task<(double Overflade, double Undergrund)> HentSenesteMålingerAsync();
}