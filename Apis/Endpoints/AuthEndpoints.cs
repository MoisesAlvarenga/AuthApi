using AuthApi.Models;
using AuthApi.Services;

namespace AuthApi.AuthEndpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/api/v1/auth/login", async (AuthenticateRequest model, IAuthService service) => {
            
                var response = await service.Login(model); 

                if(response == null)
                {   
                    return Results.BadRequest(new {message = "Usuário ou senha incorreto(s)"});
                    
                }

                return Results.Ok(response);

        });
    }
}