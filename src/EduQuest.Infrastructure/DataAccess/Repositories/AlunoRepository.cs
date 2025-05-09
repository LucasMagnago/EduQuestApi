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

        public async Task<Aluno?> GetByAlunoId(int alunoId)
        {
            return await _entity
                .Where(a => a.Id == alunoId)
                .FirstOrDefaultAsync();
        }

        public async Task<Aluno?> GetByUsuarioGuid(Guid usuarioGuid)
        {
            return await _entity
                .Where(a => a.UsuarioIdentifier == usuarioGuid)
                .FirstOrDefaultAsync();
        }

        public async Task<bool> ExistAlunoWithUsuarioGuid(Guid usuarioGuid)
        {
            return await _entity.AnyAsync(a => a.UsuarioIdentifier == usuarioGuid);
        }

        public async Task<Turma?> GetTurmaByAlunoId(int alunoId)
        {
            return await _entity
                .Where(a => a.Id == alunoId && a.Turma != null)
                .Select(a => a.Turma)
                .FirstOrDefaultAsync();
        }

        public async Task<Escola?> GetEscolaByAlunoId(int alunoId)
        {
            return await _entity
                .Where(a => a.Id == alunoId && a.Turma != null)
                .Select(a => a.Turma!.Escola)
                .FirstOrDefaultAsync();
        }

        public async Task<List<Aluno>?> GetAllByTurmaId(int turmaId)
        {
            return await _entity
                .Where(a => a.TurmaId == turmaId)
                .ToListAsync();
        }

        public async Task<List<Aluno>?> GetAllByEscolaId(int escolaId)
        {
            return await _entity
                .Include(a => a.Turma)
                .Where(a => a.Turma != null && a.Turma.EscolaId == escolaId)
                .ToListAsync();
        }
    }
}
