using BookLibrary.Application.Services;
using BookLibrary.Application.Services.Interfaces;

namespace BookLibrary.UI.Blazor.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection RegisterHttpClient(this IServiceCollection services)
            => services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:7251/api/") })
                       .AddScoped<IApiService, ApiService>();
    }
}