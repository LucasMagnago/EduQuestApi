using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;

namespace EduQuest.Application.UseCases.Alunos.GetAllByEscolaId
{
    internal class GetAllAlunoByEscolaIdUseCase : IGetAllAlunoByEscolaIdUseCase
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public GetAllAlunoByEscolaIdUseCase(
            IAlunoRepository alunoRepository,
            IMapper mapper)
        {
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseShortAlunoJson>> Execute(int escolaId)
        {
            var alunos = await _alunoRepository.GetAllByEscolaId(escolaId);
            if (alunos == null || alunos.Count == 0)
                return new List<ResponseShortAlunoJson>();

            return _mapper.Map<List<ResponseShortAlunoJson>>(alunos);
        }
    }
}
