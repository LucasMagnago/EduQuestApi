using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;

namespace EduQuest.Application.UseCases.AtividadeQuestoes.GetAllByAtividadeId
{
    internal class GetAllQuestaoByAtividadeIdUseCase : IGetAllQuestaoByAtividadeIdUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAtividadeQuestaoRepository _atividadeQuestaoRepository;


        public GetAllQuestaoByAtividadeIdUseCase(IMapper mapper,
            IAtividadeQuestaoRepository atividadeQuestaoRepository)
        {
            _mapper = mapper;
            _atividadeQuestaoRepository = atividadeQuestaoRepository;
        }

        public async Task<List<ResponseQuestaoJson>> Execute(int atividadeId)
        {
            var questoes = await _atividadeQuestaoRepository.GetAllQuestaoByAtividadeId(atividadeId);
            if (questoes == null || questoes.Count == 0)
            {
                return new List<ResponseQuestaoJson>();
            }

            return questoes.Select(questao => _mapper.Map<ResponseQuestaoJson>(questao)).ToList();
        }
    }
}

