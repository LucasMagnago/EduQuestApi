using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class UsuarioEscolaPerfilRepository
        : GenericRepository<UsuarioEscolaPerfil>, IUsuarioEscolaPerfilRepository
    {
        public UsuarioEscolaPerfilRepository(EduQuestDbContext context) : base(context)
        {

        }

        public async Task<UsuarioEscolaPerfil> GetActiveByUsuarioGuidAsync(Guid usuarioGuid)
        {
            return await _context.UsuarioEscolaPerfis
                .Include(u => u.Usuario)
                .Include(u => u.Perfil)
                .Where(u => u.Usuario.UsuarioIdentifier == usuarioGuid && u.Ativo)
                .FirstAsync();
        }

        public async Task<UsuarioEscolaPerfil> GetActiveByUsuarioIdAsync(int usuarioId)
        {
            return await _context.UsuarioEscolaPerfis
                .Include(u => u.Perfil)
                .Where(u => u.UsuarioId == usuarioId && u.Ativo)
                .FirstAsync();
        }

        public async Task<List<UsuarioEscolaPerfil>> GetAllByUsuarioGuidAsync(Guid usuarioGuid)
        {
            return await _context.UsuarioEscolaPerfis
                .Include(u => u.Perfil)
                .Where(u => u.Usuario.UsuarioIdentifier == usuarioGuid)
                .ToListAsync();
        }

        public async Task<List<UsuarioEscolaPerfil>> GetAllByUsuarioIdAsync(int usuarioId)
        {
            return await _context.UsuarioEscolaPerfis
                .Include(u => u.Perfil)
                .Where(u => u.UsuarioId == usuarioId)
                .ToListAsync();
        }
    }
}
