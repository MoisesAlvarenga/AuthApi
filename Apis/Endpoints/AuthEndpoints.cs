using AuthApi.Models;
using AuthApi.Services;

namespace AuthApi.AuthEndpoints;

public static class AuthEndpoints
{
    public static void MapAuthEndpoints(this WebApplication app)
    {
        app.MapPost("/api/v1/auth/register", async (User model, IAuthService service) => {

            if(model != null)
            {
                var userResponse = await service.RegisterUser(model);

                if(userResponse != null)
                {
                    return Results.Created("Usuario criado com sucesso", userResponse);
                }
            }

           return Results.BadRequest(new {message = "Não foi possível registrat usuario."});

        });
    }
}