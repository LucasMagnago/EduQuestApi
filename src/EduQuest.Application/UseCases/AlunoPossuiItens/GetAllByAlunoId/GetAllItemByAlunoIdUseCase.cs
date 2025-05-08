using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Application.UseCases.AlunoPossuiItens.GetAllByAlunoId
{
    internal class GetAllItemByAlunoIdUseCase : IGetAllItemByAlunoIdUseCase
    {
        public readonly IAlunoPossuiItemRepository _alunoPossuiItemRepository;
        public IMapper _mapper;

        public GetAllItemByAlunoIdUseCase(IAlunoPossuiItemRepository alunoPossuiItemRepository, IMapper mapper)
        {
            _alunoPossuiItemRepository = alunoPossuiItemRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseShortAlunoPossuiItemJson>> Execute(int alunoId)
        {
            var itens = await _alunoPossuiItemRepository.GetAllByAlunoId(alunoId) ?? new List<AlunoPossuiItem>();

            return itens.Select(i => _mapper.Map<ResponseShortAlunoPossuiItemJson>(i)).ToList();
        }
    }
}
