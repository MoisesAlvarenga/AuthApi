using AuthApi.Models;
using AuthApi.Services;

namespace AuthApi.AuthEndpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/api/v1/auth/register", async (AuthenticateRequest model, IAuthService service) => {

            if(model != null)
            {
                var isRegister = await service.RegisterUser(model);

                if(isRegister)
                {
                    return Results.Created("Usuario criado com sucesso", isRegister);
                }
            }

           return Results.BadRequest(new {message = "Não foi possível registrat usuario."});

        });

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