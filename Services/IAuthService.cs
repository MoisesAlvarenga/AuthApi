using AuthApi.Models;

namespace AuthApi.Services;

public interface IAuthService
{
    Task<User> RegisterUser(User user);
}