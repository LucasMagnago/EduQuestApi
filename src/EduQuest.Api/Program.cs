using EduQuest.Api.Filters;
using EduQuest.Api.Token;
using EduQuest.Application;
using EduQuest.Domain.Security.Tokens;
using EduQuest.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

//builder.Services.AddSwaggerGen(config =>
//{
//    config.AddSecurityDefinition("Bearer Token", new OpenApiSecurityScheme
//    {
//        Name = "Authorization",
//        Description = @"JWT Authorization header using the Bearer scheme.
//                      Enter 'Bearer' [space] and then your token in the text input below.
//                      Example: 'Bearar 123456abcdef'",
//        In = ParameterLocation.Header,
//        Scheme = "Bearer",
//        Type = SecuritySchemeType.ApiKey
//    });

//    config.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//           new OpenApiSecurityScheme
//           {
//               Reference = new OpenApiReference
//                {
//                    Type = ReferenceType.SecurityScheme,
//                    Id = "Bearer"
//                },
//               Scheme = "oauth2",
//               Name = "Bearer",
//               In = ParameterLocation.Header
//           },
//           new List<string>()
//        }
//    });
//});

builder.Services.AddMvc(options => options.Filters.Add(typeof(ExceptionFilter)));

builder.Services.AddInfrastructure(builder.Configuration);
builder.Services.AddApplication();

builder.Services.AddScoped<ITokenProvider, HttpContextTokenValue>();
builder.Services.AddHttpContextAccessor();

var signingKey = builder.Configuration.GetValue<string>("Settings:Jwt:SigningKey");

builder.Services.AddAuthentication(config =>
{
    config.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    config.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(config =>
{
    config.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = false,
        ValidateAudience = false,
        ClockSkew = new TimeSpan(0),
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(signingKey!))
    };
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

//await MigrateDatabase();

app.Run();

//async Task MigrateDatabase()
//{
//    // Cria um escopo para ter acesso ao serviço de injeção de dependência
//    await using var scope = app.Services.CreateAsyncScope();

//    await DataBaseMigration.MigrateDatabase(scope.ServiceProvider);
//}