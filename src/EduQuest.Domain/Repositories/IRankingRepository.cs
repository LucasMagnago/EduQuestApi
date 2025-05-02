using EduQuest.Domain.DTOs;

namespace EduQuest.Domain.Repositories
{
    public interface IRankingRepository
    {
        #region Ranking Atividades Concluídas

        Task<List<AlunoRankingDTO>> GetRankingAlunosPorAtividadeConcluidaNaTurma(int turmaId);


        Task<List<AlunoRankingDTO>> GetRankingAlunosPorAtividadeConcluidaNaEscola(int escolaId);

        Task<List<TurmaRankingDTO>> GetRankingTurmasPorMediaAtividadesConcluidasNaEscola(int escolaId);
        #endregion

        #region Ranking Média Nota em Atividades

        Task<List<AlunoRankingDTO>> GetRankingAlunosPorMediaNotaNaTurma(int turmaId);

        Task<List<AlunoRankingDTO>> GetRankingAlunosPorMediaNotaNaEscola(int escolaId);

        Task<List<TurmaRankingDTO>> GetRankingTurmasPorMediaGeralNotaNaEscola(int escolaId);

        #endregion

        //---------------------------------------------------------------------
        // Métricas de Batalhas e Questões (Alunos)
        //---------------------------------------------------------------------

        #region Ranking Batalhas Participadas

        Task<List<AlunoRankingDTO>> GetRankingAlunosPorBatalhasParticipadasNaTurma(int turmaId);

        Task<List<AlunoRankingDTO>> GetRankingAlunosPorBatalhasParticipadasNaEscola(int escolaId);
        #endregion

        #region Ranking Batalhas Vencidas

        Task<List<AlunoRankingDTO>> GetRankingAlunosPorBatalhasVencidasNaTurma(int turmaId);

        Task<List<AlunoRankingDTO>> GetRankingAlunosPorBatalhasVencidasNaEscola(int escolaId);

        #endregion

        #region Ranking Questões Respondidas (Total)

        Task<List<AlunoRankingDTO>> GetRankingAlunosPorQuestoesRespondidasNaTurma(int turmaId);

        Task<List<AlunoRankingDTO>> GetRankingAlunosPorQuestoesRespondidasNaEscola(int escolaId);

        #endregion

        #region Ranking Questões Acertadas (Total)

        Task<List<AlunoRankingDTO>> GetRankingAlunosPorQuestoesAcertadasNaTurma(int turmaId);

        Task<List<AlunoRankingDTO>> GetRankingAlunosPorQuestoesAcertadasNaEscola(int escolaId);


        #endregion
    }
}
