namespace EduQuest.Application.UseCases.Questoes.Delete
{
    public interface IDeleteQuestaoUseCase
    {
        Task Execute(int questaoId);
    }
}
