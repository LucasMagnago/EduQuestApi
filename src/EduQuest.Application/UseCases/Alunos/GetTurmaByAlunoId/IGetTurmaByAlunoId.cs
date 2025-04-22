using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Alunos.GetTurmaByAlunoId
{
    public interface IGetTurmaByAlunoId
    {
        Task<ResponseTurmaJson> Execute(int turmaId);
    }
}
