using AuthApi.Models;

namespace AuthApi.Services;

public interface IAuthService
{
    Task<bool> RegisterUser(AuthenticateRequest user);
    Task<AuthenticateResponse> Login(AuthenticateRequest model);
}