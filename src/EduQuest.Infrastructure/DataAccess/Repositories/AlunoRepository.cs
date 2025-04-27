using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AlunoRepository : GenericRepository<Aluno>, IAlunoRepository
    {
        public AlunoRepository(EduQuestDbContext context) : base(context)
        {

        }

        public async Task<Aluno?> GetByUsuarioGuid(Guid usuarioGuid)
        {
            return await _entity
                .Where(a => a.UsuarioIdentifier == usuarioGuid && a.Ativo)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ExistAlunoWithUsuarioGuid(Guid usuarioGuid)
        {
            return await _entity.AnyAsync(a => a.UsuarioIdentifier == usuarioGuid);
        }

        public async Task<Turma?> GetTurmaByAlunoId(int alunoId)
        {
            return await _entity
                .Where(a => a.Id == alunoId)
                .Select(a => a.Turma)
                .FirstOrDefaultAsync();
        }
    }
}
