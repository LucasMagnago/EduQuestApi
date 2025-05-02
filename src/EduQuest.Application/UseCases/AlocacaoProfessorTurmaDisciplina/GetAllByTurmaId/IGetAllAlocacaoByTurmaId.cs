using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.GetAllByTurmaId
{
    public interface IGetAllAlocacaoByTurmaId
    {
        Task<List<ResponseProfessorDisciplinaTurmaJson>> Execute(int turmaId);
    }
}

