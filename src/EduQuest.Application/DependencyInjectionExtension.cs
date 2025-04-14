using EduQuest.Application.AutoMapper;
using EduQuest.Application.UseCases.Usuarios.Profile;
using EduQuest.Application.UseCases.Usuarios.Register;
using Microsoft.Extensions.DependencyInjection;

namespace EduQuest.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            AddAutoMapper(services);
            AddUseCases(services);
        }

        public static void AddAutoMapper(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(AutoMapping));
        }

        public static void AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<IRegisterUsuarioUseCase, RegisterUsuarioUseCase>();
            services.AddScoped<IGetUsuarioProfileUseCase, GetUsuarioProfileUseCase>();
        }
    }
}
