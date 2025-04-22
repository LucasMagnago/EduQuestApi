using EduQuest.Communication.Requests;

namespace EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.RemoveProfessor
{
    public interface IRemoveProfessorFromTurmaUseCase
    {
        Task Execute(RequestRemoveProfessorFromTurmaJson request);
    }
}
