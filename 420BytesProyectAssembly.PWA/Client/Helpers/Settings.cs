using _420BytesProyectAssembly.PWA.Client.Helpers.Interfaces;

namespace _420BytesProyectAssembly.PWA.Client.Helpers
{
    public class Settings : ISettings
{
    public string GetApiUrl()
    {
        string ApiUrl = "https://localhost:7205/api";
        return ApiUrl;
    }
}
}
