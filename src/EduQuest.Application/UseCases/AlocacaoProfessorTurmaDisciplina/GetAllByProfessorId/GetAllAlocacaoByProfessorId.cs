using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.GetAllByProfessorId
{
    internal class GetAllAlocacaoByProfessorId : IGetAllAlocacaoByProfessorId
    {
        private readonly IAlocacaoProfessorRepository _alocacaoProfessorRepository;
        private readonly IMapper _mapper;

        public GetAllAlocacaoByProfessorId(IAlocacaoProfessorRepository alocacaoProfessorRepository,
            IMapper mapper)
        {
            _alocacaoProfessorRepository = alocacaoProfessorRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseProfessorDisciplinaJson>> Execute(int professorId)
        {
            var alocacaoProfessores = await _alocacaoProfessorRepository.GetAllByProfessorId(professorId);

            if (alocacaoProfessores == null)
            {
                throw new NotFoundException("Alocações não encontradas");
            }

            return _mapper.Map<List<ResponseProfessorDisciplinaJson>>(alocacaoProfessores);
        }
    }
}
