using AutoMapper;
using EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.GetAllByTurmaId;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.GetAllByturmaId
{
    public class GetAllAlocacaoByTurmaId : IGetAllAlocacaoByTurmaId
    {
        private readonly IAlocacaoProfessorRepository _alocacaoProfessorRepository;
        private readonly IMapper _mapper;

        public GetAllAlocacaoByTurmaId(IAlocacaoProfessorRepository alocacaoProfessorRepository,
            IMapper mapper)
        {
            _alocacaoProfessorRepository = alocacaoProfessorRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseProfessorDisciplinaTurmaJson>> Execute(int turmaId)
        {
            var alocacaoProfessores = await _alocacaoProfessorRepository.GetAllByTurmaId(turmaId);

            if (alocacaoProfessores == null)
            {
                throw new NotFoundException("Alocações não encontradas");
            }

            return _mapper.Map<List<ResponseProfessorDisciplinaTurmaJson>>(alocacaoProfessores);
        }
    }
}
