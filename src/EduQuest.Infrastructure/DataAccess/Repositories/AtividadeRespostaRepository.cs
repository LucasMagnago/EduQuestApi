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

        public async Task<IEnumerable<AtividadeResposta>> GetAllByAlunoIdAndAtividadeId(int alunoId, int atividadeId)
        {
            return await _entity
                .Include(ar => ar.AtividadeAluno)
                .Include(ar => ar.AlternativaEscolha)
                .Where(ar => ar.AtividadeAluno.AlunoId == alunoId &&
                    ar.AtividadeAluno.AtividadeId == atividadeId)
                .Select(ar => new AtividadeResposta
                {
                    Id = ar.Id,
                    Acertou = ar.Acertou,
                    DataResposta = ar.DataResposta,
                    AtividadeAlunoId = ar.AtividadeAlunoId,
                    QuestaoId = ar.QuestaoId,
                    AlternativaEscolha = ar.AlternativaEscolha,
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<AtividadeResposta>> GetAllByAtividadeAlunoId(int atividadeAlunoId)
        {
            return await _entity
                .Include(ar => ar.AlternativaEscolha)
                .Where(ar => ar.AtividadeAlunoId == atividadeAlunoId)
                .Select(ar => new AtividadeResposta
                {
                    Id = ar.Id,
                    Acertou = ar.Acertou,
                    DataResposta = ar.DataResposta,
                    AtividadeAlunoId = ar.AtividadeAlunoId,
                    QuestaoId = ar.QuestaoId,
                    AlternativaEscolha = ar.AlternativaEscolha,
                })
                .ToListAsync();
        }
    }
}
