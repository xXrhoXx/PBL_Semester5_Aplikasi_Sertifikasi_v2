

using Blazored.LocalStorage;
using Microsoft.JSInterop;
using System;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.app.Data
{
    public class SessionStorageService : ISessionStorageService, ISyncSessionStorageService
    {
        private readonly IJSRuntime _runtime;
        private readonly IJSInProcessRuntime _inProcessRuntime;

        public SessionStorageService(IJSRuntime jSRuntime)
        {
            _runtime = jSRuntime;
            _inProcessRuntime = _runtime as IJSInProcessRuntime;
        }

        public event EventHandler<ChangedEventArgs> changed;
        public event EventHandler<ChangingEventArgs> changing;

        public void Clear()
        {
            if (_inProcessRuntime == null)
            {
                throw new InvalidOperationException("IJSInProcessRuntime is not valid (clear)");
            }
            _inProcessRuntime.Invoke<object>("sessionStorage.clear");
        }

        public async Task ClearAsync() => await _runtime.InvokeAsync<object>("sessionStorage.clear");

        public T GetItem<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (_inProcessRuntime == null)
            {
                throw new InvalidOperationException("IJSInProcessRuntime is not valid (getitem)");
            }

            var serializedData = _inProcessRuntime.Invoke<string>("sessionStorage.getItem", key);

            if (serializedData == null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(serializedData);
        }

        public async Task<T> GetItemAsync<T>(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            var serializedData = await _runtime.InvokeAsync<string>("sessionStorage.getItem", key);

            if (serializedData == null)
            {
                return default(T);
            }

            return JsonSerializer.Deserialize<T>(serializedData);
        }

        public string Key(int index)
        {
            if (_inProcessRuntime == null)
            {
                throw new InvalidOperationException("IJSInProcessRuntime is not valid (key)");
            }
            return _inProcessRuntime.Invoke<string>("sessionStorage.key", index);
        }

        public async Task<string> KeyAsync<T>(int index) => await _runtime.InvokeAsync<string>("sessionStorage.key", index);

        public int Length()
        {
            if (_inProcessRuntime == null)
            {
                throw new InvalidOperationException("IJSInProcessRuntime is not valid (length)");
            }
            return _inProcessRuntime.Invoke<int>("eval", "sessionStorage.length");
        }

        public async Task<int> LengthAsync() => await _runtime.InvokeAsync<int>("eval", "sessionStorage.length");

        public void RemoveItem(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (_inProcessRuntime == null)
            {
                throw new InvalidOperationException("IJSInProcessRuntime is not valid (remove item)");
            }

            _inProcessRuntime.Invoke<object>("sessionStorage.removeItem", key);
        }

        public async Task RemoveItemAsync(string key)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            await _runtime.InvokeAsync<object>("sessionStorage.removeItem", key);
        }

        public void SetItem(string key, object data)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (_inProcessRuntime == null)
            {
                throw new InvalidOperationException("IJSInProcessRuntime is not valid (set item)");
            }

            var e = RaiseOnChangingSync(key, data);
            if (e.cancel) return;

            _inProcessRuntime.Invoke<object>("sessionStorage.setItem", key, JsonSerializer.Serialize(data));
            RaiseOnChangingSync(key, e.oldValue, data);
        }

        public async Task SetItemAsync(string key, object data)
        {
            if (string.IsNullOrEmpty(key))
            {
                throw new ArgumentNullException(nameof(key));
            }

            var e = RaiseOnChangingSync(key, data);
            if (e.cancel) return;

            await _runtime.InvokeAsync<object>("sessionStorage.setItem", key, JsonSerializer.Serialize(data));
            RaiseOnChangingSync(key, e.oldValue, data);
        }

        private ChangingEventArgs RaiseOnChangingSync(string key, object data)
        {
            var e = new ChangingEventArgs
            {
                key = key,
                oldValue = ((ISyncSessionStorageService)this).GetItem<object>(key),
                newValue = data
            };
            changing?.Invoke(this, e);
            return e;
        }

        private void RaiseOnChangingSync(string key, object oldValue, object data)
        {
            var e = new ChangingEventArgs
            {
                key = key,
                oldValue = oldValue,
                newValue = data
            };
            changing?.Invoke(this, e);
        }
    }
}
