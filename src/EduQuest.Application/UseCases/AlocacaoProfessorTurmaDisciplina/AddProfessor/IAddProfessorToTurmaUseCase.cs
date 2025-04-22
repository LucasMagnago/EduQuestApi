using EduQuest.Communication.Requests;
using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.AddProfessor
{
    public interface IAddProfessorToTurmaUseCase
    {
        Task<ResponseAlocacaoProfessorJson> Execute(RequestAddProfessorToTurmaJson request);
    }
}
