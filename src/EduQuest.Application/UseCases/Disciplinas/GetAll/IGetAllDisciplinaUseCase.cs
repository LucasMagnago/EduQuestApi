using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Disciplinas.GetAll
{
    public interface IGetAllDisciplinaUseCase
    {
        Task<List<ResponseDisciplinaJson>> Execute();
    }
}
