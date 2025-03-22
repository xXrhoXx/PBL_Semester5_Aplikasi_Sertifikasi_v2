namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.app.Data
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddBlazorSessionStorage(this IServiceCollection services)
        {
            return services.AddScoped<ISessionStorageService, SessionStorageService>()
                .AddScoped<ISyncSessionStorageService, SessionStorageService>();
        }
    }
}
