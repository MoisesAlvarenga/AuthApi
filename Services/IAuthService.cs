using AuthApi.Models;

namespace AuthApi.Services;

public interface IAuthService
{
    Task<AuthenticateResponse> Login(AuthenticateRequest model);
}