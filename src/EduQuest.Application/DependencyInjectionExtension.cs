using EduQuest.Application.AutoMapper;
using EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.AddProfessor;
using EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.GetAllByProfessorId;
using EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.GetAllByturmaId;
using EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.GetAllByTurmaId;
using EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.RemoveProfessor;
using EduQuest.Application.UseCases.Alunos.GetById;
using EduQuest.Application.UseCases.Alunos.GetTurmaByAlunoId;
using EduQuest.Application.UseCases.Auth.Login;
using EduQuest.Application.UseCases.Auth.Register;
using EduQuest.Application.UseCases.Disciplinas.GetAll;
using EduQuest.Application.UseCases.Disciplinas.GetById;
using EduQuest.Application.UseCases.Disciplinas.Register;
using EduQuest.Application.UseCases.Escolas.GetAll;
using EduQuest.Application.UseCases.Escolas.GetById;
using EduQuest.Application.UseCases.Escolas.Register;
using EduQuest.Application.UseCases.Turmas.AddAluno;
using EduQuest.Application.UseCases.Turmas.GetAll;
using EduQuest.Application.UseCases.Turmas.GetById;
using EduQuest.Application.UseCases.Turmas.Register;
using EduQuest.Application.UseCases.Turmas.RemoveAluno;
using EduQuest.Application.UseCases.UsuarioEscolaPerfis.Assign;
using EduQuest.Application.UseCases.UsuarioEscolaPerfis.Unassign;
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
            services.AddScoped<IAddProfessorToTurmaUseCase, AddProfessorToTurmaUseCase>();
            services.AddScoped<IRemoveProfessorFromTurmaUseCase, RemoveProfessorFromTurmaUseCase>();


            services.AddScoped<IGetAlunoById, GetAlunoById>();
            services.AddScoped<IGetTurmaByAlunoId, GetTurmaByAlunoId>();



            services.AddScoped<IRegisterUsuarioUseCase, RegisterUsuarioUseCase>();
            services.AddScoped<ILoginUsuarioUseCase, LoginUsuarioUseCase>();

            //services.AddScoped<IRegisterCursoUseCase, RegisterCursoUseCase>();
            //services.AddScoped<IGetCursoByIdUseCase, GetCursoByIdUseCase>();
            //services.AddScoped<IGetAllCursoUseCase, GetAllCursoUseCase>();

            services.AddScoped<IRegisterDisciplinaUseCase, RegisterDisciplinaUseCase>();
            services.AddScoped<IGetDisciplinaByIdUseCase, GetDisciplinaByIdUseCase>();
            services.AddScoped<IGetAllDisciplinaUseCase, GetAllDisciplinaUseCase>();

            services.AddScoped<IRegisterEscolaUseCase, RegisterEscolaUseCase>();
            services.AddScoped<IGetEscolaByIdUseCase, GetEscolaByIdUseCase>();
            services.AddScoped<IGetAllEscolaUseCase, GetAllEscolaUseCase>();

            //services.AddScoped<IGetAllMatriculaByAlunoId, GetAllMatriculaByAlunoId>();
            //services.AddScoped<IGetMatriculaByIdUseCase, GetMatriculaByIdUseCase>();
            //services.AddScoped<IRegisterMatriculaUseCase, RegisterMatriculaUseCase>();
            //services.AddScoped<IRegisterTransferenciaUseCase, RegisterTransferenciaUseCase>();

            //services.AddScoped<IRegisterPeriodoLetivoUseCase, RegisterPeriodoLetivoUseCase>();
            //services.AddScoped<IGetPeriodoLetivoByIdUseCase, GetPeriodoLetivoByIdUseCase>();
            //services.AddScoped<IGetAllPeriodoLetivoUseCase, GetAllPeriodoLetivoUseCase>();

            services.AddScoped<IAddAlunoToTurmaUseCase, AddAlunoToTurmaUseCase>();
            services.AddScoped<IGetAllTurmaUseCase, GetAllTurmaUseCase>();
            services.AddScoped<IGetTurmaByIdUseCase, GetTurmaByIdUseCase>();
            services.AddScoped<IRegisterTurmaUseCase, RegisterTurmaUseCase>();
            services.AddScoped<IRemoveAlunoFromTurmaUseCase, RemoveAlunoFromTurmaUseCase>();

            services.AddScoped<IAssingUserToSchoolWithRoleUseCase, AssignUserToSchoolWithRoleUseCase>();
            services.AddScoped<IUnassignUserToSchoolWithRoleUseCase, UnassignUserToSchoolWithRoleUseCase>();

            services.AddScoped<IAddProfessorToTurmaUseCase, AddProfessorToTurmaUseCase>();
            services.AddScoped<IRemoveProfessorFromTurmaUseCase, RemoveProfessorFromTurmaUseCase>();
            services.AddScoped<IGetAllAlocacaoByProfessorId, GetAllAlocacaoByProfessorId>();
            services.AddScoped<IGetAllAlocacaoByTurmaId, GetAllAlocacaoByTurmaId>();



        }
    }
}
