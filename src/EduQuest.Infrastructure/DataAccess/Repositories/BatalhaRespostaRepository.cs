using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class BatalhaRespostaRepository : GenericRepository<BatalhaResposta>, IBatalhaRespostaRepository
    {
        public BatalhaRespostaRepository(EduQuestDbContext context) : base(context)
        {

        }

        public async Task<int> CountCorrectRespostasForAlunoInBatalhaAsync(int alunoId, int batalhaId)
        {
            return await _entity
               .Where(resposta =>
                   resposta.BatalhaId == batalhaId &&
                   resposta.AlunoId == alunoId &&
                   resposta.Acertou)
               .CountAsync();
        }

        public async Task<BatalhaResposta?> GetBatalhaRespostaByAlunoIdAndBatalhaIdAndQuestaoIdAsync(int alunoId, int batalhaId, int questaoId)
        {
            return await _entity
                .Where(resposta =>
                    resposta.BatalhaId == batalhaId &&
                    resposta.AlunoId == alunoId &&
                    resposta.QuestaoId == questaoId)
                .FirstOrDefaultAsync();
        }
    }
}
