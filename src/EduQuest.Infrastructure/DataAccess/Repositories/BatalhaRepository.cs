using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class BatalhaRepository : GenericRepository<Batalha>, IBatalhaRepository
    {
        public BatalhaRepository(EduQuestDbContext context) : base(context)
        {

        }

        public async Task<Batalha?> GetWithRelationsById(int batalhaId)
        {
            return await _entity
                .Include(b => b.BatalhaQuestoes)
                    .ThenInclude(bq => bq.Questao)
                    .ThenInclude(q => q.Alternativas)
                .Include(b => b.BatalhaRespostas)
                .Where(b => b.Id == batalhaId)
                .FirstOrDefaultAsync();
        }
    }
}
