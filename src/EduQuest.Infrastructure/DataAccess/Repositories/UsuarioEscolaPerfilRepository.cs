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

        public async Task<UsuarioEscolaPerfil?> GetActiveByUsuarioIdAsync(int usuarioId)
        {
            return await _context.UsuarioEscolaPerfis
                .Include(u => u.Perfil)
                .Where(u => u.UsuarioId == usuarioId && u.Ativo)
                .FirstOrDefaultAsync();
        }

        public async Task<UsuarioEscolaPerfil?> GetActiveByUsuarioGuidAsync(Guid usuarioGuid)
        {
            return await _context.UsuarioEscolaPerfis
                .Include(u => u.Usuario)
                .Include(u => u.Perfil)
                .Where(u => u.Usuario.UsuarioIdentifier == usuarioGuid && u.Ativo)
                .FirstOrDefaultAsync();
        }

        public async Task<UsuarioEscolaPerfil?> GetActiveWithRelationsByUsuarioIdAsync(int usuarioId)
        {
            return await _context.UsuarioEscolaPerfis
                .Include(u => u.Usuario)
                .Include(u => u.Perfil)
                .Include(u => u.Escola)
                .Where(u => u.UsuarioId == usuarioId && u.Ativo)
                .FirstOrDefaultAsync();
        }

        public async Task<UsuarioEscolaPerfil?> GetActiveWithRelationsByUsuarioGuidAsync(Guid usuarioGuid)
        {
            return await _context.UsuarioEscolaPerfis
                .Include(u => u.Usuario)
                .Include(u => u.Perfil)
                .Include(u => u.Escola)
                .Where(u => u.Usuario.UsuarioIdentifier == usuarioGuid && u.Ativo)
                .FirstOrDefaultAsync();
        }

        public async Task<List<UsuarioEscolaPerfil>?> GetAllByUsuarioIdAsync(int usuarioId)
        {
            return await _context.UsuarioEscolaPerfis
                .Include(u => u.Perfil)
                .Where(u => u.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task<List<UsuarioEscolaPerfil>?> GetAllWithRelationsByUsuarioIdAsync(int usuarioId)
        {
            return await _context.UsuarioEscolaPerfis
                .Include(u => u.Usuario)
                .Include(u => u.Perfil)
                .Include(u => u.Escola)
                .Where(u => u.UsuarioId == usuarioId)
                .ToListAsync();
        }

        public async Task<List<UsuarioEscolaPerfil>?> GetAllByUsuarioGuidAsync(Guid usuarioGuid)
        {
            return await _context.UsuarioEscolaPerfis
                .Include(u => u.Perfil)
                .Where(u => u.Usuario.UsuarioIdentifier == usuarioGuid)
                .ToListAsync();
        }
        public async Task<List<UsuarioEscolaPerfil>?> GetAllWithRelationsByUsuarioGuidAsync(Guid usuarioGuid)
        {
            return await _context.UsuarioEscolaPerfis
                .Include(u => u.Usuario)
                .Include(u => u.Perfil)
                .Include(u => u.Escola)
                .Where(u => u.Usuario.UsuarioIdentifier == usuarioGuid)
                .ToListAsync();
        }

        public async Task<List<UsuarioEscolaPerfil>?> GetAllWithRelations()
        {
            return await _entity
                .Include(u => u.Usuario)
                .Include(u => u.Perfil)
                .Include(u => u.Escola)
                .ToListAsync();
        }

        public async Task<bool> DoesUsuarioHavePerfilInEscolaAsync(Guid usuarioGuid, int escolaId, int perfilId)
        {
            return await _context.UsuarioEscolaPerfis.AnyAsync(u => u.Usuario.UsuarioIdentifier == usuarioGuid && u.EscolaId == escolaId && u.PerfilId == perfilId);
        }

        public async Task<bool> DoesUsuarioHavePerfilInEscolaAsync(int usuarioId, int escolaId, int perfilId)
        {
            return await _context.UsuarioEscolaPerfis.AnyAsync(u => u.UsuarioId == usuarioId && u.EscolaId == escolaId && u.PerfilId == perfilId);
        }

        public async Task<UsuarioEscolaPerfil?> GetByUsuarioIdAndEscolaIdAndPerfilIdAsync(int usuarioId, int escolaId, int perfilId)
        {
            return await _context.UsuarioEscolaPerfis
                .Where(u => u.UsuarioId == usuarioId && u.EscolaId == escolaId && u.PerfilId == perfilId)
                .FirstOrDefaultAsync();
        }
    }
}
