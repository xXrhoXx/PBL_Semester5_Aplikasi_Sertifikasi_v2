using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;

namespace PBL_Semester5_Aplikasi_Sertifikasi_v2.AccessorApp.Service
{
    using System.Security.Claims;
    using Microsoft.AspNetCore.Components.Authorization;

    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public async Task MarkUserAsAuthenticated(string username, string role = "User")
        {
            var authenticatedUser = new ClaimsPrincipal(new ClaimsIdentity(new[]
            {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, role)
        }, authenticationType: "apiauth_type"));

            var authState = Task.FromResult(new AuthenticationState(authenticatedUser));
            NotifyAuthenticationStateChanged(authState);

            await Task.CompletedTask;
        }

        public async Task MarkUserAsLoggedOut()
        {
            var authState = Task.FromResult(new AuthenticationState(_anonymous));
            NotifyAuthenticationStateChanged(authState);

            await Task.CompletedTask;
        }

        public override Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            return Task.FromResult(new AuthenticationState(_anonymous));
        }
    }

}
