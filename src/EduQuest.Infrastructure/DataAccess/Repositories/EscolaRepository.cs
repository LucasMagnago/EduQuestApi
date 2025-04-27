using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class EscolaRepository : GenericRepository<Escola>, IEscolaRepository
    {
        public EscolaRepository(EduQuestDbContext context) : base(context)
        {

        }

        public async Task<bool> ExistsWithNomeAsync(string nome)
        {
            return await _entity
                .AnyAsync(e => e.Nome.Equals(nome));
        }

        public async Task<bool> ExistsWithSiglaAsync(string sigla)
        {
            return await _entity
                .AnyAsync(e => e.Sigla.Equals(sigla));
        }
    }
}
