using MauiAccessorApp.Models.ViewModels;
using Microsoft.AspNetCore.Components.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MauiAccessorApp.Models.Authentication
{
    public class CustomAuthenticationStateProvider : AuthenticationStateProvider
    {
        private readonly AuthenticationService _authenticationService;
        private readonly ClaimsPrincipal _anonymous = new ClaimsPrincipal(new ClaimsIdentity());

        public CustomAuthenticationStateProvider(AuthenticationService authenticationService)
        {
            _authenticationService = authenticationService;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            var authenticationState = new AuthenticationState(_anonymous);

            var userSession = await _authenticationService.GetUserSession();
            if (userSession is not null)
            {
                var claimsPrincipal = GetClaimPrincipal(userSession);
                authenticationState = new AuthenticationState(claimsPrincipal);
            }

            return authenticationState;
        }

        public async Task UpdateAuthenticationState(UserSession? userSession, bool rememberUser = false)
        {
            ClaimsPrincipal claimsPrincipal = _anonymous;

            if (userSession is not null)
            {
                if (rememberUser)
                    await _authenticationService.SaveUserSession(userSession);

                claimsPrincipal = GetClaimPrincipal(userSession);
            }
            else
            {
                _authenticationService.DeleteUserSession();
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }

        private ClaimsPrincipal GetClaimPrincipal(UserSession userSession)
        {
            return new ClaimsPrincipal(new ClaimsIdentity(new List<Claim>
            {
                new Claim(ClaimTypes.Name, userSession.username),
                new Claim("Id", userSession.id.ToString()),
                new Claim(ClaimTypes.Email, userSession.email)
            }, "CustomAuth"));
        }
    }
}
