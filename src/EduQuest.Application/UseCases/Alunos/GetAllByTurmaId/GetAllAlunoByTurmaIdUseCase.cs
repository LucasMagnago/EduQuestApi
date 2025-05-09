using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;

namespace EduQuest.Application.UseCases.Alunos.GetAllByTurmaId
{
    internal class GetAllAlunoByTurmaIdUseCase : IGetAllAlunoByTurmaIdUseCase
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public GetAllAlunoByTurmaIdUseCase(
            IAlunoRepository alunoRepository,
            IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseShortAlunoJson>> Execute(int turmaId)
        {
            var alunos = await _alunoRepository.GetAllByTurmaId(turmaId);
            if (alunos == null || alunos.Count == 0)
                return new List<ResponseShortAlunoJson>();

            return _mapper.Map<List<ResponseShortAlunoJson>>(alunos);
        }
    }
}
