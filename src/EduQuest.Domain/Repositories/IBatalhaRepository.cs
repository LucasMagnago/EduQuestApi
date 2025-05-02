using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IBatalhaRepository : IGenericRepository<Batalha>
    {
        Task<Batalha?> GetWithRelationsById(int batalhaId);
    }
}


