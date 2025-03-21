using MauiAccessorApp.Models.Authentication;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.Extensions.Logging;
using NetcodeHub.Packages.Extensions.LocalStorage;
using NetcodeHub.Packages.Extensions.SessionStorage;

namespace MauiAccessorApp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Services.AddSingleton<AuthenticationService>();
            builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
            builder.Services.AddAuthorizationCore();

            builder.Services.AddNetcodeHubLocalStorageService();
            builder.Services.AddNetcodeHubSessionStorageService();

#if DEBUG
    		builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
