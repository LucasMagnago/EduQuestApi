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

        public async Task<List<Usuario>?> GetAllByEscolaId(int escolaId)
        {
            return await _entity
                .AsNoTracking()
                .Where(user => user.UsuarioEscolaPerfis.Any(uep => uep.EscolaId == escolaId))
                .ToListAsync();
        }

        public async Task<List<Usuario>?> GetAllByPerfilId(int perfilId)
        {
            return await _entity
                .AsNoTracking()
                .Where(user => user.UsuarioEscolaPerfis.Any(uep => uep.PerfilId == perfilId))
                .ToListAsync();
        }

        public async Task<List<Usuario>?> GetAllByListPerfilId(List<int> lstPerfilId)
        {
            return await _entity
                .AsNoTracking()
                .Where(user => user.UsuarioEscolaPerfis.Any(uep => lstPerfilId.Contains(uep.PerfilId)))
                .ToListAsync();
        }

        public async Task<List<Usuario>?> GetAllByPerfilIdAndEscolaId(int perfilId, int escolaId)
        {
            return await _entity
                .AsNoTracking()
                .Where(user => user.UsuarioEscolaPerfis.Any(uep => uep.EscolaId == escolaId && uep.PerfilId == perfilId))
                .ToListAsync();
        }

        public async Task<List<Usuario>?> GetAllByListPerfilIdAndEscolaId(List<int> lstPerfilId, int escolaId)
        {
            return await _entity
                .AsNoTracking()
                .Where(user => user.UsuarioEscolaPerfis.Any(uep => lstPerfilId.Contains(uep.PerfilId) && uep.EscolaId == escolaId))
                .ToListAsync();
        }
    }
}
