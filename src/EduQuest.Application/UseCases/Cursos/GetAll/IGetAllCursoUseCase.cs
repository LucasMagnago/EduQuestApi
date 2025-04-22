using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Cursos.GetAll
{
    public interface IGetAllCursoUseCase
    {
        Task<List<ResponseCursoJson>> Execute();
    }
}
