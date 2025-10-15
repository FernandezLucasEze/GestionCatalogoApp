// src/Presentation/GestionCatalogo.Web/Services/AuthService.cs
using System.Net.Http.Json;

namespace GestionCatalogo.Web.Services;

public class AuthService : IAuthService
{
    private readonly HttpClient _httpClient;
    // La URL base de tu API, configurada en Program.cs
    private readonly string _apiBaseUrl;

    public AuthService(HttpClient httpClient)
    {
        _httpClient = httpClient;
        // Ajusta el puerto si tu API usa uno diferente
        _apiBaseUrl = "https://localhost:5001/api/auth";
    }

    public async Task<bool>
    RegisterAsync(RegisterDto registerDto)
    {
    var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/register", registerDto);
    return response.IsSuccessStatusCode;
    }

    public async Task<LoginResponseDto?>
        LoginAsync(LoginDto loginDto)
        {
        var response = await _httpClient.PostAsJsonAsync($"{_apiBaseUrl}/login", loginDto);
        if (response.IsSuccessStatusCode)
        {
        return await response.Content.ReadFromJsonAsync<LoginResponseDto>
            ();
            }
            return null;
            }
            }
