using PBL_Semester5_Aplikasi_Sertifikasi_v2.ApiClient.Models;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.ApiClient.Models.ApiModels;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.ApiClient
{
    public class ApiClientService
    {
        private readonly HttpClient _httpClient;

        public ApiClientService(ApiClientOptions apiClientOptions)
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri(apiClientOptions.ApiBaseAddress);
        }

        public async Task<List<Accessor>?> GetAccessor()
        {
            return await _httpClient.GetFromJsonAsync<List<Accessor>?>("/api/Accessor");
        }

        public async Task<Accessor?> GetAccessorById(int id)
        {
            return await _httpClient.GetFromJsonAsync<Accessor?>($"/api/Accessor/{id}");
        }

        public async Task SaveAccessor(Accessor accessor)
        {
            await _httpClient.PostAsJsonAsync("/api/Accessor", accessor);
        }

        public async Task UpdateAccessor(Accessor accessor)
        {
            await _httpClient.PutAsJsonAsync("/api/Accessor", accessor);
        }

        public async Task DeleteAccessor(int id)
        {
            await _httpClient.DeleteAsync($"/api/Accessor/{id}");
        }
    }
}
