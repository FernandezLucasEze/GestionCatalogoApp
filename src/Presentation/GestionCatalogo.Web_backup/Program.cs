using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using GestionCatalogo.Web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

// Registra HttpClient
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// --- SERVICIOS DE AUTENTICACIÓN ---
// 1. Añade los servicios de Blazored.LocalStorage
builder.Services.AddBlazoredLocalStorage();
// 2. Añade los servicios de autorización de Blazor
builder.Services.AddAuthorizationCore();
// 3. Registra NUESTRO AuthenticationStateProvider personalizado
builder.Services.AddScoped<AuthenticationStateProvider, CustomAuthenticationStateProvider>();
// --- FIN DE SERVICIOS DE AUTENTICACIÓN ---

// Registra tu servicio de autenticación
builder.Services.AddScoped<IAuthService, AuthService>();

await builder.Build().RunAsync();