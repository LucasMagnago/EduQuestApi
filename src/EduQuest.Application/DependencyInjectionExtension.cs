using EduQuest.Application.AutoMapper;
using EduQuest.Application.Services.AssignRewards;
using EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.AddProfessor;
using EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.GetAllByProfessorId;
using EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.GetAllByturmaId;
using EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.GetAllByTurmaId;
using EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.RemoveProfessor;
using EduQuest.Application.UseCases.Alternativas.Delete;
using EduQuest.Application.UseCases.Alternativas.GetById;
using EduQuest.Application.UseCases.Alternativas.Register;
using EduQuest.Application.UseCases.Alunos.GetById;
using EduQuest.Application.UseCases.Alunos.GetTurmaByAlunoId;
using EduQuest.Application.UseCases.AtividadeAlunos.End;
using EduQuest.Application.UseCases.AtividadeAlunos.Start;
using EduQuest.Application.UseCases.AtividadeQuestoes.GetAllByAtividadeId;
using EduQuest.Application.UseCases.AtividadeQuestoes.GetById;
using EduQuest.Application.UseCases.AtividadeQuestoes.Register;
using EduQuest.Application.UseCases.AtividadeQuestoes.Remove;
using EduQuest.Application.UseCases.AtividadeRespostas.Answer;
using EduQuest.Application.UseCases.AtividadeRespostas.GetAllByAlunoIdAndAtividadeId;
using EduQuest.Application.UseCases.Atividades.GetAllAvailableAtividadeByTurmaIdUseCase.cs;
using EduQuest.Application.UseCases.Atividades.GetAllAvailableByAlunoId;
using EduQuest.Application.UseCases.Atividades.GetAllAvailableByProfessorId;
using EduQuest.Application.UseCases.Atividades.GetAllByAlunoId;
using EduQuest.Application.UseCases.Atividades.GetAllByProfessorId;
using EduQuest.Application.UseCases.Atividades.GetAllByTurmaId;
using EduQuest.Application.UseCases.Atividades.GetById;
using EduQuest.Application.UseCases.Atividades.Register;
using EduQuest.Application.UseCases.AtividadeTurmas.Assign;
using EduQuest.Application.UseCases.AtividadeTurmas.Unassign;
using EduQuest.Application.UseCases.Auth.Login;
using EduQuest.Application.UseCases.Auth.Register;
using EduQuest.Application.UseCases.Batalhas.AddAluno;
using EduQuest.Application.UseCases.Batalhas.End;
using EduQuest.Application.UseCases.Batalhas.GetById;
using EduQuest.Application.UseCases.Batalhas.Register;
using EduQuest.Application.UseCases.Batalhas.Start;
using EduQuest.Application.UseCases.Disciplinas.GetAll;
using EduQuest.Application.UseCases.Disciplinas.GetById;
using EduQuest.Application.UseCases.Disciplinas.Register;
using EduQuest.Application.UseCases.Escolas.GetAll;
using EduQuest.Application.UseCases.Escolas.GetById;
using EduQuest.Application.UseCases.Escolas.Register;
using EduQuest.Application.UseCases.Questoes.Delete;
using EduQuest.Application.UseCases.Questoes.GetAllByDisciplinaId;
using EduQuest.Application.UseCases.Questoes.GetAllByDisciplinaIdAndNivel;
using EduQuest.Application.UseCases.Questoes.GetAllByProfessorId;
using EduQuest.Application.UseCases.Questoes.GetById;
using EduQuest.Application.UseCases.Questoes.Register;
using EduQuest.Application.UseCases.Questoes.SetCorrectAlternativa;
using EduQuest.Application.UseCases.Turmas.AddAluno;
using EduQuest.Application.UseCases.Turmas.GetAll;
using EduQuest.Application.UseCases.Turmas.GetById;
using EduQuest.Application.UseCases.Turmas.Register;
using EduQuest.Application.UseCases.Turmas.RemoveAluno;
using EduQuest.Application.UseCases.UsuarioEscolaPerfis.Assign;
using EduQuest.Application.UseCases.UsuarioEscolaPerfis.GetAllByUsuarioId;
using EduQuest.Application.UseCases.UsuarioEscolaPerfis.GetAtivoByUsuarioId;
using EduQuest.Application.UseCases.UsuarioEscolaPerfis.SetAtivo;
using EduQuest.Application.UseCases.UsuarioEscolaPerfis.SetInativo;
using EduQuest.Application.UseCases.UsuarioEscolaPerfis.Unassign;
using EduQuest.Domain.Services.AssignRewards;
using EduQuest.Domain.Services.UpdateStatistics;
using Microsoft.Extensions.DependencyInjection;

namespace EduQuest.Application
{
    public static class DependencyInjectionExtension
    {
        public static void AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAssignRewardsService, AssignRewardsService>();
            services.AddScoped<IUpdateStatisticsService, IUpdateStatisticsService>();

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
            services.AddScoped<IGetUsuarioEscolaPerfilAtivoByUsuarioIdUseCase, GetUsuarioEscolaPerfilAtivoByUsuarioIdUseCase>();
            services.AddScoped<IGetAllUsuarioEscolaPerfilByUsuarioIdUseCase, GetAllUsuarioEscolaPerfilByUsuarioIdUseCase>();
            services.AddScoped<ISetUsuarioEscolaPerfilAtivoUseCase, SetUsuarioEscolaPerfilAtivoUseCase>();
            services.AddScoped<ISetUsuarioEscolaPerfilInativoUseCase, SetUsuarioEscolaPerfilInativoUseCase>();


