using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.AtividadeQuestoes.GetById
{
    internal class GetAtividadeQuestaoByIdUseCase : IGetAtividadeQuestaoByIdUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAtividadeQuestaoRepository _atividadeQuestaoRepository;

        public GetAtividadeQuestaoByIdUseCase(IMapper mapper,
            IAtividadeQuestaoRepository atividadeQuestaoRepository)
        {
            _mapper = mapper;
            _atividadeQuestaoRepository = atividadeQuestaoRepository;
        }

        public async Task<ResponseAtividadeQuestaoJson> Execute(int id)
        {
            var atividadeQuestao = await _atividadeQuestaoRepository.GetByIdAsync(id);
            if (atividadeQuestao == null)
            {
                throw new NotFoundException("Registro não encontrado");
            }

            return _mapper.Map<ResponseAtividadeQuestaoJson>(atividadeQuestao);
        }
    }
}
