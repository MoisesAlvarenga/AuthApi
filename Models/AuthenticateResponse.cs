namespace AuthApi.Models;


public class AuthenticateResponse
{
    public string Id { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }


    public AuthenticateResponse(UserModel user, string token)
    {
        Id = user.Id;
        Email = user.Email;
        Token = token;
    }
}