using Soil.Components;
using Soil.Services.Interface;
using Soil.DB;
using Soil.Services.Implementation;
using Microsoft.EntityFrameworkCore;
using Plotly.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));



builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<PlotlyChart>();
builder.Services.AddHttpClient<ISoilDataClient, SoilDataClient>();
builder.Services.AddScoped<ISoilService, SoilService>();


var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();


app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();