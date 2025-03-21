using PBL_Semester5_Aplikasi_Sertifikasi_v2.AccessorApp.Components;
using NetcodeHub.Packages.Extensions.LocalStorage;
using NetcodeHub.Packages.Extensions.SessionStorage;
using PBL_Semester5_Aplikasi_Sertifikasi_v2.AccessorApp.Service;
using Microsoft.AspNetCore.Authentication.Cookies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
       .AddCookie(options =>
       {
           options.Cookie.Name = "auth_token";
           options.LoginPath = "/login";  // Define the login path
           options.Cookie.MaxAge = TimeSpan.FromMinutes(60);
           options.AccessDeniedPath = "/access-denied";  // Access denied path
       });
builder.Services.AddAuthorization();
builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddNetcodeHubLocalStorageService();
builder.Services.AddNetcodeHubSessionStorageService();
 

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
