using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AlunoPossuiItemRepository : GenericRepository<AlunoPossuiItem>, IAlunoPossuiItemRepository
    {
        public AlunoPossuiItemRepository(EduQuestDbContext context) : base(context)
        {

        }

        public async Task<List<AlunoPossuiItem>?> GetAllByAlunoId(int alunoId)
        {
            return await _entity.Include(a => a.Item)
                .Where(a => a.AlunoId == alunoId)
                .ToListAsync();
        }

        public async Task<bool> AlunoAlreadyHasItem(int alunoId, int itemId)
        {
            return await _entity.AnyAsync(a => a.AlunoId == alunoId && a.ItemId == itemId);
        }
    }
}
