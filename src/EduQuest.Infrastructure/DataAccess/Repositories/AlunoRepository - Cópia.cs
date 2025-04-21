using EduQuest.Domain.Entities;
using EduQuest.Domain.Enums;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class MatriculaRepository : GenericRepository<Matricula>, IMatriculaRepository
    {
        public MatriculaRepository(EduQuestDbContext context) : base(context)
        {

        }

        public async Task<Matricula?> GetMatriculaAtivaByUsuarioId(int alunoId)
        {
            return await _context.Matriculas
                .Where(m => m.AlunoId == alunoId && m.Situacao == SituacaoMatricula.Normal)
                .FirstOrDefaultAsync();
        }

        public async Task<Matricula?> GetMatriculaAtivaByUsuarioGuid(Guid alunoGuid)
        {
            return await _context.Matriculas
                .Where(m => m.Aluno.UsuarioIdentifier == alunoGuid && m.Situacao == SituacaoMatricula.Normal)
                .FirstOrDefaultAsync();
        }
    }
}
