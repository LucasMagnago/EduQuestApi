using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Turmas.GetById
{
    public interface IGetTurmaByIdUseCase
    {
        Task<ResponseTurmaJson> Execute(int id);
    }
}
