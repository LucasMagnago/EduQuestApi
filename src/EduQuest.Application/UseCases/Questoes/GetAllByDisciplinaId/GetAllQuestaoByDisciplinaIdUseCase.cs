using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Questoes.GetAllByDisciplinaId
{
    internal class GetAllQuestaoByDisciplinaIdUseCase : IGetAllQuestaoByDisciplinaIdUseCase
    {
        private readonly IQuestaoRepository _questaoRepository;
        private readonly IMapper _mapper;

        public GetAllQuestaoByDisciplinaIdUseCase(IQuestaoRepository questaoRepository, IMapper mapper)
        {
            _questaoRepository = questaoRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseQuestaoJson>> Execute(int disciplinaId)
        {
            var questoes = await _questaoRepository.GetAllByDisciplinaId(disciplinaId);
            if (questoes == null || !questoes.Any())
            {
                throw new NotFoundException("Nenhuma questão encontrada para a disciplina informada.");
            }

            return _mapper.Map<List<ResponseQuestaoJson>>(questoes);
        }
    }
}
