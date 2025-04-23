using EduQuest.Communication.Responses;

namespace EduQuest.Application.UseCases.AlocacaoProfessorTurmaDisciplina.GetAllByProfessorId
{
    public interface IGetAllAlocacaoByProfessorId
    {
        Task<List<ResponseProfessorDisciplinaJson>> Execute(int professorId);
    }
}
