using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IQuestaoRepository : IGenericRepository<Questao>
    {
        Task<List<Questao>> GetAllByDisciplinaId(int disciplinaId);
        Task<List<Questao>> GetAllByDisciplinaIdAndNivel(int disciplinaId, int nivel);
        Task<List<Questao>> GetAllByProfessorId(int professorId);
    }
}
