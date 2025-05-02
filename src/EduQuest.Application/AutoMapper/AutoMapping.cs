using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.DTOs;
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
            CreateMap<RequestRemoveProfessorFromTurmaJson, AlocacaoProfessor>();
            CreateMap<RequestRegisterDisciplinaJson, Disciplina>();
            CreateMap<RequestAddAlunoToTurmaJson, Aluno>();
            CreateMap<RequestRegisterUsuarioJson, Usuario>()
                .ForMember(entity => entity.SenhaHash, config => config.Ignore());
            CreateMap<RequestRegisterUsuarioJson, Aluno>()
                .ForMember(entity => entity.SenhaHash, config => config.Ignore());
            CreateMap<RequestRegisterEscolaJson, Escola>()
                .ForMember(entity => entity.Ativo, config => config.Ignore());
            CreateMap<RequestRegisterTurmaJson, Turma>();
            CreateMap<RequestRemoveAlunoFromTurmaJson, Aluno>();
            CreateMap<RequestRegisterAtividadeJson, Atividade>();
            CreateMap<RequestAssignAtividadeToTurmaJson, AtividadeTurma>();
            CreateMap<RequestRegisterAlternativaJson, Alternativa>();
            CreateMap<RequestSetQuestaoCorrectAlternativaJson, Questao>();
            CreateMap<RequestAddQuestaoToAtividadeJson, AtividadeQuestao>();
            CreateMap<RequestAlunoStartsAtividadeJson, AtividadeResposta>();
            CreateMap<RequestAlunoAnswerQuestaoFromAtividadeJson, AtividadeResposta>();
            CreateMap<RequestRegisterBatalhaJson, Batalha>();
        }

        private void EntityToResponse()
        {
            CreateMap<AlocacaoProfessor, ResponseAlocacaoProfessorJson>();
            CreateMap<Aluno, ResponseAlunoJson>()
                .ForMember(dest => dest.Turma, opt => opt.MapFrom(src => src.Turma));
            CreateMap<Turma, ResponseTurmaJson>();

            //CreateMap<Usuario, ResponseRegisteredUsuarioJson>();

            CreateMap<Disciplina, ResponseDisciplinaJson>();
            CreateMap<Disciplina, ResponseRegisteredDisciplinaJson>();
            CreateMap<Escola, ResponseRegisteredEscolaJson>();
            CreateMap<Escola, ResponseEscolaJson>()
                .ForMember(dest => dest.TipoUnidade, opt => opt.MapFrom(src => src.TipoUnidade));
            CreateMap<Turma, ResponseRegisteredTurmaJson>();
            CreateMap<AlocacaoProfessor, ResponseProfessorDisciplinaTurmaJson>();
            CreateMap<Atividade, ResponseAtividadeJson>()
                .ForMember(dest => dest.Professor, opt => opt.MapFrom(src => src.Professor));
            CreateMap<AtividadeTurma, ResponseAssignedAtividadeToTurmaJson>();
            CreateMap<AtividadeTurma, ResponseUnassignedAtividadeFromTurmaJson>();
            CreateMap<Alternativa, ResponseAlternativaJson>();
            CreateMap<Questao, ResponseQuestaoJson>()
                .ForMember(dest => dest.AlternativaCorreta, opt => opt.MapFrom(src => src.AlternativaCorreta))
                .ForMember(dest => dest.Alternativas, opt => opt.MapFrom(src => src.Alternativas));
            CreateMap<AtividadeQuestao, ResponseAtividadeQuestaoJson>()
                .ForMember(dest => dest.Questao, opt => opt.MapFrom(src => src.Questao));
            CreateMap<AtividadeResposta, ResponseAtividadeRespostaJson>()
                .ForMember(dest => dest.AlternativaEscolha, opt => opt.MapFrom(src => src.AlternativaEscolha));
            CreateMap<Batalha, ResponseBatalhaJson>()
                .ForMember(dest => dest.BatalhaQuestoes, opt => opt.MapFrom(src => src.BatalhaQuestoes))
                .ForMember(dest => dest.BatalhaRespostas, opt => opt.MapFrom(src => src.BatalhaRespostas));
            CreateMap<BatalhaResposta, ResponseBatalhaRespostaJson>();




            CreateMap<Alternativa, ResponseShortAlternativaJson>();
            CreateMap<Aluno, ResponseShortAlunoJson>();
            CreateMap<AtividadeAluno, ResponseShortAtividadeAlunoJson>();
            CreateMap<Atividade, ResponseShortAtividadeJson>();
            CreateMap<AtividadeQuestao, ResponseShortAtividadeQuestaoJson>();
            CreateMap<AtividadeResposta, ResponseShortAtividadeRespostaJson>();
            CreateMap<Escola, ResponseShortEscolaJson>();
            CreateMap<Questao, ResponseShortQuestaoJson>()
                .ForMember(dest => dest.Alternativas, opt => opt.MapFrom(src => src.Alternativas));
            CreateMap<Usuario, ResponseShortUsuarioJson>();
            CreateMap<Batalha, ResponseShortBatalhaRespostaJson>();
            CreateMap<AlunoRankingDTO, ResponseAlunoRankingJson>();
            CreateMap<TurmaRankingDTO, ResponseTurmaRankingJson>();

            CreateMap<Usuario, ResponseShortUsuarioJson>();
            CreateMap<Escola, ResponseShortEscolaJson>();
            CreateMap<Perfil, ResponseShortPerfilJson>();
            CreateMap<UsuarioEscolaPerfil, ResponseShortUsuarioEscolaPerfilJson>()
                .ForMember(dest => dest.Usuario, opt => opt.MapFrom(src => src.Usuario))
                .ForMember(dest => dest.Escola, opt => opt.MapFrom(src => src.Escola))
                .ForMember(dest => dest.Perfil, opt => opt.MapFrom(src => src.Perfil));
        }
    }
}

