using AuthApi.AuthEndpoints;
using AuthApi.Infrastructure;
using AuthApi.Services;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors();

builder.Services.Configure<MongoDbSettings>(builder.Configuration.GetSection("MongoDbSettings"));

builder.Services.AddSingleton<IMongoDbSettings>(serviceProvider => serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

builder.Services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

builder.Services.AddScoped<IAuthService, AuthService>();




builder.Services.AddEndpointsApiExplorer();

//#region swagger
    builder.Services.AddSwaggerGen();

    builder.Services.AddSwaggerGen(c =>
    {
        c.SwaggerDoc("v1",
            new OpenApiInfo
            {
                Title = "Estudos Gerais",
                Description = "Estudos gerais sobre diversos temas do Dot.Net",
                Version = "v1",
                Contact = new OpenApiContact()
                {
                    Name = "Moises Alvarenga",
                    Url = new Uri("https://github.com/MoisesAlvarenga"),
                }
            });
    });

//#endregion

var app = builder.Build();

app.UseCors(x => x
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());

app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Estudos Gerais v1");
});


app.MapAuthEndpoints();

app.MapGet("/", () => "Hello World!");

app.Run();
