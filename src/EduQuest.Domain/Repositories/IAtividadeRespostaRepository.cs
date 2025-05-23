﻿using EduQuest.Domain.Entities;

namespace EduQuest.Domain.Repositories
{
    public interface IAtividadeRespostaRepository : IGenericRepository<AtividadeResposta>
    {
        Task<AtividadeResposta?> GetByAlunoIdAndAtividadeIdAndQuestaoId(int alunoId, int AtividadeId, int QuestaoId);
        Task<AtividadeResposta?> GetByAtividadeAlunoIdAndQuestaoId(int atividadeAlunoId, int QuestaoId);
        Task<IEnumerable<AtividadeResposta>> GetAllByAlunoIdAndAtividadeId(int alunoId, int atividadeId);
        Task<IEnumerable<AtividadeResposta>> GetAllByAtividadeAlunoId(int atividadeAlunoId);
    }
}
