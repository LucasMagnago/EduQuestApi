using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IAlunoPossuiItemRepository : IGenericRepository<AlunoPossuiItem>
    {
        Task<List<AlunoPossuiItem>?> GetAllByAlunoId(int alunoId);
        Task<bool> AlunoAlreadyHasItem(int alunoId, int itemId);
    }
}
