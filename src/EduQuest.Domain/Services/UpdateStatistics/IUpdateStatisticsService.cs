namespace EduQuest.Domain.Services.UpdateStatistics
{
    public interface IUpdateStatisticsService
    {
        Task UpdateAlunoStatisticsInBatalhas(int batalhaId);
        Task UpdateEscolaStatisticsInBatalhas(int batalhaId);
        Task UpdateTurmaStatisticsInBatalhas(int batalhaId);
        Task UpdateAlunoStatisticsInAtividades(int atividadeAlunoId);
        Task UpdateEscolaStatisticsInAtividades(int atividadeAlunoId);
        Task UpdateTurmaStatisticsInAtividades(int atividadeAlunoId);
    }
}
