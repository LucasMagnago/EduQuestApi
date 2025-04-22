using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Disciplinas.GetById
{
    public interface IGetDisciplinaByIdUseCase
    {
        Task<ResponseDisciplinaJson> Execute(int id);
    }
}
