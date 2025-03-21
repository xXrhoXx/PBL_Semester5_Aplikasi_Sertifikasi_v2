using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.ApiClient.Models;
using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.ApiClient.IoC
{
    public static class ServiceCollectionExtention
    {
        public static void AddApiClientService(this IServiceCollection service,
            Action<ApiClientOptions> options)
        {
            service.Configure(options);
            service.AddSingleton(provider =>
            {
                var options = provider.GetRequiredService<IOptions<ApiClientOptions>>().Value;
                return new ApiClientService(options);
            });
        }
    }
}
