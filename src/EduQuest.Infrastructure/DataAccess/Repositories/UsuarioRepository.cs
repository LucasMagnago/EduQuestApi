using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class UsuarioRepository : GenericRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(EduQuestDbContext context) : base(context)
        {
        }

        public async Task<Usuario?> GetByGuid(Guid guid)
        {
            return await _entity
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.UsuarioIdentifier.Equals(guid));
        }

        public async Task<Usuario?> GetByEmail(string email)
        {
            return await _entity
                .AsNoTracking()
                .FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public async Task<bool> ExistsActiveUsuarioWithEmail(string email)
        {
            return await _entity
                .AnyAsync(u => u.Email.Equals(email));
        }
    }
}
