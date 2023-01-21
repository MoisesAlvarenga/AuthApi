using AuthApi.Infrastructure;
using AuthApi.Models;

namespace AuthApi.Services;

public class AuthService : IAuthService
{
    private readonly IMongoRepository<User> _userRepository;

    public AuthService(IMongoRepository<User> userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<User> RegisterUser(User user)
    {
        var hashPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

        user.Password = hashPassword;

        await _userRepository.InsertOneAsync(user);

        return user;
    }

}