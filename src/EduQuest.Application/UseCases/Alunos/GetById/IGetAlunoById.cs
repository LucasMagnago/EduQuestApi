using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Alunos.GetById
{
    public interface IGetAlunoById
    {
        Task<ResponseAlunoJson> Execute(int id);
    }
}
