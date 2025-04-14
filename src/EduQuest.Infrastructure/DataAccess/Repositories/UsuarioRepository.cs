using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class UsuarioRepository : IUsuarioRepository
    {
        private readonly EduQuestDbContext _context;

        public UsuarioRepository(EduQuestDbContext context)
        {
            _context = context;
        }

        public async Task Add(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
        }

        public async Task Delete(Usuario usuario)
        {
            var usuarioToRemove = await _context.Usuarios.FindAsync(usuario.Id);
            _context.Usuarios.Remove(usuarioToRemove!);
        }

        public async Task<bool> ExistActiveUserWithEmail(string email)
        {
            return await _context.Usuarios.AnyAsync(u => u.Email.Equals(email));
        }

        public async Task<Usuario> GetById(long id)
        {
            return await _context.Usuarios.FirstAsync(user => user.Id == id);
        }

        public async Task<Usuario?> GetUserByEmail(string email)
        {
            return await _context.Usuarios.AsNoTracking().FirstOrDefaultAsync(user => user.Email.Equals(email));
        }

        public void Update(Usuario user)
        {
            _context.Usuarios.Update(user);
        }
    }
}
