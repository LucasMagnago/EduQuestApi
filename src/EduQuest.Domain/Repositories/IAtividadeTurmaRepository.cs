using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IAtividadeTurmaRepository : IGenericRepository<AtividadeTurma>
    {
        Task<DateTime> GetDataEntregaAtividade(int atividadeTurmaId);
        Task<DateTime> GetDataEntregaAtividade(int atividadeId, int turmaId);
    }
}
