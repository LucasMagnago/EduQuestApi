using AutoMapper;
using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;
using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.AlunoPossuiItens.Acquire
{
    internal class AlunoAcquireItemUseCase : IAlunoAcquireItemUseCase
    {
        private readonly IAlunoPossuiItemRepository _alunoPossuiItemRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IItemRepository _itemRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public AlunoAcquireItemUseCase(IAlunoPossuiItemRepository alunoPossuiItemRepository,
            IAlunoRepository alunoRepository,
            IItemRepository itemRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper)
        {
            _alunoPossuiItemRepository = alunoPossuiItemRepository;
            _alunoRepository = alunoRepository;
            _itemRepository = itemRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<ResponseShortAlunoPossuiItemJson> Execute(RequestAlunoAcquireItemJson request)
        {
            var aluno = await _alunoRepository.GetByIdAsync(request.alunoId);
            if (aluno is null)
                throw new NotFoundException("Aluno não encontrado");

            var item = await _itemRepository.GetByIdAsync(request.itemId);
            if (item is null)
                throw new NotFoundException("Item não encontrado");

            var alreadyHasItem = await _alunoPossuiItemRepository.AlunoAlreadyHasItem(aluno.Id, item.Id);
            if (alreadyHasItem)
                throw new ConflictException("Aluno já possui este item");

            if (item.XpDesbloqueio > aluno.XpAtual)
                throw new ConflictException("Aluno não possui xp necessário para comprar este item");

            var alunoPossuiItem = _mapper.Map<AlunoPossuiItem>(request);
            alunoPossuiItem.DataAquisicao = DateTime.Now;

            aluno.UpdateSaldoWithItemPurchase(item.Custo);

            await _alunoRepository.UpdateAsync(aluno);
            await _alunoPossuiItemRepository.SaveAsync(alunoPossuiItem);
            await _unitOfWork.Commit();

            return _mapper.Map<ResponseShortAlunoPossuiItemJson>(alunoPossuiItem);
        }
    }
}
