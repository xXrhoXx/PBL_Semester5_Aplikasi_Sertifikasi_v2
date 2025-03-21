using PBL_Semester5_Aplikasi_Sertifikasi_v2.app.Models.Entities;
using System.Net.Http;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.app.Data
{
    public class DataFetcher
    {
        public async Task FetchData()
        {
            Accessor accessor;
            HttpClient httpClient = new HttpClient();

            try
            {
                // Fetch the list of data
                accessor = await httpClient.GetFromJsonAsync<Accessor>("http://localhost:5017/api/Accessor");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error fetching data: {ex.Message}");
            }
        }
    }
}
