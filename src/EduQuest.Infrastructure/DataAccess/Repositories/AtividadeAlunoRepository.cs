using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AtividadeAlunoRepository : GenericRepository<AtividadeAluno>, IAtividadeAlunoRepository
    {
        public AtividadeAlunoRepository(EduQuestDbContext context) : base(context)
        {

        }

        public async Task<bool> CheckIfAlunoAlreadyStartedAtividade(int alunoId, int atividadeId)
        {
            return await _context.AtividadeAlunos
                .Where(aa => aa.AlunoId == alunoId && aa.AtividadeId == atividadeId)
                .AnyAsync();
        }

        public async Task<AtividadeAluno?> GetByAlunoIdAndAtividadeId(int alunoId, int atividadeId)
        {
            return await _context.AtividadeAlunos
                .Include(aa => aa.Atividade)
                .Where(aa => aa.AlunoId == alunoId && aa.AtividadeId == atividadeId)
                .FirstOrDefaultAsync();
        }

        public Task<int> GetQuantidadeAcertos(int atividadeAlunoId)
        {
            throw new NotImplementedException();
        }
    }
}
