using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;

namespace EduQuest.Application.UseCases.Itens.GetAll
{
    internal class GetAllItem : IGetAllItem
    {
        public readonly IItemRepository _itemRepository;
        public IMapper _mapper;

        public GetAllItem(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<List<ResponseItemJson>> Execute()
        {
            var itens = await _itemRepository.GetAllAsync() ?? new List<Item>();

            return itens.Select(i => _mapper.Map<ResponseItemJson>(i)).ToList();
        }
    }
}
