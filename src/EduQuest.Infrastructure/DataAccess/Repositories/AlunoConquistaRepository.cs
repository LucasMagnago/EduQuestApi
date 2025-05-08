using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AlunoConquistaRepository : GenericRepository<AlunoConquista>, IAlunoConquistaRepository
    {
        public AlunoConquistaRepository(EduQuestDbContext context) : base(context)
        {

        }

        public async Task<List<AlunoConquista>?> GetAllByAlunoId(int alunoId)
        {
            return await _entity.Include(aq => aq.Conquista)
                .Where(aq => aq.AlunoId == alunoId)
                .ToListAsync();
        }
    }
}
