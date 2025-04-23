using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;

namespace EduQuest.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestAddProfessorToTurmaJson, AlocacaoProfessor>();

            CreateMap<RequestRegisterDisciplinaJson, Disciplina>();

            CreateMap<RequestAddAlunoToTurmaJson, Aluno>();

            CreateMap<RequestRegisterUsuarioJson, Usuario>()
                .ForMember(entity => entity.SenhaHash, config => config.Ignore());

            CreateMap<RequestRegisterUsuarioJson, Aluno>()
                .ForMember(entity => entity.SenhaHash, config => config.Ignore());

            CreateMap<RequestRegisterEscolaJson, Escola>()
                .ForMember(entity => entity.ativo, config => config.Ignore());

            CreateMap<RequestRegisterTurmaJson, Turma>();

            CreateMap<RequestRemoveAlunoFromTurmaJson, Aluno>();
        }

        private void EntityToResponse()
        {
            CreateMap<AlocacaoProfessor, ResponseAlocacaoProfessorJson>();
            CreateMap<Aluno, ResponseAlunoJson>();
            CreateMap<Turma, ResponseTurmaJson>();
            CreateMap<Usuario, ResponseRegisteredUsuarioJson>();

            CreateMap<Disciplina, ResponseDisciplinaJson>();
            CreateMap<Disciplina, ResponseRegisteredDisciplinaJson>();

            CreateMap<Escola, ResponseRegisteredEscolaJson>();
            CreateMap<Escola, ResponseEscolaJson>();

            CreateMap<Turma, ResponseRegisteredTurmaJson>();

            CreateMap<AlocacaoProfessor, ResponseProfessorDisciplinaJson>();
        }
    }
}

