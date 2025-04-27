using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Questoes.GetById
{
    internal class GetQuestaoByIdUseCase : IGetQuestaoByIdUseCase
    {
        private readonly IQuestaoRepository _questaoRepository;
        private readonly IMapper _mapper;

        public GetQuestaoByIdUseCase(IQuestaoRepository questaoRepository, IMapper mapper)
        {
            _questaoRepository = questaoRepository;
            _mapper = mapper;
        }

        public async Task<ResponseQuestaoJson> Execute(int id)
        {
            var questao = await _questaoRepository.GetByIdAsync(id);
            if (questao == null)
            {
                throw new NotFoundException("Nenhuma questão encontrada com o ID informado.");
            }
            return _mapper.Map<ResponseQuestaoJson>(questao);
        }
    }
}

