using AuthApi.Entities;

namespace AuthApi.Helpers;


public interface IJwtUtils
{
    string GenerateToken(User user);
}