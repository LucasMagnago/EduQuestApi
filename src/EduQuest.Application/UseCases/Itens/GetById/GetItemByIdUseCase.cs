using AutoMapper;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Itens.GetById
{
    internal class GetItemByIdUseCase : IGetItemByIdUseCase
    {
        public readonly IItemRepository _itemRepository;
        public IMapper _mapper;

        public GetItemByIdUseCase(IItemRepository itemRepository, IMapper mapper)
        {
            _itemRepository = itemRepository;
            _mapper = mapper;
        }

        public async Task<ResponseItemJson> Execute(int itemId)
        {
            var item = await _itemRepository.GetByIdAsync(itemId);
            if (item is null)
                throw new NotFoundException("Item não encontrado");

            return _mapper.Map<ResponseItemJson>(item);
        }
    }
}
