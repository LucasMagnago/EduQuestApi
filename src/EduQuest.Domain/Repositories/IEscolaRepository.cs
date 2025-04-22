using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IEscolaRepository : IGenericRepository<Escola>
    {
        Task<bool> ExistsWithNomeAsync(string nome);
        Task<bool> ExistsWithSiglaAsync(string sigla);
    }
}
