using EduQuest.Domain.Repositories;
using EduQuest.Domain.Security.Cryptography;
using EduQuest.Domain.Security.Tokens;
using EduQuest.Domain.Services.LoggedUser;
using EduQuest.Infrastructure.DataAccess;
using EduQuest.Infrastructure.DataAccess.Repositories;
using EduQuest.Infrastructure.Security.Tokens;
using EduQuest.Infrastructure.Services.LoggedUser;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EduQuest.Infrastructure
{
    public static class DependencyInjectionExtension
    {
        public static void AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IPasswordEncripter, Security.Cryptography.BCrypt>();
            services.AddScoped<ILoggedUser, LoggedUser>();

            AddDbContext(services, configuration);
            AddToken(services, configuration);
            AddRepositories(services);
        }

        private static void AddToken(IServiceCollection services, IConfiguration configuration)
        {
            var expirationTimeMinutes = configuration.GetValue<uint>("Settings:Jwt:ExpirationTimeInMinutes");
            var signingKey = configuration.GetValue<string>("Settings:Jwt:SigningKey");

            services.AddScoped<IAccessTokenGenerator>(config => new JwtTokenGenerator(expirationTimeMinutes, signingKey!));
        }

        private static void AddRepositories(IServiceCollection services)
        {
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAlternativaRepository, AlternativaRepository>();
            services.AddScoped<IAlocacaoProfessorRepository, AlocacaoProfessorRepository>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IAtividadeRepository, AtividadeRepository>();
            services.AddScoped<IBatalhaRepository, BatalhaRepository>();
            services.AddScoped<IConquistaRepository, ConquistaRepository>();
            //services.AddScoped<ICursoRepository, CursoRepository>();
            services.AddScoped<IDesafioRepository, DesafioRepository>();
            services.AddScoped<IDisciplinaRepository, DisciplinaRepository>();
            services.AddScoped<IEscolaRepository, EscolaRepository>();
            services.AddScoped<IItemRepository, ItemRepository>();
            //services.AddScoped<IMatriculaRepository, MatriculaRepository>();
            services.AddScoped<IMensagemRepository, MensagemRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            //services.AddScoped<IPeriodoLetivoRepository, PeriodoLetivoRepository>();
            services.AddScoped<IQuestaoRepository, QuestaoRepository>();
            services.AddScoped<ITipoAtividadeRepository, TipoAtividadeRepository>();
            services.AddScoped<ITipoUnidadeRepository, TipoUnidadeRepository>();
            services.AddScoped<ITurmaRepository, TurmaRepository>();
            services.AddScoped<IUsuarioEscolaPerfilRepository, UsuarioEscolaPerfilRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
        }

        private static void AddDbContext(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Connection");

            services.AddDbContext<EduQuestDbContext>(config => config.UseSqlServer(connectionString));
        }
    }
}