            services.AddScoped<IAddProfessorToTurmaUseCase, AddProfessorToTurmaUseCase>();
            services.AddScoped<IRemoveProfessorFromTurmaUseCase, RemoveProfessorFromTurmaUseCase>();
            services.AddScoped<IGetAllAlocacaoByProfessorId, GetAllAlocacaoByProfessorId>();
            services.AddScoped<IGetAllAlocacaoByTurmaId, GetAllAlocacaoByTurmaId>();

            services.AddScoped<IRegisterAtividadeUseCase, RegisterAtividadeUseCase>();
            services.AddScoped<IGetAtividadeByIdUseCase, GetAtividadeByIdUseCase>();
            services.AddScoped<IGetAllAtividadeByAlunoIdUseCase, GetAllAtividadeByAlunoIdUseCase>();
            services.AddScoped<IGetAllAtividadeByProfessorIdUseCase, GetAllAtividadeByProfessorIdUseCase>();
            services.AddScoped<IGetAllAtividadeByTurmaIdUseCase, GetAllAtividadeByTurmaIdUseCase>();
            services.AddScoped<IGetAllAvailableAtividadeByAlunoIdUseCase, GetAllAvailableAtividadeByAlunoIdUseCase>();
            services.AddScoped<IGetAllAvailableAtividadeByProfessorIdUseCase, GetAllAvailableAtividadeByProfessorIdUseCase>();
            services.AddScoped<IGetAllAvailableAtividadeByTurmaIdUseCase, GetAllAvailableAtividadeByTurmaIdUseCase>();

            services.AddScoped<IUnassignAtividadeFromTurmaUseCase, UnassignAtividadeFromTurmaUseCase>();
            services.AddScoped<IAssignAtividadeToTurmaUseCase, AssignAtividadeToTurmaUseCase>();

            services.AddScoped<IGetAlternativaByIdUseCase, GetAlternativaByIdUseCase>();
            services.AddScoped<IRegisterAlternativaUseCase, RegisterAlternativaUseCase>();
            services.AddScoped<IDeleteAlternativaUseCase, DeleteAlternativaUseCase>();

            services.AddScoped<IRegisterQuestaoUseCase, RegisterQuestaoUseCase>();
            services.AddScoped<IDeleteQuestaoUseCase, DeleteQuestaoUseCase>();
            services.AddScoped<IGetAllQuestaoByDisciplinaIdUseCase, GetAllQuestaoByDisciplinaIdUseCase>();
            services.AddScoped<IGetAllQuestaoByDisciplinaIdAndNivelUseCase, GetAllQuestaoByDisciplinaIdAndNivelUseCase>();
            services.AddScoped<IGetAllQuestaoByProfessorIdUseCase, GetAllQuestaoByProfessorIdUseCase>();
            services.AddScoped<IGetQuestaoByIdUseCase, GetQuestaoByIdUseCase>();
            services.AddScoped<ISetQuestaoCorrectAlternativaUseCase, SetQuestaoCorrectAlternativaUseCase>();

            services.AddScoped<IAddQuestaoToAtividadeUseCase, AddQuestaoToAtividadeUseCase>();
            services.AddScoped<IRemoveQuestaoFromAtividadeUseCase, RemoveQuestaoFromAtividadeUseCase>();
            services.AddScoped<IGetAllQuestaoByAtividadeIdUseCase, GetAllQuestaoByAtividadeIdUseCase>();
            services.AddScoped<IGetAtividadeQuestaoByIdUseCase, GetAtividadeQuestaoByIdUseCase>();

            services.AddScoped<IAlunoStartsAtividadeUseCase, AlunoStartsAtividadeUseCase>();
            services.AddScoped<IAlunoEndsAtividadeUseCase, AlunoEndsAtividadeUseCase>();

            services.AddScoped<IAlunoAnswerQuestaoFromAtividadeUseCase, AlunoAnswerQuestaoFromAtividadeUseCase>();
            services.AddScoped<IGetAllAtividadeRespostaByAlunoIdAndAtividadeIdUseCase, GetAllAtividadeRespostaByAlunoIdAndAtividadeIdUseCase>();

            services.AddScoped<IRegisterBatalhaUseCase, RegisterBatalhaUseCase>();
            services.AddScoped<IAddAlunoToBatalhaUseCase, AddAlunoToBatalhaUseCase>();
            services.AddScoped<IStartBatalhaUseCase, StartBatalhaUseCase>();
            services.AddScoped<IEndBatalhaUseCase, EndBatalhaUseCase>();
            services.AddScoped<IGetBatalhaByIdUseCase, GetBatalhaByIdUseCase>();

            services.AddScoped<IAlunoAnswerQuestaoFromAtividadeUseCase, AlunoAnswerQuestaoFromAtividadeUseCase>();

        }
    }
}
