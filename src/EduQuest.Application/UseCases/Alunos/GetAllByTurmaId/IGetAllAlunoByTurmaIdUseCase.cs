using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Alunos.GetAllByTurmaId
{
    public interface IGetAllAlunoByTurmaIdUseCase
    {
        Task<List<ResponseShortAlunoJson>> Execute(int turmaId);
    }
}
