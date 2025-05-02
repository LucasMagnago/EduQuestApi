using EduQuest.Api.Filters;
using EduQuest.Api.Token;
using EduQuest.Application;
using EduQuest.Domain.Security.Tokens;
using EduQuest.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Scalar.AspNetCore;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddJsonOptions(opts =>
{
    opts.JsonSerializerOptions.MaxDepth = 64;
});

builder.Services.AddOpenApi();

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

//builder.Services.AddAuthorization(options =>
//{
//    options.AddPolicy("OnlyAdmin", policy =>
//        policy.Requirements.Add(new PerfilRequirement(new[] { "Admin" })));

//    options.AddPolicy("OnlyAluno", policy =>
//        policy.Requirements.Add(new PerfilRequirement(new[] { "Aluno" })));

//    options.AddPolicy("OnlyProfessor", policy =>
//        policy.Requirements.Add(new PerfilRequirement(new[] { "Professor" })));

//    options.AddPolicy("OnlyGestor", policy =>
//        policy.Requirements.Add(new PerfilRequirement(new[] { "Gestor" })));

//    options.AddPolicy("AdminOrGestor", policy =>
//        policy.Requirements.Add(new PerfilRequirement(new[] { "Admin", "Gestor" })));

//    options.AddPolicy("ProfessorOrGestor", policy =>
//        policy.Requirements.Add(new PerfilRequirement(new[] { "Professor", "Gestor" })));

//    options.AddPolicy("AdminOrProfessorOrGestor", policy =>
//        policy.Requirements.Add(new PerfilRequirement(new[] { "Admin", "Professor", "Gestor" })));

//    options.AddPolicy("All", policy =>
//        policy.Requirements.Add(new PerfilRequirement(new[] { "Admin", "Aluno", "Professor", "Gestor" })));
//});

//builder.Services.AddScoped<IAuthorizationHandler, PerfilHandler>();

builder.Services.AddAuthorization(options =>
{
    options.FallbackPolicy = new AuthorizationPolicyBuilder()
        .RequireAuthenticatedUser()
        .Build();
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