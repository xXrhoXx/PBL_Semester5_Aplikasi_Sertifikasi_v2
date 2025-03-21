using MauiAccessorApp2.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace MauiAccessorApp2.Models.Authentication
{
    public class AuthenticationService
    {
        private const string USER_SESSION_KEY = "app_user_session";
        public async Task<UserSession?> GetUserSession()
        {
            UserSession? session = null;

            var userSessionJson = await SecureStorage.Default.GetAsync(USER_SESSION_KEY);
            if (!string.IsNullOrWhiteSpace(userSessionJson))
                session = JsonSerializer.Deserialize<UserSession>(userSessionJson);

            return session;
        }

        public async Task SaveUserSession(UserSession session)
        {
            var userSessionJson = JsonSerializer.Serialize(session);
            await SecureStorage.Default.SetAsync(USER_SESSION_KEY, userSessionJson);
        }

        public void DeleteUserSession()
        {
            SecureStorage.Remove(USER_SESSION_KEY);
        }
    }
}
