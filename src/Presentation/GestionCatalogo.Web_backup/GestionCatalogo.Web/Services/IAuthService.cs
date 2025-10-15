namespace GestionCatalogo.Web.Services;
public interface IAuthService
{
    Task<bool> RegisterAsync(RegisterDto registerDto);
    Task<LoginResponseDto?> LoginAsync(LoginDto loginDto);
}
public class RegisterDto { public string Username { get; set; } = ""; public string Password { get; set; } = ""; }
public class LoginDto { public string Username { get; set; } = ""; public string Password { get; set; } = ""; }
public class LoginResponseDto { public string Token { get; set; } = ""; }