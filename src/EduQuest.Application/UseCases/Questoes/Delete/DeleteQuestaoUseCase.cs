using EduQuest.Domain.Repositories;
using EduQuest.Exception.ExceptionsBase;

namespace EduQuest.Application.UseCases.Questoes.Delete
{
    internal class DeleteQuestaoUseCase : IDeleteQuestaoUseCase
    {
        private readonly IQuestaoRepository _questaoRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteQuestaoUseCase(IQuestaoRepository questaoRepository, IUnitOfWork unitOfWork)
        {
            _questaoRepository = questaoRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(int questaoId)
        {
            var questao = await _questaoRepository.GetByIdAsync(questaoId);
            if (questao == null)
            {
                throw new NotFoundException("Questão não encontrada");
            }

            await _questaoRepository.DeleteAsync(questao);
            await _unitOfWork.Commit();
        }
    }
}
