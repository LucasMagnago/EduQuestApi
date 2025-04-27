using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Questoes.GetAllByDisciplinaIdAndNivel
{
    internal class GetAllQuestaoByDisciplinaIdAndNivelUseCase : IGetAllQuestaoByDisciplinaIdAndNivelUseCase
    {
        private readonly IQuestaoRepository _questaoRepository;
        private readonly IMapper _mapper;

        public GetAllQuestaoByDisciplinaIdAndNivelUseCase(IQuestaoRepository questaoRepository, IMapper mapper)
        {
            _questaoRepository = questaoRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseQuestaoJson>> Execute(int disciplinaId, int nivel)
        {
            var questoes = await _questaoRepository.GetAllByDisciplinaIdAndNivel(disciplinaId, nivel);
            if (questoes == null || questoes.Count == 0)
            {
                throw new NotFoundException("Nenhuma questão encontrada para a disciplina informada.");
            }

            return _mapper.Map<List<ResponseQuestaoJson>>(questoes);
        }
    }
}
