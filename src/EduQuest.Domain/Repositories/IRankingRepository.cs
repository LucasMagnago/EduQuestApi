using EduQuest.Domain.DTOs;

namespace EduQuest.Domain.Repositories
{
    public interface IRankingRepository
    {
        //-------------------------------------------------------------------------
        // RANKING DE ALUNOS
        //-------------------------------------------------------------------------

        #region Atividades Concluídas

        Task<List<AlunoRankingDTO>> GetRankingAlunosByAtividadesConcluidasInTurma(int turmaId);
        Task<List<AlunoRankingDTO>> GetRankingAlunosByAtividadesConcluidasInEscola(int escolaId);

        #endregion

        #region Média de Notas

        Task<List<AlunoRankingDTO>> GetRankingAlunosByMediaNotasInTurma(int turmaId);
        Task<List<AlunoRankingDTO>> GetRankingAlunosByMediaNotasInEscola(int escolaId);

        #endregion

        #region Batalhas Participadas

        Task<List<AlunoRankingDTO>> GetRankingAlunosByBatalhasParticipadasInTurma(int turmaId);
        Task<List<AlunoRankingDTO>> GetRankingAlunosByBatalhasParticipadasInEscola(int escolaId);

        #endregion

        #region Batalhas Vencidas

        Task<List<AlunoRankingDTO>> GetRankingAlunosByBatalhasVencidasInTurma(int turmaId);
        Task<List<AlunoRankingDTO>> GetRankingAlunosByBatalhasVencidasInEscola(int escolaId);

        #endregion

        //-------------------------------------------------------------------------
        // RANKING DE TURMAS
        //-------------------------------------------------------------------------

        #region Atividades Concluídas

        Task<List<TurmaRankingDTO>> GetRankingTurmasByAtividadesConcluidasInEscola(int escolaId);

        #endregion

        #region Média de Notas

        Task<List<TurmaRankingDTO>> GetRankingTurmasByMediaNotasInEscola(int escolaId);

        #endregion

        #region Batalhas Participadas

        Task<List<TurmaRankingDTO>> GetRankingTurmasByBatalhasParticipadasInEscola(int escolaId);

        #endregion

        #region Batalhas Vencidas

        Task<List<TurmaRankingDTO>> GetRankingTurmasByBatalhasVencidasInEscola(int escolaId);

        #endregion

        //-------------------------------------------------------------------------
        // RANKING DE ESCOLAS
        //-------------------------------------------------------------------------

        #region Atividades Concluídas

        Task<List<EscolaRankingDTO>> GetRankingEscolasByAtividadesConcluidas();

        #endregion

        #region Média de Notas

        Task<List<EscolaRankingDTO>> GetRankingEscolasByMediaNotas();

        #endregion

        #region Batalhas Participadas

        Task<List<EscolaRankingDTO>> GetRankingEscolasByBatalhasParticipadas();

        #endregion

        #region Batalhas Vencidas

        Task<List<EscolaRankingDTO>> GetRankingEscolasByBatalhasVencidas();

        #endregion
    }
}
