using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IEscolaRepository : IGenericRepository<Escola>
    {
        Task<Escola?> GetEscolaWithRelationsByIdAsync(int id);
        Task<List<Escola>?> GetAllEscolasWithRelationsByIdAsync();
        Task<bool> ExistsWithNomeAsync(string nome);
        Task<bool> ExistsWithSiglaAsync(string sigla);
    }
}
