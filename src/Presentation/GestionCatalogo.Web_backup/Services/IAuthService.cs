namespace GestionCatalogo.Web.Services;

public interface IAuthService
{
    Task<bool>
    RegisterAsync(RegisterDto registerDto);
    Task<LoginResponseDto?>
        LoginAsync(LoginDto loginDto);
        }

        // Definimos los DTOs que usaremos para la comunicación
        public class RegisterDto {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        }

        public class LoginDto {
        public string Username { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        }

        public class LoginResponseDto {
        public string Token { get; set; } = string.Empty;
        }
