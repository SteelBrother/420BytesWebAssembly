using _420BytesProyectAssembly.PWA.Client;
using _420BytesProyectAssembly.PWA.Client.Model.Usuarios.Interfaz;
using _420BytesProyectAssembly.PWA.Client.Model.Usuarios;
using _420BytesProyectAssembly.PWA.Client.ViewModels.Interfaces;
using _420BytesProyectAssembly.PWA.Client.ViewModels;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using _420BytesProyectAssembly.PWA.Client.Model.Interfaces;
using _420BytesProyectAssembly.PWA.Client.Model;
using _420BytesProyectAssembly.PWA.Client.Helpers.Interfaces;
using _420BytesProyectAssembly.PWA.Client.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Linq;
using System.Net.Http;
using Microsoft.Extensions.DependencyInjection;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

//builder.Services.AddSingleton(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

ConfigureServices(builder);

await builder.Build().RunAsync();

void ConfigureServices(WebAssemblyHostBuilder builder)
{
    builder.Services.AddTransient<IIndiceUsuarios_ViewModel, IndiceUsuarios_ViewModel>();
    builder.Services.AddTransient<IGestionUsuarios_Model, GestionUsuarios_Model>();
    builder.Services.AddSingleton<IConexionRest, ConexionRest>();
    builder.Services.AddSingleton<ISettings, Settings>();
    builder.Services.AddScoped<IHttpContextAccessor, HttpContextAccessor>();
    builder.Services.AddHttpClient();
    builder.Services.AddSingleton<HttpClient>();

    ConfigureViewModel(builder.Services);
    ConfigureModels(builder.Services);
}

void ConfigureViewModel(IServiceCollection services)
{
    var assembly = typeof(Program).Assembly;
    var classes = assembly.ExportedTypes.Where(a => a.FullName != null && a.FullName.Contains("_ViewModel"));
    foreach (Type t in classes)
    {
        foreach (Type i in t.GetInterfaces())
        {
            services.AddTransient(i, t);
        }
    }
}

void ConfigureModels(IServiceCollection services)
{
    var assembly = typeof(Program).Assembly;
    var classes = assembly.ExportedTypes.Where(a => a.FullName != null && a.FullName.Contains("_Model"));
    foreach (Type t in classes)
    {
        foreach (Type i in t.GetInterfaces())
        {
            services.AddTransient(i, t);
        }
    }
}
