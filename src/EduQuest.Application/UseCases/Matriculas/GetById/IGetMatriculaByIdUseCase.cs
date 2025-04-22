using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.Matriculas.GetById
{
    public interface IGetMatriculaByIdUseCase
    {
        Task<ResponseMatriculaJson> Execute(int id);
    }
}
