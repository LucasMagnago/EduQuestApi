using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Cursos.GetById
{
    public interface IGetCursoByIdUseCase
    {
        Task<ResponseCursoJson> Execute(int id);
    }
}
