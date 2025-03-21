namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.app.Data
{
    public interface ISyncSessionStorageService
    {
        void Clear();
        T GetItem<T>(string key);
        string Key(int index);
        int Length();
        void RemoveItem(string key);
        void SetItem(string key, object data);

        event EventHandler<ChangedEventArgs> changed;
        event EventHandler<ChangingEventArgs> changing;
    }
}
