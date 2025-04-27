using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.AtividadeQuestoes.Remove
{
    internal class RemoveQuestaoFromAtividadeUseCase : IRemoveQuestaoFromAtividadeUseCase
    {
        private readonly IAtividadeQuestaoRepository _atividadeQuestaoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveQuestaoFromAtividadeUseCase(IAtividadeQuestaoRepository atividadeQuestaoRepository,
            IUnitOfWork unitOfWork)
        {
            _atividadeQuestaoRepository = atividadeQuestaoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(int id)
        {
            var atividadeQuestao = await _atividadeQuestaoRepository.GetByIdAsync(id);
            if (atividadeQuestao == null)
            {
                throw new NotFoundException("Registro não encontrado");
            }

            await _atividadeQuestaoRepository.DeleteAsync(atividadeQuestao);
            await _unitOfWork.Commit();
        }
    }
}

