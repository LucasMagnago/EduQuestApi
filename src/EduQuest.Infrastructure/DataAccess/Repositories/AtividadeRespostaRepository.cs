using EduQuest.Domain.Entities;
using EduQuest.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace EduQuest.Infrastructure.DataAccess.Repositories
{
    internal class AtividadeRespostaRepository : GenericRepository<AtividadeResposta>, IAtividadeRespostaRepository
    {
        public AtividadeRespostaRepository(EduQuestDbContext context) : base(context)
        {

        }

        public async Task<AtividadeResposta?> GetByAlunoIdAndAtividadeIdAndQuestaoId(int alunoId, int AtividadeId, int QuestaoId)
        {
            return await _entity
                .Include(ar => ar.AtividadeAluno)
                .Where(ar => ar.AtividadeAluno.AlunoId == alunoId &&
                    ar.AtividadeAluno.AtividadeId == AtividadeId &&
                    ar.QuestaoId == QuestaoId)
                .SingleOrDefaultAsync();
        }

        public async Task<AtividadeResposta?> GetByAtividadeAlunoIdAndQuestaoId(int atividadeAlunoId, int QuestaoId)
        {
            return await _entity
                .Where(ar => ar.AtividadeAlunoId == atividadeAlunoId &&
                    ar.QuestaoId == QuestaoId)
                .SingleOrDefaultAsync();
        }
    }
}
