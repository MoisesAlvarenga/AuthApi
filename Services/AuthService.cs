using AuthApi.Entities;
using AuthApi.Helpers;
using AuthApi.Infrastructure;
using AuthApi.Models;
using AutoMapper;

namespace AuthApi.Services;

public class AuthService : IAuthService
{
    private readonly IMongoRepository<User> _userRepository;
    private readonly IJwtUtils _jwtUtils;
    private readonly IMapper _mapper;

    public AuthService(IMongoRepository<User> userRepository, IJwtUtils jwtUtils, IMapper mapper)
    {
        _userRepository = userRepository;
        _jwtUtils = jwtUtils;
        _mapper = mapper;
    }
    public async Task<AuthenticateResponse> Login(AuthenticateRequest model)
    {
        var user = await _userRepository.FindOneAsync(x => x.Email == model.Email);

        if(user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
        {
            return null;
        }

        var userResponse = _mapper.Map<UserModel>(user);

        var token = _jwtUtils.GenerateToken(user);

        return new AuthenticateResponse(userResponse, token);
    }
}