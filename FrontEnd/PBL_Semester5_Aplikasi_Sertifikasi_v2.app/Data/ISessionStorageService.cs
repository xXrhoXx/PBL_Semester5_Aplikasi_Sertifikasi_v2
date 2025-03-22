namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.app.Data
{
    public interface ISessionStorageService
    {
        Task ClearAsync();
        Task<T> GetItemAsync<T>(string key);
        Task<string> KeyAsync<T>(int index);
        Task RemoveItemAsync(string key);
        Task<int> LengthAsync();
        Task SetItemAsync(string key, object data);

        event EventHandler<ChangedEventArgs> changed;
        event EventHandler<ChangingEventArgs> changing;
    }
}
