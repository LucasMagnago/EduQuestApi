using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;

namespace EduQuest.Application.UseCases.AtividadeRespostas.GetAllByAlunoIdAndAtividadeId
{
    internal class GetAllAtividadeRespostaByAlunoIdAndAtividadeIdUseCase : IGetAllAtividadeRespostaByAlunoIdAndAtividadeIdUseCase
    {
        private readonly IMapper _mapper;
        private readonly IAtividadeRespostaRepository _atividadeRespostaRepository;

        public GetAllAtividadeRespostaByAlunoIdAndAtividadeIdUseCase(IMapper mapper,
            IAtividadeRespostaRepository atividadeRespostaRepository)
        {
            _mapper = mapper;
            _atividadeRespostaRepository = atividadeRespostaRepository;
        }

        public async Task<IEnumerable<ResponseAtividadeRespostaJson>> Execute(int alunoId, int atividadeId)
        {
            var respostas = await _atividadeRespostaRepository.GetAllByAlunoIdAndAtividadeId(alunoId, atividadeId);

            return _mapper.Map<IEnumerable<ResponseAtividadeRespostaJson>>(respostas);
        }
    }
}

