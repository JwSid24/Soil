using Soil.Models.DataTransferObject;
using Soil.Services.Interface;

namespace Soil.Services.Implementation;

public class JordDataKlient : IJordDataKlient
{
    private readonly HttpClient _httpClient;

    private const string Url =
        "https://api.open-meteo.com/v1/forecast?latitude=52.9566&longitude=11.0949&hourly=soil_moisture_0_to_1cm,soil_moisture_27_to_81cm&models=icon_seamless&past_days=7&forecast_days=1";

    public JordDataKlient(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<(double Overflade, double Undergrund)> HentSenesteMålingerAsync()
    {
        try
        {
            var svar = await _httpClient.GetFromJsonAsync<OpenMateoResponse>(Url);

            if (svar?.TimeVis.FugtighedsOverflade != null && svar.TimeVis.FugtighedsOverflade.Any())
            {
                var nyesteOverflade = svar.TimeVis.FugtighedsOverflade.Last();
                var nyesterUndergrund = svar.TimeVis.FugtighedsUndergrund.Last();

                return (nyesteOverflade, nyesterUndergrund);
            }

        }
        catch (Exception ex)
        {
            Console.WriteLine($"Fejl ved hentning af data: {ex.Message}");
        }

        return (0, 0);
    }
}